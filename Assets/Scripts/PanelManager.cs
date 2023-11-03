using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance { get; private set; }

    public PanelReference[] panelReferences;

    private void Awake()
    {
        Debug.Log("Instance "+Instance);
        Debug.Log("This "+this);
        // if (Instance != null && Instance != this)
        // {
        //     Debug.Log("i am here to detroy previous instance "+Instance);
        //     Destroy(gameObject);
        //     return;
        // }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Transform GetPanelByName(string panelName)
    {
        foreach (PanelReference panelReference in panelReferences)
        {
            if (panelReference.panelName == panelName)
            {
                return panelReference.panel;
            }
        }

        return null;
    }
    public void LoadNextScene(string sceneName)
    {
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(sceneName);
    }
}

[System.Serializable]
public class PanelReference
{
    public string panelName;
    public Transform panel;
}