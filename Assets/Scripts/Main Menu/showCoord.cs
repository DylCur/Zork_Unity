using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class showCoord : MonoBehaviour
{

    Toggle toggle;
    public GameObject toggleHolder;
    public bool shouldIt;
    public GameObject dontDestroyObject;
    public GameObject roomControlHolder;
    public GameObject textManageHolder;


    roomController roomControl;
    textManager textManage;


    // Start is called before the first frame update
    void Start()
    {

        toggle = toggleHolder.GetComponent<Toggle>();

        if(SceneManager.GetSceneByBuildIndex(1).isLoaded){
            textManageHolder = GameObject.Find("TextUIManager");
            textManage = textManageHolder.GetComponent<textManager>();
            roomControlHolder = GameObject.Find("CoordinateManager");
            roomControl = roomControlHolder.GetComponent<roomController>();

        }
        DontDestroyOnLoad(dontDestroyObject);
    }

    // Update is called once per frame
    void Update()
    {

      

        if(SceneManager.GetSceneByBuildIndex(0).isLoaded){

            if(toggle.isOn){
                shouldIt = true;
            }

            else{
                shouldIt = false;
            }
        }

        // if(SceneManager.GetSceneByName("Game").isLoaded)
        // {
        //     Destroy(dontDestroyObject);
        // }

        if(SceneManager.GetSceneByName("Game").isLoaded){
            textManageHolder = GameObject.Find("TextUIManager");
            textManage = textManageHolder.GetComponent<textManager>();
            roomControlHolder = GameObject.Find("CoordinateManager");
            roomControl = roomControlHolder.GetComponent<roomController>();

        }

        if(SceneManager.GetSceneByBuildIndex(1).isLoaded){
            if(shouldIt){
                textManage.currentRoomText.text = $"Your current coordinates are {roomControl.formattedCoords}";
                Debug.Log("Hi!");
            }
            else{
                textManage.currentRoomText.text = "";
            }
        }   

    }

    
    public void ShouldLoad(bool shouldIt){

        if(toggle.isOn){
            shouldIt = true;
        }

        else{
            shouldIt = false;
        }

        Debug.Log(shouldIt);

            

        

    }


    public void ShouldQuit(bool canQuit){
        if(canQuit){
            Application.Quit();
            Debug.Log("Quit attempted");
        }

        else{
            Debug.Log("Quitting is not permitted");
        }
    }
    
}
