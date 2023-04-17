using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class actionTextController : MonoBehaviour
{

    [Header("Text Game Objects")]

    public TextMeshProUGUI actionText;

    [Header("TMP Holders")]

    public GameObject actionTextHolder;

    [Header("Script Holders")]

    public GameObject roomControlHolder;
    public GameObject itemControlHolder;
    public GameObject coordinateControlHolder;

    roomController roomControl;
    itemController itemControl;
    coordinateController coordinateControl;


    string eventStr;

    // Start is called before the first frame update
    void Start()
    {

        coordinateControl = coordinateControlHolder.GetComponent<coordinateController>();
        itemControl = itemControlHolder.GetComponent<itemController>();
        roomControl = roomControlHolder.GetComponent<roomController>();

        roomControl.formattedCoords = $"{coordinateControl.xPos}, {coordinateControl.yPos}";
        roomControl.currentRoom = roomControl.roomFeatures[roomControl.formattedCoords];

        actionText.text = $"You have started in the {roomControl.currentRoom}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateActionText(string variableToInput)
    {

        
        if(itemControl.hasJustGotLantern){
            
            itemControl.hasJustGotLantern = false;
        }

        else if(itemControl.hasJustGotPickaxe){
            actionText.text = "You have just picked up a Pickaxe";
            itemControl.hasJustGotPickaxe = false;
        }
        

           

        if(variableToInput == roomControl.currentRoom){

            char firstLetterOfRoomName = roomControl.currentRoom[0];
            string strOfFirstLetter =   firstLetterOfRoomName.ToString().ToLower();

            if(strOfFirstLetter == "a" || strOfFirstLetter == "e" || strOfFirstLetter == "i" || strOfFirstLetter == "o" || strOfFirstLetter == "u")
            {
                eventStr =  $"You have moved into an {variableToInput}";
            }

            else{
                eventStr = $"You have moved into a {variableToInput}"; // Gramma checking

            }

            if(roomControl.formattedCoords == itemControl.lanternCoords || roomControl.formattedCoords == itemControl.pickaxeCoords)
            {
                if(roomControl.formattedCoords == itemControl.lanternCoords && roomControl.formattedCoords != itemControl.pickaxeCoords){
                    actionText.text = $"{eventStr}. There is a lantern on the floor!";
                }

                else if(roomControl.formattedCoords == itemControl.pickaxeCoords && roomControl.formattedCoords != itemControl.lanternCoords){
                    actionText.text = $"{eventStr}. There is a pickaxe on the floor!";
                }

                else if(roomControl.formattedCoords == itemControl.lanternCoords && roomControl.formattedCoords == itemControl.pickaxeCoords){
                    actionText.text = $"{eventStr}. There is a lantern and a pickaxe on the floor!";
                }
            }

            else{
                actionText.text = eventStr;
            }

        }
    
        if(variableToInput == "Boulder Broken"){
            actionText.text = "You hit the bolder. Mysteriously, it bursts into tiny sand sized shards";
        }
    
    }
}
