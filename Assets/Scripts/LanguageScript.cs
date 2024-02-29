using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.SceneManagement;

public class LanguageScript : MonoBehaviour
{
    public TMP_FontAsset fontAssetEnglish;
    public TMP_FontAsset fontAssetChinese;
    public string languageFilePath; // The file path of the language file (e.g., "Languages/English.txt")
    private Dictionary<string, string> languageDictionary;
    String languageSelected, childName;

    void Awake()
    {
        //// To allocate the language file path according to the language selected
        languageSelected = PlayerPrefs.GetString("Language");
        if (languageSelected != null)
        {
            if (languageSelected == "Chinese")
                languageFilePath = "Language/Chinese";
            else if (languageSelected == "English")
                languageFilePath = "Language/English";
            else if (languageSelected == "Melayu")
                languageFilePath = "Language/Melayu";
            Debug.Log("languageFilePath: " + languageFilePath);

            // if (languageSelected == "Chinese")
            //     languageFilePath = "Assets/Resources/Language/Chinese.txt";
            // else if (languageSelected == "English")
            //     languageFilePath = "Assets/Resources/Language/English.txt";
            // Debug.Log("languageFilePath: "+languageFilePath);
        }
        else
        {
            languageSelected = "English";
            languageFilePath = "Language/English";
        }
    }

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "LanguageSelectionScene")
        { // Load the SS text in the story scene only
            // Load and parse the language file
            if (languageFilePath != null)
                LoadLanguageFile(languageFilePath);

            //// To display the text in the storyline according to the language selected
            // Find the canvas
            Canvas canvas = FindObjectOfType<Canvas>();

            if (canvas != null)
            {
                // Transform panel = PanelManager.Instance.panel;
                // Transform panel2 = PanelManager.Instance.panel2;

                Transform panel = PanelManager.Instance.GetPanelByName("TextBubble");
                Transform panel2 = PanelManager.Instance.GetPanelByName("TextBubble2");
                Transform panel3 = PanelManager.Instance.GetPanelByName("TextBubble3");

                // Find all the panels that are children of the canvas
                // Transform panel = canvas.transform.Find("TextBubble");
                // Transform panel2 = canvas.transform.Find("TextBubble2");

                if (panel != null)
                {
                    panel.gameObject.SetActive(true);
                    // Find the TextMeshPro components under each panel
                    TextMeshProUGUI[] textMeshProArray = panel.GetComponentsInChildren<TextMeshProUGUI>(true);

                    // Access and manipulate the TextMeshPro components
                    foreach (TextMeshProUGUI textMeshPro in textMeshProArray)
                    {
                        textMeshPro.text = GetLocalizedString(textMeshPro.name);
                        if (languageSelected == "Chinese")
                            textMeshPro.font = fontAssetChinese;
                        else if (languageSelected == "English" || languageSelected == "Melayu")
                            textMeshPro.font = fontAssetEnglish;

                        Debug.Log("TextMeshPro found: " + textMeshPro.name + "\nText: " + textMeshPro.text);

                    }
                }
                else
                {
                    Debug.Log("here");
                }

                if (panel2 != null)
                {
                    panel2.gameObject.SetActive(true);
                    // Find the TextMeshPro components under each panel
                    TextMeshProUGUI[] textMeshProArray2 = panel2.GetComponentsInChildren<TextMeshProUGUI>(true);

                    // Access and manipulate the TextMeshPro components
                    foreach (TextMeshProUGUI textMeshPro2 in textMeshProArray2)
                    {
                        textMeshPro2.text = GetLocalizedString(textMeshPro2.name);
                        if (languageSelected == "Chinese")
                            textMeshPro2.font = fontAssetChinese;
                        else if (languageSelected == "English" || languageSelected == "Melayu")
                            textMeshPro2.font = fontAssetEnglish;

                        Debug.Log("TextMeshPro2 found: " + textMeshPro2.name + "\nText: " + textMeshPro2.text);

                    }
                }
                else
                {
                    Debug.Log("here again");
                }

                if (panel3 != null)
                {
                    panel3.gameObject.SetActive(true);
                    // Find the TextMeshPro components under each panel
                    TextMeshProUGUI[] textMeshProArray3 = panel3.GetComponentsInChildren<TextMeshProUGUI>(true);

                    // Access and manipulate the TextMeshPro components
                    foreach (TextMeshProUGUI textMeshPro3 in textMeshProArray3)
                    {
                        textMeshPro3.text = GetLocalizedString(textMeshPro3.name);
                        if (languageSelected == "Chinese")
                            textMeshPro3.font = fontAssetChinese;
                        else if (languageSelected == "English" || languageSelected == "Melayu")
                            textMeshPro3.font = fontAssetEnglish;

                        Debug.Log("TextMeshPro2 found: " + textMeshPro3.name + "\nText: " + textMeshPro3.text);

                    }
                }
                else
                {
                    Debug.Log("here again");
                }
            }
            else
            {
                Debug.Log("Canvas not found in the scene.");
            }
        }


    }

    private void LoadLanguageFile(string filePath)
    {
        // Create a new dictionary to store the key-value pairs
        languageDictionary = new Dictionary<string, string>();

        TextAsset textAsset = Resources.Load<TextAsset>(filePath);
        if (textAsset != null)
        {
            string fileContent = textAsset.text;

            //// To draw the child's name saved previously
            childName = PlayerPrefs.GetString("ChildName");
            if (childName != null)
            {
                //// To update child's name in the story text file
                fileContent = fileContent.Replace("[replace name here]", childName);
            }
            else //// if no child's name saved, replace as "New Kiddo"
                fileContent = fileContent.Replace("[replace name here]", "New Kiddo");


            string[] lines = fileContent.Split('\n');

            foreach (string line in lines)
            {
                string[] keyValue = line.Split('='); // Split the line based on the delimiter

                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim();
                    string value = keyValue[1].Trim();
                    Debug.Log("key: " + key);
                    Debug.Log("value: " + value);

                    // Add the key-value pair to the dictionary
                    languageDictionary.Add(key, value);
                }
            }
        }
        else
            Debug.Log("cannot file the file");


        // // Read the text file
        // string[] lines = File.ReadAllLines(filePath);

        // // Parse each line and add the key-value pairs to the dictionary
        // foreach (string line in lines)
        // {
        //     string[] keyValue = line.Split('='); // Split the line based on the delimiter

        //     if (keyValue.Length == 2)
        //     {
        //         string key = keyValue[0].Trim();
        //         string value = keyValue[1].Trim();

        //         // Add the key-value pair to the dictionary
        //         languageDictionary.Add(key, value);
        //     }
        // }
    }

    public string GetLocalizedString(string key)
    {
        // Check if the key exists in the dictionary
        if (languageDictionary.ContainsKey(key))
        {
            // Return the localized string for the key
            return languageDictionary[key];
        }
        else
        {
            // Return an error message or a fallback string
            return "Localization not found for key: " + key;
        }
    }

    public void UpdateText()
    {
        String textUpdated = GetLocalizedString("greeting");
        Debug.Log("The text is: " + textUpdated);
        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas != null)
        {
            TextMeshProUGUI textMeshPro = canvas.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = languageSelected;
            }

        }
    }

    public void LanguageSelection()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        if (clickedButton != null)
        {
            Button button = clickedButton.GetComponent<Button>();

            if (button != null)
            {
                if (button.name == "ChineseButton")
                {
                    Debug.Log("Language update to Chinese");
                    PlayerPrefs.SetString("Language", "Chinese");
                    SSTools.ShowMessage("Language Updated To Chinese", SSTools.Position.bottom, SSTools.Time.oneSecond);
                }
                else if (button.name == "EnglishButton")
                {
                    Debug.Log("Language update to English");
                    PlayerPrefs.SetString("Language", "English");
                    SSTools.ShowMessage("Language Updated To English", SSTools.Position.bottom, SSTools.Time.oneSecond);
                }
                else if (button.name == "MelayuButton")
                {
                    Debug.Log("Language update to Melayu");
                    PlayerPrefs.SetString("Language", "Melayu");
                    SSTools.ShowMessage("Language Updated To Melayu", SSTools.Position.bottom, SSTools.Time.oneSecond);
                }
            }
        }
    }
}
