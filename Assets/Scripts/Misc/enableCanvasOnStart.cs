using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableCanvasOnStart : MonoBehaviour
{
   
   public GameObject canvasToDisable;

    void Awake() {
        canvasToDisable.SetActive(true);
    }
   
}
