using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// when clicking cross "x" at the top
using Google.XR.Cardboard;
using UnityEngine.XR;
using UnityEngine.XR.Management;
// namespace BackgroundMusicAudioPlayerScript
// {


public class BackgroundMusicAudioPlayerScript : MonoBehaviour
{
    public static BackgroundMusicAudioPlayerScript instance;

    /* void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            // BackgroundMusicAudioPlayerScript.instance.GetComponent<AudioSource>().Play();
        }
    } */

    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            // BackgroundMusicAudioPlayerScript.instance.GetComponent<AudioSource>().Play();
        }
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
    }
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }

        // Debug.Log("active scene: "+ SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name == "EndStoryScene")
            BackgroundMusicAudioPlayerScript.instance.GetComponent<AudioSource>().Pause();
        else if (SceneManager.GetActiveScene().name == "Story2_2ClassroomScene" || SceneManager.GetActiveScene().name == "Story2_1ClassroomScene" || SceneManager.GetActiveScene().name == "Story3_1ClassroomScene" || SceneManager.GetActiveScene().name == "Story3_2PlaygroundScene")
        {
            // Resume the audio
            BackgroundMusicAudioPlayerScript.instance.GetComponent<AudioSource>().UnPause();
        }

        if (Api.IsCloseButtonPressed)
        {
            BackgroundMusicAudioPlayerScript.instance.GetComponent<AudioSource>().Pause();
        }
        // else
        //     BackgroundMusicAudioPlayerScript.instance.GetComponent<AudioSource>().Play();

        //BGmusic.instance.GetComponent<AudioSource>().Play();

    }

}
// }