using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story1NextSceneControllerScript : MonoBehaviour
{
    public string nextSceneName = "";
    public float secondWait=0;
    // Start is called before the first frame update
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        // Debug.Log("Current scene name: " + currentSceneName);
        switch (currentSceneName)
        {
            case "Story1_1RoadScene": 
            {
                secondWait=15;
                StartCoroutine(DelayFunction(secondWait));
                nextSceneName = "Story1_2SchoolScene";
                break;
            }
            case "Story1_2SchoolScene":
            {
                secondWait=32;
                StartCoroutine(DelayFunction(secondWait));
                nextSceneName = "Story1_3CorridorScene";
                break;
            }
            case "Story1_3CorridorScene":
            {
                secondWait=13;
                StartCoroutine(DelayFunction(secondWait));
                nextSceneName = "Story1_4ClassroomScene";
                break;
            }
            case "Story1_4ClassroomScene":
            {
                secondWait=66;
                StartCoroutine(DelayFunction(secondWait));
                nextSceneName = "Story1_5CorridorScene";
                break;
            }
            case "Story1_5CorridorScene":
            {
                secondWait=17;
                StartCoroutine(DelayFunction(secondWait));
                nextSceneName = "Story1_6SchoolScene";
                break;
            }
            case "Story1_6SchoolScene":
            {
                secondWait=6;
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
