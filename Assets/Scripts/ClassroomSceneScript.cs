using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kakera;

public class ClassroomSceneScript : MonoBehaviour
{
    int sceneIndex;
    Color chosenColor;
    public GameObject plane; //used to calculate the classroom width -> to display the student's table in the middle of the class
    [SerializeField] private MeshRenderer wall1, wall2, wall3;

    void Start()
    {
        //// ---- To set the classroom background color and corridor background color ---- ////
        sceneIndex = SceneManager.GetActiveScene ().buildIndex;
        float r = PlayerPrefs.GetFloat("ColorR");
        float g = PlayerPrefs.GetFloat("ColorG");
        float b = PlayerPrefs.GetFloat("ColorB");
        if(r==null && g==null && b==null){
            r=1;
            g=1;
            b=1;
        }
        chosenColor = new Color(r, g, b);
        wall1.material.color = chosenColor;
        wall2.material.color = chosenColor;
        wall3.material.color = chosenColor;

        //// ---- To set the table chair in the classroom ---- ////
        Scene currentScene = SceneManager.GetActiveScene();
        string[] targetScenes = {
            "ClassroomScene", "Story2_1ClassroomScene",
            "Story2_2ClassroomScene"
        };

        if (System.Array.Exists(targetScenes, scene => scene == currentScene.name))
        {
            LoadObjects();
        }
    }

    private void LoadObjects()
    {
        int objectsInstantiated = PlayerPrefs.GetInt("ObjectsInstantiated", 0);
        int teacherTableInstantiated = PlayerPrefs.GetInt("TeacherTableInstantiated", 0);
        if (objectsInstantiated == 1)
        {
            String myAssetFile = PlayerPrefs.GetString("myAssetFile");
            int valueRow = PlayerPrefs.GetInt("valueRow");
            int valueColumn = PlayerPrefs.GetInt("valueColumn");
            Debug.Log("find the update in objectsInstantiated and the file name for the asset is "+ myAssetFile);
            GameObject assetFind = Resources.Load<GameObject>(myAssetFile);
            Debug.Log("find the child of the asset is "+ assetFind.gameObject);
            GameObject studentMale = Resources.Load<GameObject>("Student/studentSit");
            // studentMale.transform.Rotate(90.0f, 0.0f, 0.0f);
            // GameObject studentFemale = Resources.Load<GameObject>("Table/desk1");
            if (assetFind != null)
            {
                Debug.Log("assetFind is not null");
                int rowCounter = 0, columnCounter = 0;
                float spacing = 1.5f, zPosForRow = -4;
                float xOffset = plane.transform.position.x;
                float yOffset = plane.transform.position.y;
                float zOffset = plane.transform.position.z;

                if(valueColumn==0)
                    valueColumn=1;
                if(valueRow==0)
                    valueRow=1;

                for (int j= 0; j<5; j++)
                {
                    if(rowCounter<valueRow){
                        //// center column tables
                        GameObject myObj = Instantiate(assetFind, new Vector3(plane.transform.position.x, yOffset, zPosForRow), Quaternion.identity);
                        Vector3 newScale = myObj.transform.localScale; //enlarge the table size 
                        myObj.transform.localScale = newScale; //assign to the game obj

                        //// center column student
                        Quaternion stuRotation = Quaternion.identity;
                        stuRotation.eulerAngles = new Vector3(0, 0, 0);
                        float zPosForStu = zPosForRow + 0.35f;
                        float yPosForStu = yOffset + 0.2f;
                        GameObject myStu = Instantiate(studentMale, new Vector3(xOffset, yPosForStu, zPosForStu), stuRotation);
                        Vector3 newScaleStu = myStu.transform.localScale; //enlarge the student size 
                        Vector3 scaleChange = new Vector3(-0.65f, -0.65f, -0.65f);
                        myStu.transform.localScale += scaleChange;                        
                        ++columnCounter;

                        if(valueColumn>1){
                            for (int i = 1; i <= 3; i++)
                            {
                                //// Instantiate left hand side tables and students
                                if(columnCounter<valueColumn){
                                    float xPos = xOffset + (i * spacing);
                                    Vector3 position = new Vector3(xPos, yOffset, zPosForRow);
                                    Vector3 positionForStuLeft = new Vector3(xPos, yPosForStu, zPosForStu);
                                    myObj.transform.localScale = newScale;
                                    Instantiate(myObj, position, Quaternion.identity);
                                    Instantiate(myStu, positionForStuLeft, stuRotation);
                                    ++columnCounter;
                                }
                                //// Instantiate right hand side tables and students
                                if(columnCounter<valueColumn){
                                    float xPos = xOffset - (i * spacing);
                                    Vector3 position = new Vector3(xPos, yOffset, zPosForRow);
                                    Vector3 positionForStuRight = new Vector3(xPos, yPosForStu, zPosForStu);
                                    myObj.transform.localScale = newScale;
                                    Instantiate(myObj, position, Quaternion.identity);
                                    Instantiate(myStu, positionForStuRight, stuRotation);
                                    ++columnCounter;
                                }
                            }
                        }
                        zPosForRow=zPosForRow+2;
                        columnCounter=0;
                        ++rowCounter;
                    }
                }
            }
        }
        if (teacherTableInstantiated == 1)
        {
            String teacherTableFile = PlayerPrefs.GetString("teacherTableFile");
            GameObject assetFind = Resources.Load<GameObject>(teacherTableFile);
            // Debug.Log("find the update in objectsInstantiated and the file name for the asset is "+ assetFind);
            if (teacherTableFile != null)
            {
                GameObject myObj = Instantiate(assetFind);
                Vector3 newScale = myObj.transform.localScale*1.5f; // adjust object's scale
                myObj.transform.localScale = newScale;
                Vector3 newPosition = new Vector3(5, 2.2f, -8); // adjust object's position
                myObj.transform.position = newPosition;
                myObj.transform.Rotate(0f, 90f, 0f); // rotate the table in 90degree
            }
        }
    }

}
