using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControlScript : MonoBehaviour
{
    public GameObject mainPanel, tablePanel, chairPanel;
    [SerializeField] private Button tableBtn = null;
    [SerializeField] private Button chairBtn = null; 
    // Start is called before the first frame update
    void Start()
    {
        tablePanel.gameObject.SetActive(false);
        chairPanel.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);

        tableBtn.onClick.AddListener(() => { 
            mainPanel.gameObject.SetActive(false);
            tablePanel.gameObject.SetActive(true);

        });

        chairBtn.onClick.AddListener(() => { 
            mainPanel.gameObject.SetActive(false);
            chairPanel.gameObject.SetActive(true);

        });
    }

    public void BackToMainPanel()
    {
        tablePanel.gameObject.SetActive(false);
        chairPanel.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
    }
}
