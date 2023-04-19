using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class itemController : MonoBehaviour
{
    // Possible items are "Lantern", "Pickaxe", "Sword", "Steak", "Knife", 

    [Header("Inventory Things")]
    public string[] inventory = new string[5];


    [Header("Coords for items")]
    public string lanternCoords;
    public string pickaxeCoords;


    [Header("Item Bools")]

    public bool canGetLantern;
    public bool hasLantern;
    public bool canGetPickaxe;
    public bool hasPickaxe;

    [Header("Keycodes")]

    public KeyCode getKey = KeyCode.G;
    public KeyCode dropKey = KeyCode.X;
    public KeyCode inventoryKey = KeyCode.I;

    [Header("Inventory Selection")]

    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public KeyCode fourKey = KeyCode.Alpha4;

    public string currentlySelectedItem;


    bool isHotbar;
    

    [Header("Hotbar Size & position")]
    public Vector3 hotbarSize = new Vector3(0.5f, 0.5f, 1f);
    public Vector3 hotbarPosition = new Vector3(-1.17f, -5.51f, 1);


    [Header("Inventory Size & position")]
    public Vector3 regularSize = new Vector3(1f, 1f, 1f);
    public Vector3 intialPosition = new Vector3(-1.456403f, 1.035505f, 1);
    
    

    [HideInInspector] public bool hasJustGotLantern;
    [HideInInspector] public bool hasJustGotPickaxe;


    [Header("Script Holder")]

    public GameObject invControlHolder;
    public GameObject actionTextControlHolder;



    actionTextController actionTextControl;
    inventoryGUIController invControl;
    roomController roomControl;

    // Start is called before the first frame update
    void Start()
    {
        actionTextControl = actionTextControlHolder.GetComponent<actionTextController>();
        invControl = invControlHolder.GetComponent<inventoryGUIController>();
        roomControl = GetComponent<roomController>();
        lanternCoords = "1, 0";
        pickaxeCoords = "1, 3";
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if(inventory[0] == "Lantern" && Input.GetKeyDown(oneKey)){
            if(currentlySelectedItem == "Lantern"){
                currentlySelectedItem = "";
            }
            else{
                currentlySelectedItem = "Lantern";
            }
        }

        if(inventory[1] == "Pickaxe" && Input.GetKeyDown(twoKey)){
            if(currentlySelectedItem == "Pickaxe"){
                currentlySelectedItem = "";
            }
            else{
                currentlySelectedItem = "Pickaxe";
            }
        }

     

        if(Input.GetKeyDown(getKey)){
            if(lanternCoords ==  roomControl.formattedCoords && inventory[0] != "Lantern" && canGetLantern){
                Debug.Log("Have Lantern");
                inventory[0] = "Lantern";
                canGetLantern = false;
                hasLantern = true;
                actionTextControl.actionText.text = "You have just gotten the lantern";
            }

            if(pickaxeCoords ==  roomControl.formattedCoords && inventory[1] != "Pickaxe" && canGetPickaxe){
                Debug.Log("Have Pickaxe");
                inventory[1] = "Pickaxe";
                canGetPickaxe = false;
                hasPickaxe = true;
                actionTextControl.actionText.text = "You have just gotten the pickaxe";

                
                
            }
        }

        if(Input.GetKeyDown(dropKey)){
            if(inventory.Contains(currentlySelectedItem)){
                if(currentlySelectedItem == "Lantern"){
                    lanternCoords = roomControl.formattedCoords;
                    inventory[0] = "";
                    currentlySelectedItem = "";
                    canGetLantern = true;
                    hasLantern = false;
                    actionTextControl.actionText.text = "You have just dropped your lantern";
                }

                else if(currentlySelectedItem == "Pickaxe"){
                    pickaxeCoords = roomControl.formattedCoords;
                    inventory[1] = "";
                    currentlySelectedItem = "";
                    canGetPickaxe = true;
                    hasPickaxe = false;
                    actionTextControl.actionText.text = "You have just dropped your pickaxe";

                }

            }
        }

        if(Input.GetKeyDown(inventoryKey)){
            if(isHotbar){
                invControl.inventoryGameobject.transform.localScale = regularSize;
                invControl.inventoryGameobject.transform.position = intialPosition;
                isHotbar = false;
            }
                
            else{
                invControl.inventoryGameobject.transform.localScale = hotbarSize;
                invControl.inventoryGameobject.transform.position = hotbarPosition;
                isHotbar = true;
            }

            Debug.Log(string.Join(",", inventory));
        }
           

            
            
        }




   
}

