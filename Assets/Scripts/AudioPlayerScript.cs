using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayerScript : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip audioClipEng, audioClipChi, audioClipMal;
    // AudioClip audioClip;
    // string audioPath = "file://" + Application.streamingAssetsPath + "/Audio/";

    // Start is called before the first frame update
    void Awake()
    {
        CheckLanguageSelected();

    }

    /* private WWW GetAudioFromFile(string path, string filename)
    {
        string audioLoad = string.Format(path + filename);
        Debug.Log("audioLoad "+audioLoad);
        WWW request = new WWW(audioLoad);
        return request;
    } */

    private void CheckLanguageSelected()
    {
        string languageSaved = PlayerPrefs.GetString("Language");
        // string languageSaved = "Chinese";
        if (languageSaved == "English")
            audioSrc.clip = audioClipEng;
        else if (languageSaved == "Chinese")
            audioSrc.clip = audioClipChi;
        else if (languageSaved == "Melayu")
            audioSrc.clip = audioClipMal;
        else
            audioSrc.clip = audioClipEng;
        audioSrc.Play();
        Debug.Log("I am here to play audio");
        // string sceneName;
        // string audioFileName="test";

        // sceneName = checkCurrentScene();
        // Debug.Log("checkCurrentScene "+sceneName);

        // if (languageSaved == "English")
        //     audioFileName = "English_" + sceneName + ".mp3";
        // else if (languageSaved == "Chinese")
        //     audioFileName = "Chinese_" + sceneName + ".mp3";
        // else if (languageSaved == "Melayu")
        //     audioFileName = "Melayu_" + sceneName + ".mp3";

        // Debug.Log("audioFileName "+audioFileName);
        // WWW request = GetAudioFromFile(audioPath, audioFileName);
        // audioClip = request.GetAudioClip();
        // audioSrc.clip = audioClip;
        // audioSrc.Play();
        // Debug.Log("I am here to play audio");

    }

    /* private string checkCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        return currentSceneName;
    } */
}
