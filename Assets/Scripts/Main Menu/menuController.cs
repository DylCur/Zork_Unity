using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuController : MonoBehaviour
{
    
    public int currentScreen = 1;
    public GameObject[] screen1Objects;
    public GameObject[] screen2Objects;

    


    public void Start() {

        screen1Objects = GameObject.FindGameObjectsWithTag("Screen1");
        screen2Objects = GameObject.FindGameObjectsWithTag("Screen2");

        foreach (GameObject j in screen2Objects){
            j.SetActive(false); // Disable screen 2
        }
    }   


    public void switchScreen(int screenToSwitch)
    {

        Debug.Log("Started");

        if(currentScreen == 1){

            Debug.Log("Current screen is 1");

            if(screenToSwitch == 2){

                    currentScreen = 2;
                    Debug.Log("Screen to switch = 2");


                    foreach (GameObject i in screen1Objects){
                        i.SetActive(false); // Disable screen 1
                    }

                    foreach (GameObject j in screen2Objects){
                        j.SetActive(true); // Enable screen 2
                    }
                }
           
           
        }

        if(currentScreen == 2){
            if(screenToSwitch == 1){

                currentScreen = 1;
                foreach (GameObject i in screen1Objects){
                        i.SetActive(true); // Enable Screen 1
                    }

                    foreach (GameObject j in screen2Objects){
                        j.SetActive(false); // Disables Screen 1
                    }
            }
        }
           

        if(screenToSwitch == 0){
            SceneManager.LoadScene(1);
        }
    }




}
