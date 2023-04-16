using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class roomController : MonoBehaviour
{



    

    [Header("Room Settings")]

    [Tooltip("The features of the room")] public Dictionary<string, string> roomFeatures = new Dictionary<string, string>()
    {
        {"0, 0", "Starting room"}, // 0
        {"1, 0", "Entrance to cave"}, // 1
        {"1, 1", "Side of the house"}, // 2
        {"1, 2", "Slightly ajar window"}, // 3
        {"1, 3", "Living Room"}, // 4
        {"2, 0", "Boulder"}, // 5
        {"3, 0", "Thing in cave"}, // 6
        {"0, 1", "Door to house"}, // 7
        {"-1, 0", "Forest"}, // 8
        

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
