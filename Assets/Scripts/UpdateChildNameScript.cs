using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class UpdateChildNameScript : MonoBehaviour
{
    public TMP_InputField childName_field;
    public string childName = "";
    void Start()
    {
        childName_field.characterLimit = 20;
    }

    public void saveChildNameButtonClicked()
    {
        Debug.Log("save button is clicked");
        childName = childName_field.text;
        if (string.IsNullOrEmpty(childName_field.text)==false)
        {
            Debug.Log("childname is: " + childName);
            PlayerPrefs.SetString("ChildName", childName);
            SSTools.ShowMessage("Child's Name Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);

        }
        else
            PlayerPrefs.SetString("ChildName", "New Kid");

    }

    public void clearButtonClicked()
    {
        Debug.Log("clear button is clicked");
        childName_field.text = "";

    }
}
