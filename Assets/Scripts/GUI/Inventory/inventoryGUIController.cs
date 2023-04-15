using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryGUIController : MonoBehaviour
{
    

    [Header("Holders")]

    [Tooltip("Holds the game object with the itemController.cs script")] public GameObject itemControlHolder;
    [Tooltip("Holds the renderer for the lantern (By default, just the lantern game object)")]public GameObject lanternRenderHolder;



    [Header("Lantern Settings")]


    [Tooltip("The renderer of the lantern (Set in the start method)")]public SpriteRenderer lantern;
    [Tooltip("The sprite for when the lantern is not in the inventory")] public Sprite inactiveLanternSprite;
    [Tooltip("The sprite for when the lantern is in the inventory")] public Sprite activeLanternSprite;

    
    itemController itemControl; // Reference to the itemController.cs script





    // Start is called before the first frame update
    void Start()
    {
        itemControl = itemControlHolder.GetComponent<itemController>();
        lantern = lanternRenderHolder.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void spriteChanger()
    {
        if(itemControl.hasLantern){

            lantern.sprite = activeLanternSprite;

        }

        else if(!itemControl.hasLantern){

            lantern.sprite = inactiveLanternSprite;

        }
    }



}

