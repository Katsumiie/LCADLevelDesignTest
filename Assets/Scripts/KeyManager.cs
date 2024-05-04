using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private int numKeys = 0;    //***What does this variable represent? A: This variable represents an interger (whole number) 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;     //***What is this variable used for?   A: This variable specifies a raycast hitting an object in the scene. 

            if(Physics.Raycast(this.transform.position, transform.forward, out hit, 5f))     //Please describe how this raycast is working by describing the variables being passed to it.   A: This line tells the raycast to project forward from its current position 5 units.  
            {
                if (hit.collider.CompareTag("Door"))
                {
                    Door door = hit.collider.GetComponent<Door>();

                    if(numKeys > 0 && door.CanOpenDoor())   //***Why can't we just look for the door's "canPlayerOpenDoor" variable directly instead of using the function?   A: Because the canPlayerOpenDoor variable is in another script that cannot be called because it is using a private function. 
                    {
                        door.OpenDoor();    //***What are ALL the conditions that have to be met in order for this door to be opened? Hint: There are 5.   A: 1. Player presses key E. 2. Player has at least one key in their "inventory." 3. Player has to be within 5 units in front of the door for the raycast to open it 4. Door has to be closed before the player interacts with it. 5. The object hit by the raycast has to be a door 
                        numKeys--;          //What is the purpose of this line?   A: Decrements by 1 
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)     //When is OnTriggerEnter called?   A: OnTriggerEnter is called when a GameObject collides with another GameObject, or when Collider Other enters the trigger. 
    {
        if(other.CompareTag("Key"))
        {
            numKeys++;                      //What is the purpose of this line?   A: Increments by 1 
            Destroy(other.gameObject);      //***What object is being destroyed and why do we have to destroy it?   A: The key is being destroyed because once you use it with the door, it has to disappear and CANNOT BE USED AGAIN 
        }
    }
}
