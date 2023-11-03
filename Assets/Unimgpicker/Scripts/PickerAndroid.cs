#if UNITY_ANDROID
using UnityEngine;

namespace Kakera
{
    internal class PickerAndroid : IPicker
    {
        private static readonly string PickerClass = "com.kakeragames.unimgpicker.Picker";

        public void Show(string title, string outputFileName)
        {
            using (var picker = new AndroidJavaClass(PickerClass))
            {
                picker.CallStatic("show", title, outputFileName);
            }
        }

        public string GetImgPath()
        {
            string imgPath = "";
        
            using (var picker = new AndroidJavaClass(PickerClass))
            {
                picker.CallStatic("getimgpath");
                // Set the value of imgPath based on the result from the picker
                // For example, you can assign the result to imgPath if it's a valid string
                // imgPath = ...
            }
            
            // Return the value of imgPath or a default value if it's not set
            return imgPath;
        }
    }
}
#endif