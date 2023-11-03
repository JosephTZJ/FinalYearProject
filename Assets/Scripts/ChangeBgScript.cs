using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
namespace Kakera
{
public class ChangeBgScript : MonoBehaviour
{
    public Slider red;
    public Slider green;
    public Slider blue;
    // public string message = "The background colour is updated.";
    // public ToastManagerScript toastManager;
    // public static Color chosenColor;
    // [SerializeField] private Unimgpicker imagePicker;
    [SerializeField] private MeshRenderer imageRenderer;

        void Awake()
        {
            // To retrieve the color saved and set to the slider
            float r = PlayerPrefs.GetFloat("ColorR");
            float g = PlayerPrefs.GetFloat("ColorG");
            float b = PlayerPrefs.GetFloat("ColorB");
            if(r!=null && g!=null && b!=null){
                red.value = r;
                blue.value = b;
                green.value=g;
            }
            if(r==null && g==null && b==null){
                red.value = 1;
                blue.value = 1;
                green.value=1;
            }
        }

        void Update()
        {
            // color picker 2 from youtuber reactive developemnt
            // Debug.Log("Color value red: " + red.value+" ,green: "+green.value+" ,blue: "+blue.value);
            imageRenderer.material.color = new Color(red.value, green.value, blue.value);
        }

        public void UpdateBgColor()
        {
            Debug.Log("Color value red: " + red.value+" ,green: "+green.value+" ,blue: "+blue.value);
            // chosenColor = new Color(red.value, green.value, blue.value);
            PlayerPrefs.SetFloat("ColorR", red.value);
            PlayerPrefs.SetFloat("ColorG", green.value);
            PlayerPrefs.SetFloat("ColorB", blue.value);
            PlayerPrefs.Save();
            SSTools.ShowMessage("Colour Updated", SSTools.Position.bottom, SSTools.Time.twoSecond);
            // toastManager.ShowToast(message);
        }

}
}
