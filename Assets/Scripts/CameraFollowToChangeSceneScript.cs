using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CameraFollowToChangeSceneScript : MonoBehaviour
{
    public Camera mCamera;
    public Transform target; 
    [SerializeField] private Button btn = null;
    public float speed = 0.01f;


    private void Awake()
    {
        btn.onClick.AddListener(NoParameterOnClick);
    }

    private void NoParameterOnClick()
    {
        Debug.Log("button clicked");
        // mCamera.fieldOfView -= 50; 
        // mCamera.position = Vector3.Lerp()
        // Vector3 targetPos = target.position;
        // Debug.Log("targetPos: "+ targetPos);
        // Vector3 mCameraPos = Vector3.Lerp(transform.position, targetPos, speed);
        // Debug.Log("mCameraPos: "+ mCameraPos);
        // transform.position = mCameraPos; 
        // transform.LookAt(target);
        SceneManager.LoadScene("ClassroomScene");
    }

   
}
