using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryTriggerScript : MonoBehaviour
{
    public GameObject popupPrefab;
    public string message;
    private GameObject popupObject;

    public void ShowPopup() {
        popupObject = Instantiate(popupPrefab);
        popupObject.transform.SetParent(gameObject.transform, false);
        popupObject.GetComponentInChildren<Text>().text = message;
        Debug.Log("inside popup");
    }

    public void HidePopup() 
    {
        // Destroy the popup GameObject
        if (popupObject != null) 
        {
            Destroy(popupObject);
        }
    }
}
