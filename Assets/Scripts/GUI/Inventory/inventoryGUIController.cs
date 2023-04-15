using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryGUIController : MonoBehaviour
{
    

    [Header("Render Holders")]

    [Tooltip("Holds the renderer for the lantern (By default, just the lantern game object)")] public GameObject lanternRenderHolder;
    [Tooltip("Holds the renderer for the lantern backgroud")] public GameObject lanternBgRenderHolder;

    [Tooltip("Holds the renderer for the pickaxe (By default, just the pickaxe game object)")] public GameObject pickaxeRenderHolder;
    [Tooltip("Holds the renderer for the pickaxe backgroud")] public GameObject pickaxeBgRenderHolder;




    [Header("Script Holders")]

    [Tooltip("Holds the game object with the itemController.cs script")] public GameObject itemControlHolder;





   

    [HideInInspector] [Tooltip("The renderer of the lantern (Set in the start method)")]public SpriteRenderer lantern;
    [HideInInspector] [Tooltip("The renderer of the lantern's background (Set in the start method)")] public SpriteRenderer lanternBG;


  

    [HideInInspector] [Tooltip("The renderer of the Pickaxe (Set in the start method)")]public SpriteRenderer pickaxe;
    [HideInInspector] [Tooltip("The renderer of the Pickaxe's background (Set in the start method)")] public SpriteRenderer pickaxeBG;

    

    [Header("Lantern Sprites")]

    [Tooltip("The sprite for when the lantern is not in the inventory")] public Sprite inactiveLanternSprite;
    [Tooltip("The sprite for when the lantern is in the inventory")] public Sprite activeLanternSprite;

    [Header("Pickaxe Sprites")]
    
    [Tooltip("The sprite for when the pickaxe is not in the inventory")] public Sprite inactivePickaxeSprite;
    [Tooltip("The sprite for when the pickaxe is in the inventory")] public Sprite activePickaxeSprite;


   


    
    public Sprite deselectedBG;
    public Sprite selectedBG;    


   
    [Header("Inventory Game Objects")]

    [Tooltip("The whole inventory GUI")] public GameObject inventoryGameobject;
    





    
    itemController itemControl; // Reference to the itemController.cs script





    // Start is called before the first frame update
    void Start()
    {
        // inventoryGameobject.SetActive(false);
        itemControl = itemControlHolder.GetComponent<itemController>();
        lanternBG = lanternBgRenderHolder.GetComponent<SpriteRenderer>();
        lantern = lanternRenderHolder.GetComponent<SpriteRenderer>();
        pickaxeBG = pickaxeBgRenderHolder.GetComponent<SpriteRenderer>();
        pickaxe = pickaxeRenderHolder.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteChanger();
    }


    public void spriteChanger()
    {
        if(itemControl.hasLantern){

            lantern.sprite = activeLanternSprite;

        }

        else if(!itemControl.hasLantern){

            lantern.sprite = inactiveLanternSprite;

        }
        

        if(itemControl.currentlySelectedItem == "Lantern"){
            lanternBG.sprite = selectedBG;
        }

        else{
            lanternBG.sprite = deselectedBG;
        }

        // Pickaxe

        if(itemControl.hasPickaxe){

            pickaxe.sprite = activePickaxeSprite;

        }

        else if(!itemControl.hasPickaxe){

            pickaxe.sprite = inactivePickaxeSprite;

        }
        

        if(itemControl.currentlySelectedItem == "Pickaxe"){
            pickaxeBG.sprite = selectedBG;
        }

        else{
            pickaxeBG.sprite = deselectedBG;
        }


    }



}

