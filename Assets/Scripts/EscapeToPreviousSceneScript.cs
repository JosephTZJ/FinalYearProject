using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToPreviousSceneScript : MonoBehaviour
{
    int sceneIndex;
    void Start()
    {
        //// ---- get current scene index ---- ////
        sceneIndex = SceneManager.GetActiveScene ().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        //// ---- go to previous scene by using index-1 ---- ////
        if(Input.GetKeyDown (KeyCode.Escape))
            SceneManager.LoadScene (sceneIndex-1);
    }
}
