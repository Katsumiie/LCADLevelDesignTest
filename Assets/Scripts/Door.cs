using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    private bool canPlayerOpenDoor = true;      //Look at this line for a hint to a question in the KeyManager script!

    [SerializeField] private float doorOpenTime = 2f;

    public bool CanOpenDoor()
    {
        return canPlayerOpenDoor;
    }

    public void OpenDoor()
    {
        canPlayerOpenDoor = false;                                                  //****Why do we have to set this variable to false? A: This variable is set to false after the player opens the door so that the player cannot open a door that is already open.
        this.transform.DOMoveY(this.transform.position.y + 4f, doorOpenTime);       //What is this line doing?   A: This line allows the door to translate upward by 4 units on the y axis over a duration based on the doorOpenTime. 
    }
}
