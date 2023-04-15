using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryGUIController : MonoBehaviour
{
    

    [Header("Render Holders")]

    [Tooltip("Holds the renderer for the lantern (By default, just the lantern game object)")] public GameObject lanternRenderHolder;
    [Tooltip("Holds the renderer for the lantern backgroud")] public GameObject lanternBgRenderHolder;



    [Header("Script Holders")]

    [Tooltip("Holds the game object with the itemController.cs script")] public GameObject itemControlHolder;





    [Header("Lantern Sprite Renderers")]

    [Tooltip("The renderer of the lantern (Set in the start method)")]public SpriteRenderer lantern;
    [Tooltip("The renderer of the lantern's background (Set in the start method)")] public SpriteRenderer lanternBG;

    [Header("Lantern Sprites")]

    [Tooltip("The sprite for when the lantern is not in the inventory")] public Sprite inactiveLanternSprite;
    [Tooltip("The sprite for when the lantern is in the inventory")] public Sprite activeLanternSprite;


    [Header("Lantern Background Sprites")]

    public Sprite deselectedLanternBG;
    public Sprite selectedLanternBG;    


    [Header("Inventory Game Objects")]

    [Tooltip("The whole inventory GUI")] public GameObject inventoryGameobject;





    
    itemController itemControl; // Reference to the itemController.cs script





    // Start is called before the first frame update
    void Start()
    {
        inventoryGameobject.SetActive(false);
        itemControl = itemControlHolder.GetComponent<itemController>();
        lanternBG = lanternBgRenderHolder.GetComponent<SpriteRenderer>();
        lantern = lanternRenderHolder.GetComponent<SpriteRenderer>();
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
            lanternBG.sprite = selectedLanternBG;
        }

        else{
            lanternBG.sprite = deselectedLanternBG;
        }

    }



}

