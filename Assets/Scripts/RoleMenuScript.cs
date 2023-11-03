using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.XR.Management;
// using UnityEngine.XR.ARCore;

public class RoleMenuScript : MonoBehaviour
{
    // [SerializeField] private ARCoreSession arCoreSession;
    // [SerializeField] private XRCardboard xrCardboard;
    // public bool useARCore = CheckARCoreAvailability();
    // public XRManagerSettings xrManagerSettings;

    public void GoToCorridorScene()
    {
        // EnableARCore();
        SceneManager.LoadScene("CorridorScene");
    }

    public void GoToStorySelectionScene()
    {
        SceneManager.LoadScene("StorySelectionScene");
    }

    public void GoToLanguageSelectionScene()
    {
        SceneManager.LoadScene("LanguageSelectionScene");
    }

    public void GoToClassroomScene()
    {
        // EnableARCore();
        SceneManager.LoadScene("ClassroomScene");
    }

    public void GoToParentScene()
    {
        SceneManager.LoadScene("ParentChooseEnvironmentScene");
    }

    public void GoToClassroomSettingScene()
    {
        SceneManager.LoadScene("ClassroomSettingScene");
    }

    public void GoToUpdateChildNameScene()
    {
        SceneManager.LoadScene("UpdateChildNameScene");
    }

    public void GoToCorridorSettingScene()
    {
        SceneManager.LoadScene("CorridorSettingScene");
    }

    public void GoToChangeBgScene()
    {
        SceneManager.LoadScene("ChangeBgScene");
    }

    public void GoToAddObjectScene()
    {
        SceneManager.LoadScene("ModifyObjectScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("RoleMenuScene");
    }

    public void GoToLoadingSceneStory1()
    {
        PlayerPrefs.SetInt("StoryChosen", 1);
        SceneManager.LoadScene("LoadingScene");
    }

    public void GoToLoadingSceneStory2()
    {
        PlayerPrefs.SetInt("StoryChosen", 2);
        SceneManager.LoadScene("LoadingScene");
    }

    public void GoToLoadingSceneStory3()
    {
        PlayerPrefs.SetInt("StoryChosen", 3);
        SceneManager.LoadScene("LoadingScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /* public void EnableARCore()
    {
        GvrViewer.Instance.VRModeEnabled = false;
        // if (arCoreSession != null)
        //     arCoreSession.enabled = true;
    } */

    // public void DisableARCore()
    // {
    //     if (arCoreSession != null)
    //         arCoreSession.enabled = false;
    // }

    /* public void EnableCardboardXR()
    {
        GvrViewer.Instance.VRModeEnabled = true;
        // if (xrCardboard != null)
        //     xrCardboard.enabled = true;
    } */

    // public void DisableCardboardXR()
    // {
    //     if (xrCardboard != null)
    //         xrCardboard.enabled = false;
    // }

    // private bool CheckARCoreAvailability()
    // {
    //     ARCoreSession.CheckApkAvailability((availability) =>
    //     {
    //         if (availability.IsSupported)
    //         {
    //             Debug.Log("ARCore is supported on this device.");
    //             return true;
    //         }
    //         else
    //         {
    //             Debug.Log("ARCore is not supported on this device.");
    //             return false;
    //         }

    //         if (availability.InstallStatus == ARCoreInstallStatus.Required)
    //         {
    //             // Prompt the user to install ARCore
    //             ARCoreSession.RequestApkInstallation();
    //             return false;
    //         }
    //     });
    // }

}
