using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderDestroy : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip boulderBreakSFX;
    public AudioClip windowOpenSfx;
    private AudioSource audioSource;
    public GameObject audioSourceHolder;
    


    [Header("Script Holders")]

    public GameObject actionTextControlHolder;


    [Header("Keycodes")]

    public KeyCode breakKey = KeyCode.B;

    public bool boulderHasBeenBroken;
    public bool windowHasBeenOpened;

    coordinateController coordsControl;
    roomController roomControl;
    itemController itemControl;
    actionTextController actionControl;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioSourceHolder.GetComponent<AudioSource>();
        actionControl = actionTextControlHolder.GetComponent<actionTextController>();
        itemControl = GetComponent<itemController>();
        roomControl = GetComponent<roomController>();
        coordsControl = GetComponent<coordinateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(breakKey)){       

            if(roomControl.formattedCoords == "2, 0" && itemControl.currentlySelectedItem == "Pickaxe" && !boulderHasBeenBroken){
                boulderHasBeenBroken = true;
                roomControl.roomFeatures["2, 0"] = "Boulder Shards";
                audioSource.PlayOneShot(boulderBreakSFX);
                actionControl.updateActionText("Boulder Broken");
            }
          
            if(roomControl.formattedCoords == "1, 2"  && !windowHasBeenOpened){
                if(itemControl.currentlySelectedItem == "Pickaxe"){
                    windowHasBeenOpened = true;
                    roomControl.roomFeatures["1, 2"] = "Open window";
                    audioSource.PlayOneShot(windowOpenSfx);
                    actionControl.updateActionText("Open Window");
                }

                else{
                    actionControl.updateActionText("Fail Open Window");
                }
            }
            
        }
        
    }
}
