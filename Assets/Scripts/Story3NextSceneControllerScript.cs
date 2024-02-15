using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story3NextSceneControllerScript : MonoBehaviour
{
    public string nextSceneName = "";
    public float secondWait = 0;
    // Start is called before the first frame update
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        // Debug.Log("Current scene name: " + currentSceneName);
        switch (currentSceneName)
        {
            case "Story3_1ClassroomScene":
                {
                    secondWait = 27;
                    StartCoroutine(DelayFunction(secondWait));
                    nextSceneName = "EndStoryScene";
                    break;
                }
            case "Story3_2ClassroomScene":
                {
                    secondWait = 79;
                    StartCoroutine(DelayFunction(secondWait));
                    nextSceneName = "EndStoryScene";
                    break;
                }
        }
    }

    IEnumerator DelayFunction(float seconds)
    {
        yield return new WaitForSeconds(seconds); // Wait for x seconds
        loadNextScene(nextSceneName);
        // SceneManager.LoadScene("Story1_2SchoolScene");
    }
    void loadNextScene(string sceneName)
    {
        // SceneManager.LoadScene(sceneName);
        // PanelManager.Instance.SetActiveScene(sceneName);
        PanelManager.Instance.LoadNextScene(sceneName);
    }

}