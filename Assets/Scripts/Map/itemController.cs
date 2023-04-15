using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class itemController : MonoBehaviour
{
    // Possible items are "Lantern", "Sword", "Steak", "Knife"

    [Header("Inventory Things")]
    public string[] inventory = new string[4];


    [Header("Coords for items")]
    public string lanternCoords;


    [Header("Item Bools")]

    public bool canGetLantern;
    public bool hasLantern;

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






    public GameObject invControlHolder;
    inventoryGUIController invControl;
    roomController roomControl;

    // Start is called before the first frame update
    void Start()
    {
        invControl = invControlHolder.GetComponent<inventoryGUIController>();
        roomControl = GetComponent<roomController>();
        lanternCoords = "1, 0";
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

     

        if(Input.GetKeyDown(getKey)){
            if(lanternCoords ==  roomControl.formattedCoords && inventory[0] != "Lantern" && canGetLantern){
                Debug.Log("Have Lantern");
                inventory[0] = "Lantern";
                canGetLantern = false;
                hasLantern = true;
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
                }

            }
        }

        if(Input.GetKeyDown(inventoryKey)){

            if(invControl.inventoryGameobject.activeSelf){
                invControl.inventoryGameobject.SetActive(false);
            }

            else{
                invControl.inventoryGameobject.SetActive(true);
            }
           
            Debug.Log(string.Join(",", inventory));
            
            
        }




   
    }
}
