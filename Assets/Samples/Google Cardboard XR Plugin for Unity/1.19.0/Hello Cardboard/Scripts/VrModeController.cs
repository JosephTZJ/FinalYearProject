//-----------------------------------------------------------------------
// <copyright file="VrModeController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEngine.SceneManagement;
// using BackgroundMusicAudioPlayerScript;


/// <summary>
/// Turns VR mode on and off.
/// </summary>
public class VrModeController : MonoBehaviour
{
    // Field of view value to be used when the scene is not in VR mode. In case
    // XR isn't initialized on startup, this value could be taken from the main
    // camera and stored.
    private const float _defaultFieldOfView = 60.0f;

    // Main camera from the scene.
    private Camera _mainCamera;
    private Scene currentScene;

    /// <summary>
    /// Gets a value indicating whether the screen has been touched this frame.
    /// </summary>
    private bool _isScreenTouched
    {
        get
        {
            return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the VR mode is enabled.
    /// </summary>
    private bool _isVrModeEnabled
    {
        get
        {
            return XRGeneralSettings.Instance.Manager.isInitializationComplete;
        }
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        // Saves the main camera from the scene.
        _mainCamera = Camera.main;

        // Configures the app to not shut down the screen and sets the brightness to maximum.
        // Brightness control is expected to work only in iOS, see:
        // https://docs.unity3d.com/ScriptReference/Screen-brightness.html.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        // Checks if the device parameters are stored and scans them if not.
        // This is only required if the XR plugin is initialized on startup,
        // otherwise these API calls can be removed and just be used when the XR
        // plugin is started.
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
        currentScene = SceneManager.GetActiveScene();
        string[] VRModeScenes = {
            "Story2_1ClassroomScene", "Story2_2ClassroomScene", "Story3_1ClassroomScene", "Story3_2PlaygroundScene"
        };
        string[] NonVRModeScenes = {
            "ChangeBgScene", "ClassroomSettingScene", "CorridorSettingScene",
            "LanguageSelectionScene", "LoadingScene", "ModifyObjectScene",
            "ParentChooseEnvironmentScene", "RoleMenuScene", "StorySelectionScene",
            "UpdateChildNameScene"
        };

        if (System.Array.Exists(VRModeScenes, scene => scene == currentScene.name))
        {
            EnterVR();
        }
        else if (System.Array.Exists(NonVRModeScenes, scene => scene == currentScene.name))
        {
            ExitVR();
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        if (Api.IsCloseButtonPressed)
        {
            // Animator animator = GetComponent<Animator>();
            // if (animator != null)
            // {
            //     animator.enabled = false; // Disable the Animator component
            // }

            // Find all objects with Animator components in the scene
            // Animator[] animators = FindObjectsOfType<Animator>();

            // // Optionally, you can filter the animators based on specific criteria (tags, names, etc.)
            // // animators = animators.Where(animator => animator.CompareTag("YourTag")).ToArray();

            // // Disable all found animators
            // foreach (Animator animator in animators)
            // {
            //     if (animator != null)
            //     {
            //         Debug.Log("active animators: "+ animator);
            //         SSTools.ShowMessage("active animators:"+ animator, SSTools.Position.bottom, SSTools.Time.oneSecond);
            //         animator.enabled = false;
            //     }
            // }
            // // BackgroundMusicAudioPlayerScript instance = instance.GetComponent<AudioSource>().Pause();
            // SceneManager.LoadScene("StorySelectionScene");
        }
        /* if (_isVrModeEnabled)
        {
            if (Api.IsCloseButtonPressed)
            {
                ExitVR();
            }

            if (Api.IsGearButtonPressed)
            {
                Api.ScanDeviceParams();
            }

            Api.UpdateScreenParams();
        }
        else
        {
            // TODO(b/171727815): Add a button to switch to VR mode.
            if (_isScreenTouched)
            {
                EnterVR();
            }
        } */
    }

    /// <summary>
    /// Enters VR mode.
    /// </summary>
    private void EnterVR()
    {
        StartCoroutine(StartXR());
        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
    }

    /// <summary>
    /// Exits VR mode.
    /// </summary>
    private void ExitVR()
    {
        StopXR();
    }

    /// <summary>
    /// Initializes and starts the Cardboard XR plugin.
    /// See https://docs.unity3d.com/Packages/com.unity.xr.management@3.2/manual/index.html.
    /// </summary>
    ///
    /// <returns>
    /// Returns result value of <c>InitializeLoader</c> method from the XR General Settings Manager.
    /// </returns>
    private IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }

    /// <summary>
    /// Stops and deinitializes the Cardboard XR plugin.
    /// See https://docs.unity3d.com/Packages/com.unity.xr.management@3.2/manual/index.html.
    /// </summary>
    private void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");

        _mainCamera.ResetAspect();
        _mainCamera.fieldOfView = _defaultFieldOfView;
    }
}