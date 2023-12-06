using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoleMenuScript : MonoBehaviour
{
    public void GoToCorridorScene()
    {
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

    public void GoToLoadingSceneStory2()
    {
        PlayerPrefs.SetInt("StoryChosen", 2);
        SceneManager.LoadScene("LoadingScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
