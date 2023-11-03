using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyObjectScript : MonoBehaviour
{
    public int valueRow; // Store the Row key in by user
    public int valueColumn; // Store the Column key in by user
    public GameObject assetFind; // To find the asset (table) selected by user
    public GameObject assetContainer; // To place all assets into a parent container

    public GameObject plane; //used to calculate the classroom width -> to display the student's table in the middle of the class

    public Transform panel1; // TablePanel to show the buttons
    public Transform panel2; // TablePanel to show the buttons
    public Button buttonPrefab1; // Button sample for student table
    public Button buttonPrefab2; // Button sample for teacher table
    public Sprite[] buttonSprites = new Sprite[6]; // Array of sprites for each button
    public Sprite[] buttonSprites2 = new Sprite[3]; // Array of sprites for each button


    // Start is called before the first frame update
    void Start()
    {
        // Load sprites (table) dynamically at runtime
        for (int i = 0; i < buttonSprites.Length; i++)
        {
            string spritePath = "Sprites/desk" + (i + 1); // Assuming sprite files are named desk1, desk2, etc.
            Debug.Log("spritePath is " + spritePath);
            buttonSprites[i] = Resources.Load<Sprite>(spritePath);
            if (Resources.Load<Sprite>(spritePath))
            {
                Debug.Log("hello from resource sprite num " + i);
                Debug.Log("Assigning image for buttonSprites " + i);
            }

        }

        // Load sprites (teacher table) dynamically at runtime
        for (int i = 0; i < buttonSprites2.Length; i++)
        {
            string spritePath = "Sprites2/desk" + (i + 1); // Assuming sprite files are named desk1, desk2, etc.
            Debug.Log("spritePath is " + spritePath);
            buttonSprites2[i] = Resources.Load<Sprite>(spritePath);
            if (Resources.Load<Sprite>(spritePath))
            {
                Debug.Log("hello from resource sprite2 num " + i);
                Debug.Log("Assigning image for buttonSprites2 " + i);
            }

        }

        CreateImageButtons(); // Generate Table Image Button
        CreateTeacherTableButtons(); // Generate Teacher Table Image Button
        if (!PlayerPrefs.HasKey("ObjectsInstantiated"))
        {
            PlayerPrefs.SetInt("ObjectsInstantiated", 1);
        }
        else
        {
            int valueRow = PlayerPrefs.GetInt("valueRow");
            int valueColumn = PlayerPrefs.GetInt("valueColumn");
            if (valueColumn != 0 && valueRow != 0)
            {
                // Instantiate objects if they haven't been created yet
                assetFind = Resources.Load<GameObject>("Table/desk1");
                if (assetFind != null)
                { //if the desk if found
                    LoopToDisplay(assetFind);
                }
            }
        }
    }

    void CreateImageButtons()
    {
        for (int i = 1; i <= 6; i++)
        {
            // Instantiate a button from the prefab
            Button button = Instantiate(buttonPrefab1, panel1);

            // Set the button's name
            button.name = "Button " + i;
            button.transform.SetParent(panel1, false);

            // Set the button's image sprite
            Image buttonImage = button.GetComponent<Image>();
            //SpriteRenderer buttonImage = button.GetComponent<SpriteRenderer>();
            if (buttonImage != null && i - 1 < buttonSprites.Length)
            {
                Debug.Log("Creating image for button " + i);
                buttonImage.sprite = buttonSprites[i - 1];
            }

            //////// To set the position for each imageButton in the TablePanel ////////
            if (i > 1)
            {
                // Set the button's position in the container
                Vector3 buttonPosition = button.transform.localPosition;
                if (i >= 4)
                    buttonPosition.y -= 120;// Adjust the vertical position based on the index

                if (i == 2 || i == 5)
                    buttonPosition.x += 120; // Adjust the horizontal position based on the index
                else if (i == 3 || i == 6)
                    buttonPosition.x += 240; // Adjust the horizontal position based on the index

                button.transform.localPosition = buttonPosition;
            }

            // Add a listener to the button's onClick event
            int index = i; // Capture the current index in a local variable to avoid closure issues
            button.onClick.AddListener(() => ButtonClicked(index));
        }
    }

    void CreateTeacherTableButtons()
    {
        for (int i = 1; i <= 3; i++)
        {
            // Instantiate a button from the prefab
            Button button = Instantiate(buttonPrefab2, panel2);

            // Set the button's name
            button.name = "Button " + i;
            button.transform.SetParent(panel2, false);

            // Set the button's image sprite
            Image buttonImage2 = button.GetComponent<Image>();
            //SpriteRenderer buttonImage = button.GetComponent<SpriteRenderer>();
            if (buttonImage2 != null && i - 1 < buttonSprites2.Length)
            {
                Debug.Log("Creating image for button " + i);
                buttonImage2.sprite = buttonSprites2[i - 1];
            }

            //////// To set the position for each imageButton in the TablePanel ////////
            if (i > 1)
            {
                // Set the button's position in the container
                Vector3 buttonPosition = button.transform.localPosition;
                if (i == 2)
                    buttonPosition.x += 120; // Adjust the horizontal position based on the index
                else if (i == 3)
                    buttonPosition.x += 240; // Adjust the horizontal position based on the index

                button.transform.localPosition = buttonPosition;
            }

            // Add a listener to the button's onClick event
            int index = i; // Capture the current index in a local variable to avoid closure issues
            button.onClick.AddListener(() => DisplayTeacherTable(index));
        }
    }

    private void ButtonClicked(int buttonIndex)
    {

        ////// ------------------------ METHOD 2 START HERE ------------------------ //////
        String assetFileName = "Table/desk" + buttonIndex;
        Debug.Log("assetFilename: " + assetFileName);
        assetFind = Resources.Load<GameObject>(assetFileName);
        PlayerPrefs.SetString("myAssetFile", assetFileName);
        if (assetFind != null)
        {
            SSTools.ShowMessage("Table Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);

            LoopToDisplay(assetFind);
        }
        else
            Debug.Log("student table asset not found");

        ////// ------------------------ METHOD 2 END HERE ------------------------ //////

        // ////// ------------------------ METHOD 1 START HERE ------------------------ ////// 
        // Debug.Log("Button " + buttonIndex + " clicked!");

        // // Perform different actions based on the button index
        // switch (buttonIndex)
        // {
        //     case 1:
        //         GameObject assetFind = Resources.Load<GameObject>("Table/desk1");
        //         PlayerPrefs.SetString("myAssetFile", "Table/desk1");
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         if (Resources.Load<GameObject>("Table/desk1")) { //if the desk if found
        //             SSTools.ShowMessage("Table Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);
        //             LoopToDisplay(assetFind);

        //         } else {
        //             Debug.Log("not found");
        //         }
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         break;
        //     case 2:
        //         assetFind = Resources.Load<GameObject>("Table/desk2");
        //         PlayerPrefs.SetString("myAssetFile", "Table/desk2");
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         if (Resources.Load<GameObject>("Table/desk2")) { //if the desk if found
        //             SSTools.ShowMessage("Table Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);
        //             LoopToDisplay(assetFind);

        //         } else {
        //             Debug.Log("not found");
        //         }
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         break;
        //     case 3:
        //         assetFind = Resources.Load<GameObject>("Table/desk3");
        //         PlayerPrefs.SetString("myAssetFile", "Table/desk3");
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         if (Resources.Load<GameObject>("Table/desk3")) { //if the desk if found
        //             SSTools.ShowMessage("Table Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);
        //             LoopToDisplay(assetFind);

        //         } else {
        //             Debug.Log("not found");
        //         }
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         break;
        //     case 4:
        //         assetFind = Resources.Load<GameObject>("Table/desk4");
        //         PlayerPrefs.SetString("myAssetFile", "Table/desk4");
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         if (Resources.Load<GameObject>("Table/desk4")) { //if the desk if found
        //             SSTools.ShowMessage("Table Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);
        //             LoopToDisplay(assetFind);

        //         } else {
        //             Debug.Log("not found");
        //         }
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         break;
        //     case 5:
        //         assetFind = Resources.Load<GameObject>("Table/desk5");
        //         PlayerPrefs.SetString("myAssetFile", "Table/desk5");
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         if (Resources.Load<GameObject>("Table/desk5")) { //if the desk if found
        //             SSTools.ShowMessage("Table Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);
        //             LoopToDisplay(assetFind);

        //         } else {
        //             Debug.Log("not found");
        //         }
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         break;
        //     case 6:
        //         assetFind = Resources.Load<GameObject>("Table/desk6");
        //         PlayerPrefs.SetString("myAssetFile", "Table/desk6");
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         if (Resources.Load<GameObject>("Table/desk6")) { //if the desk if found
        //             SSTools.ShowMessage("Table Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);
        //             LoopToDisplay(assetFind);

        //         } else {
        //             Debug.Log("not found");
        //         }
        //         ////// ---------------- Display table in GRID form ---------------- ////// 
        //         break;
        // }
        // ////// ------------------------ METHOD 1 END HERE ------------------------ //////
    }

    public void LoopToDisplay(GameObject assetFind)
    { // maximum 7 columns, 5 rows
        int rowCounter = 0, columnCounter = 0;
        float spacing = 2f, zPosForRow = -6;
        float xOffset = plane.transform.position.x;
        float yOffset = plane.transform.position.y;
        float zOffset = plane.transform.position.z;

        if (valueColumn == 0)
            valueColumn = 2;
        if (valueRow == 0)
            valueRow = 1;

        for (int j = 0; j < 5; j++) // loop to have maximum 5 rows
        {
            if (rowCounter < valueRow)
            {
                //// center column tables
                GameObject myObj = Instantiate(assetFind, new Vector3(plane.transform.position.x, yOffset, zPosForRow), Quaternion.identity);
                // Debug.Log("myObj1 at row "+j+" and column "+columnCounter);
                // myObj.transform.parent = assetContainer.transform;
                // myObj.name = "centerTable"+rowCounter;
                Vector3 newScale = myObj.transform.localScale * 3f; //enlarge the table size 
                myObj.transform.localScale = newScale; //assign to the game obj
                ++columnCounter; // center table counted as 1 column

                if (valueColumn > 1)
                {
                    for (int i = 1; i <= 3; i++) // loop to have maximum 3 table at left and 3 table at right
                    {
                        if (columnCounter < valueColumn) //// Instantiate left hand side tables
                        {
                            float xPos = xOffset + (i * spacing * 2f);
                            Vector3 position = new Vector3(xPos, yOffset, zPosForRow);
                            myObj.transform.localScale = newScale;
                            Instantiate(myObj, position, Quaternion.identity);
                            // /myObj.transform.parent = assetContainer.transform;
                            // myObj.name = "leftSideTable" + i;
                            // Debug.Log("myObj2 at row "+j+" and column "+columnCounter);
                            ++columnCounter; // another column counted
                        }
                        if (columnCounter < valueColumn) //// Instantiate right hand side tables
                        {
                            float xPos = xOffset - (i * spacing * 2f);
                            Vector3 position = new Vector3(xPos, yOffset, zPosForRow);
                            myObj.transform.localScale = newScale;
                            Instantiate(myObj, position, Quaternion.identity);
                            // myObj.transform.parent = assetContainer.transform;
                            // myObj.name = "rightSideTable" + i;
                            // Debug.Log("myObj3 at row "+j+" and column "+columnCounter);
                            ++columnCounter; // another column counted
                        }
                    }
                }
                myObj.transform.parent = assetContainer.transform;
                myObj.name = "testing"+rowCounter;
                zPosForRow = zPosForRow + 4; // process for one row finish, update the row position for next row
                columnCounter = 0; // process for one row finish, reset the columnCounter for another row
                ++rowCounter; // process for one row finish, go for another row
            }
        }


        //// use loop, loop to put the asset according to the valueRow and valueColumn
        // int spaceBetweenColumn = 10;
        // for(int i=0; i<valueColumn; i++){
        //     int spaceBetweenRow = -6;
        //     for(int j=0; j<valueRow; j++){
        //         // to instantiate table in row
        //         GameObject myObj = Instantiate(assetFind);
        //         Vector3 newScale = myObj.transform.localScale * 3f; // adjust object's scale
        //         myObj.transform.localScale = newScale;
        //         Vector3 newPosition = new Vector3((i+spaceBetweenColumn), 0, (j+spaceBetweenRow)); // adjust object's position
        //         myObj.transform.position = newPosition;
        //         spaceBetweenRow= spaceBetweenRow+3;
        //     }
        //     spaceBetweenColumn= spaceBetweenColumn-5;
        // }
    }

    public void DisplayTeacherTable(int index)
    {
        SSTools.ShowMessage("Table Updated", SSTools.Position.bottom, SSTools.Time.oneSecond);
        String assetFileName = "TeacherTable/" + index;
        Debug.Log("assetFilename: " + assetFileName);
        PlayerPrefs.SetString("teacherTableFile", assetFileName);
        GameObject assetFind = Resources.Load<GameObject>(assetFileName);
        // to instantiate teacher's table
        if (assetFind != null)
        {
            GameObject myObj = Instantiate(assetFind);
            Vector3 newScale = myObj.transform.localScale * 3f; // adjust object's scale
            myObj.transform.localScale = newScale;
            Vector3 newPosition = new Vector3(8, 0, -12); // adjust object's position
            myObj.transform.position = newPosition;
            myObj.transform.Rotate(0f, 90f, 0f); // rotate the table in 90degree
        }
        else
            Debug.Log("teacher table asset not found");

        PlayerPrefs.SetInt("TeacherTableInstantiated", 1);
    }

    public void DropdownValueUpdateRow(int index)
    {
        if (index != 0)
        {
            valueRow = index;
            PlayerPrefs.SetInt("valueRow", valueRow);
            Debug.Log("Row: " + valueRow);
        }
    }
    public void DropdownValueUpdateColumn(int index)
    {
        if (index != 0)
        {
            valueColumn = index + 1;
            PlayerPrefs.SetInt("valueColumn", valueColumn);
            Debug.Log("Column: " + valueColumn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject gameObject = Instantiate(assetFind);
        // Destroy(gameObject); 
        // Debug.Log("Destroy game object: "+ gameObject);
    }
}
