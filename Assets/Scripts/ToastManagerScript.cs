using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ToastManagerScript : MonoBehaviour
{
    private const string permission = "android.permission.WRITE_EXTERNAL_STORAGE";

    public void ShowToast(string message)
    {
        AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", GetUnityActivity(), message, 0);
        toastObject.Call("show");
    }

    public void RequestPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(permission))
        {
            Permission.RequestUserPermission(permission);
        }
    }

    private AndroidJavaObject GetUnityActivity()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    }
}
