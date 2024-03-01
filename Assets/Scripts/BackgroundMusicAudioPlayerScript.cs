using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Google.XR.Cardboard;
using UnityEngine.XR;
using UnityEngine.XR.Management;


public class BackgroundMusicAudioPlayerScript : MonoBehaviour
{
    public static BackgroundMusicAudioPlayerScript instance;

    public AudioSource musicSource;
    public GameObject musicPrefab;

    void Start()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (!Api.HasDeviceParams())
            Api.ScanDeviceParams();

        if (instance.musicSource == null)
        {
            GameObject music = Instantiate(musicPrefab);
            instance.musicSource = music.GetComponent<AudioSource>();
        }

        instance.musicSource.volume = PlayerPrefs.GetFloat("musicVolume");

    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "EndStoryScene" || SceneManager.GetActiveScene().name == "ParentChooseEnvironmentScene")
            musicSource.Pause();
        else if (SceneManager.GetActiveScene().name == "AudioSettingScene" || SceneManager.GetActiveScene().name == "Story2_2ClassroomScene" || SceneManager.GetActiveScene().name == "Story2_1ClassroomScene" || SceneManager.GetActiveScene().name == "Story3_1ClassroomScene" || SceneManager.GetActiveScene().name == "Story3_2PlaygroundScene")
        {
            // Resume the audio
            musicSource.UnPause();
        }

        if (Api.IsCloseButtonPressed)
        {
            musicSource.Pause();
        }
       
    }

}