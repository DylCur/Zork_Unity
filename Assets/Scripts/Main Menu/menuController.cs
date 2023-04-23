using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuController : MonoBehaviour
{
    
    public Animator OneTwoAnimator;
    public GameObject OneTwoAnimatorHolder;

    public Animator twoOneAnimator;
    public GameObject twoOneAnimatorHolder;

    public int currentScreen = 1;
    public GameObject[] screen1Objects;
    public GameObject[] screen2Objects;

    


    public void Start() {

        
        OneTwoAnimator = OneTwoAnimatorHolder.GetComponent<Animator>();
        OneTwoAnimatorHolder.GetComponent<Animator>().enabled = false;
        twoOneAnimator = twoOneAnimatorHolder.GetComponent<Animator>();
        twoOneAnimatorHolder.GetComponent<Animator>().enabled = false;


        screen1Objects = GameObject.FindGameObjectsWithTag("Screen1");
        screen2Objects = GameObject.FindGameObjectsWithTag("Screen2");

        
    }   


    public void switchScreen(int screenToSwitch)
    {

        Debug.Log("Started");

        if(currentScreen == 1){

            Debug.Log("Current screen is 1");

            if(screenToSwitch == 2){
                    
                    screenToSwitch = 3;


                    Vector3 screen1Position = new Vector3(1227.213f, 280.4594f, -32.2679f);

                    OneTwoAnimatorHolder.GetComponent<Animator>().enabled = true;
                    twoOneAnimatorHolder.GetComponent<Animator>().enabled = true;

                    OneTwoAnimator.Play("screen1To2");
                    twoOneAnimator.Play("screen2To1");



                    currentScreen = 2;
                    Debug.Log("Animation attempted");

                    if(OneTwoAnimatorHolder.transform.position == screen1Position){
                        OneTwoAnimatorHolder.GetComponent<Animator>().enabled = false;
                        twoOneAnimatorHolder.GetComponent<Animator>().enabled = false;
                    }

            

                    

                    
                }
           
           
        }

        if(currentScreen == 2){
            if(screenToSwitch == 1){


                screenToSwitch = 3;
                Vector3 screen1Position = new Vector3(-262.2869f, 280.4594f, -32.2679f);


                OneTwoAnimatorHolder.GetComponent<Animator>().enabled = true;
                twoOneAnimatorHolder.GetComponent<Animator>().enabled = true;
                currentScreen = 1;

                OneTwoAnimator.Play("screen1To2_Return");
                twoOneAnimator.Play("screen2To1_Return");


                

                
                if(OneTwoAnimatorHolder.transform.position == screen1Position){
                    OneTwoAnimatorHolder.GetComponent<Animator>().enabled = false;
                    twoOneAnimatorHolder.GetComponent<Animator>().enabled = false;
                }


                

            }
        }
           

        if(screenToSwitch == 0){
            SceneManager.LoadScene(1);
        }
    }




}
