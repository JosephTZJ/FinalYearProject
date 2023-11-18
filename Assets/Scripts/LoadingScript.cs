using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        int storyNum = PlayerPrefs.GetInt("StoryChosen");
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        switch (storyNum)
        {
            case 1:
            {
                SceneManager.LoadScene("Story2_1ClassroomScene"); // Load the story scene
                break;
            }
        }
        

        
    }
}
