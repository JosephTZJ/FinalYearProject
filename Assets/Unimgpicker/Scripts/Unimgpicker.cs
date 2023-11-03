using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace Kakera
{
    public class Unimgpicker : MonoBehaviour
    {
        public delegate void ImageDelegate(string path);

        public delegate void ErrorDelegate(string message);

        public event ImageDelegate Completed;

        public event ErrorDelegate Failed;

        private IPicker picker =
#if UNITY_EDITOR
            new Picker_editor();
#elif UNITY_IOS
            new PickeriOS();
#elif UNITY_ANDROID
            new PickerAndroid();
#else
            new PickerUnsupported();
#endif

        // initialise wallRenderer to directly change the material in this script
        // [SerializeField] private MeshRenderer wallRenderer;

        [Obsolete("Resizing is deprecated. Use Show(title, outputFileName)")]
        public void Show(string title, string outputFileName, int maxSize)
        {
            Show(title, outputFileName);
            StartCoroutine(DownloadImage(picker.GetImgPath()));
        }

        IEnumerator DownloadImage(string url)
        {
            Debug.Log("url : " + url);
            // Download the image using UnityWebRequest
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("Failed to download image: " + www.error);
            }
            else
            {
                // Get the downloaded texture
                Texture2D texture = DownloadHandlerTexture.GetContent(www);

                // Save the texture to a file in your Unity project folder
                byte[] bytes = texture.EncodeToPNG();
                string savePath = Application.dataPath + "/Images/" + "classroomBackground.png"; // Specify the target file path within your Unity project folder
                File.WriteAllBytes(savePath, bytes);

                Debug.Log("Image downloaded and saved to: " + savePath);
                Debug.Log("texture here : " + texture);

                // success to change the material in one script
                // wallRenderer.material.mainTexture = texture;
                
                // Bring to the next scene (classroom)
                // ImgToBgScript imgToBgScriptInstance = new ImgToBgScript();
                // imgToBgScriptInstance.ReceiveImagePath(savePath);            }
                // imgToBgScriptInstance.ReceiveImagePath(savePath, texture);            }
            }
        }

        public void Show(string title, string outputFileName)
        {
            picker.Show(title, outputFileName);
        }

        private void OnComplete(string path)
        {
            var handler = Completed;
            if (handler != null)
            {
                handler(path);
            }
        }

        private void OnFailure(string message)
        {
            var handler = Failed;
            if (handler != null)
            {
                handler(message);
            }
        }
    }
}