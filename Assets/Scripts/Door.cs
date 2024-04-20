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
        canPlayerOpenDoor = false;                                                  //Why do we have to set this variable to false?
        this.transform.DOMoveY(this.transform.position.y + 4f, doorOpenTime);       //What is this line doing?   A: 
    }
}
