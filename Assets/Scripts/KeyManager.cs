using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private int numKeys = 0;    //What does this variable represent?

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;     //What is this variable used for?   A: 

            if(Physics.Raycast(this.transform.position, transform.forward, out hit, 5f))     //Please describe how this raycast is working by describing the variables being passed to it.   A: 
            {
                if (hit.collider.CompareTag("Door"))
                {
                    Door door = hit.collider.GetComponent<Door>();

                    if(numKeys > 0 && door.CanOpenDoor())   //Why can't we just look for the door's "canPlayerOpenDoor" variable directly instead of using the function?   A: 
                    {
                        door.OpenDoor();    //What are ALL the conditions that have to be met in order for this door to be opened? Hint: There are 5.   A: 
                        numKeys--;          //What is the purpose of this line?   A: 
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)     //When is OnTriggerEnter called?   A: 
    {
        if(other.CompareTag("Key"))
        {
            numKeys++;                      //What is the purpose of this line?   A: 
            Destroy(other.gameObject);      //What object is being destroyed and why do we have to destroy it?   A: 
        }
    }
}
