using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textManager : MonoBehaviour
{

    [Header("Text Game Objects")]

    public TextMeshProUGUI currentRoomText;

    [Header("TMP Holders")]

    public GameObject roomTextHolder;


    [Header("Script Holders")]

    public GameObject roomControlHolder;

    roomController roomControl;


    // Start is called before the first frame update
    void Start()
    {
        roomControl = roomControlHolder.GetComponent<roomController>();
        currentRoomText = roomTextHolder.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentRoomText.text = $"Current room: {roomControl.currentRoom}";
    }
}
