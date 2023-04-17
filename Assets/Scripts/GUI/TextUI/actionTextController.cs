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
            actionText.text = "You have just picked up a Lantern";
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
                actionText.text = $"You have moved into an {variableToInput}";
            }

            else{
                actionText.text = $"You have moved into a {variableToInput}"; // Gramma checking

            }

        }
    }
}
