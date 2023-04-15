using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class roomController : MonoBehaviour
{



    

    [Header("Room Settings")]

    [Tooltip("The features of the room")] public Dictionary<string, string> roomFeatures = new Dictionary<string, string>()
    {
        {"0, 0", "Starting room"},
        {"1, 0", "Entrance to cave"},
        {"0, 1", "Door to house"}

    };




    
    
    [HideInInspector] public string potentialCurrentRoom;
    public string currentRoom;
    public string formattedCoords;


    coordinateController coordsController;

    // Start is called before the first frame update
    void Start()
    {
        coordsController = GetComponent<coordinateController>();

        
    }

    // Update is called once per frame
    void Update()
    {   
        formattedCoords = $"{coordsController.xPos}, {coordsController.yPos}";
        
        if(roomFeatures.TryGetValue(formattedCoords, out potentialCurrentRoom)){
            currentRoom = potentialCurrentRoom;
        }
    }
}
