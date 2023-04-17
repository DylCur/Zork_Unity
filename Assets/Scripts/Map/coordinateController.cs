using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coordinateController : MonoBehaviour
{
       
    [Header("Keycodes")]

    [SerializeField] KeyCode northKey = KeyCode.W;
    [SerializeField] KeyCode southKey = KeyCode.S;
    [SerializeField] KeyCode eastKey = KeyCode.D;
    [SerializeField] KeyCode westKey = KeyCode.A;

    [Header("Coordinate Bools")]

    [Tooltip("Checks if the player can move north")] public bool canNorth;
    [Tooltip("Checks if the player can move south")] public bool canSouth;
    [Tooltip("Checks if the player can move east")] public bool canEast;
    [Tooltip("Checks if the player can move west")] public bool canWest;

    [Header("Coordinates")]

    [Tooltip("Stores the players X position")] public int xPos;
    [Tooltip("Stores the players Y position")] public int yPos;

    [Header("Script Holders")]

    public GameObject actionTextControlHolder;


    
    actionTextController actionTextControl;
    roomController roomControl;
    itemController itemControl;
    boulderDestroy boulderBreak;

    


    


    // Start is called before the first frame update
    void Start()
    {
        
        actionTextControl = actionTextControlHolder.GetComponent<actionTextController>();
        roomControl = GetComponent<roomController>();
        itemControl = GetComponent<itemController>();
        boulderBreak = GetComponent<boulderDestroy>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
        
        if(Input.GetKeyDown(northKey) && canNorth){
           
            Debug.Log($"X position : {xPos} || Y position : {yPos} || Current Room = {roomControl.currentRoom}");
            canMoveCheck(true, false, false, false, $"{xPos}, {yPos + 1}");
            


        }

        else if(Input.GetKeyDown(southKey) && canSouth){
           
            Debug.Log($"X position : {xPos} || Y position : {yPos} || Current Room = {roomControl.currentRoom}");
            canMoveCheck(false, true, false, false, $"{xPos}, {yPos - 1}");
            



        }

        else if(Input.GetKeyDown(eastKey) && canEast){
           
            Debug.Log($"X position : {xPos} || Y position : {yPos} || Current Room = {roomControl.currentRoom}");
            canMoveCheck(false, false, true, false, $"{xPos + 1}, {yPos}");
           


            
        }

        else if(Input.GetKeyDown(westKey) && canWest){
           
            Debug.Log($"X position : {xPos} || Y position : {yPos} || Current Room = {roomControl.currentRoom}");
            canMoveCheck(false, false, false, true, $"{xPos - 1}, {yPos}");
            



        }
    }


    public void LateUpdate() {
        
        
        
    }


    public void canMoveCheck(bool isYP, bool isYN, bool isXP, bool isXN, string coordsIfMove){ // Parsed bools to check what the previous change in coordinate was e.g. isYP checks to see if the previous movement was positive on the y

        Debug.Log(coordsIfMove);

        if(roomControl.roomFeatures.ContainsKey(coordsIfMove)){



            if(isYP){
                
                yPos += 1;
                

            }

            else if(isYN){
                yPos -= 1;
                
            }

            else if(isXP){
                if(roomControl.formattedCoords == "2, 0" && !boulderBreak.boulderHasBeenBroken){
                    Debug.Log("You havent destroyed the boulder yet!");
                }
                
                else{
                    xPos += 1;
                    
    
                }
            }

            else if(isXN){
                xPos -= 1;
                


                
            }

            
            roomControl.formattedCoords = $"{xPos}, {yPos}";
            roomControl.currentRoom = roomControl.roomFeatures[roomControl.formattedCoords];
            actionTextControl.updateActionText(roomControl.currentRoom);
            
            
            
        }

        else{
           Debug.Log("You cannot do that!");
        }
    }


}
