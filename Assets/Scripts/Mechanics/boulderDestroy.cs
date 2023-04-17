using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderDestroy : MonoBehaviour
{

    [Header("Script Holders")]

    public GameObject actionTextControlHolder;


    [Header("Keycodes")]

    public KeyCode breakKey = KeyCode.B;

    public bool boulderHasBeenBroken;

    coordinateController coordsControl;
    roomController roomControl;
    itemController itemControl;
    actionTextController actionControl;
    
    // Start is called before the first frame update
    void Start()
    {
        actionControl = actionTextControlHolder.GetComponent<actionTextController>();
        itemControl = GetComponent<itemController>();
        roomControl = GetComponent<roomController>();
        coordsControl = GetComponent<coordinateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(breakKey) && roomControl.formattedCoords == "2, 0" && itemControl.currentlySelectedItem == "Pickaxe" && !boulderHasBeenBroken){       
          
            boulderHasBeenBroken = true;
            roomControl.roomFeatures["2, 0"] = "Boulder Shards";
            actionControl.updateActionText("Boulder Broken");
            
        }
    }
}
