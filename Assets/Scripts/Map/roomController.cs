using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class roomController : MonoBehaviour
{



    

    [Header("Room Settings")]

    [Tooltip("The features of the room")] public Dictionary<string, string> roomFeatures = new Dictionary<string, string>()
    {
        {"0, 0", "Empty field"}, // 0
        {"1, 0", "Entrance to a cave"}, // 1
        {"1, 1", "Side of a house"}, // 2
        {"1, 2", "Slightly ajar window"}, // 3
        {"0, 2", "Living room"}, // 4
        {"1, 3", "Strange tree stump"}, // 5
        {"2, 0", "Path blocked by a boulder"}, // 6
        {"3, 0", "Vast cavern with tunnels going in almost every direction"}, // 7
        {"3, 1", "Locked trapdoor"}, // 8
        {"3, -1", "Town"}, // 9
        {"4, 0", "Cave wall (Theres seemingly no way forewards)"}, // 10
        {"0, 1", "Front door of a house"}, // 11
        {"-1, 0", "Forest"}, // 12
        

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
