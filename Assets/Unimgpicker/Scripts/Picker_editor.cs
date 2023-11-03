#if UNITY_EDITOR_OSX || UNITY_EDITOR_WIN
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using System.IO;

namespace Kakera
{
    internal class Picker_editor : IPicker
    {
        public string path;
        public void Show(string title, string outputFileName)
        {
            path = EditorUtility.OpenFilePanel(title, "", "png");
            if (path.Length != 0)
            {
                string destination = Application.persistentDataPath + "/" + outputFileName;
                if (File.Exists(destination))
                    File.Delete(destination);
                File.Copy(path, destination);
                Debug.Log("PickerOSX:" + destination);
                Debug.Log("Display path testing1:" + path);
                var receiver = GameObject.Find("Unimgpicker");
                if (receiver != null)
                {
                    receiver.SendMessage("OnComplete", Application.persistentDataPath + "/" + outputFileName);
                }
            }
        }

        public string GetImgPath ()
        {
            Debug.Log("Display path testing2:" + path);
            return path;
        }
    }
}
#endif