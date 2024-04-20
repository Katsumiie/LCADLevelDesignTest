using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float explosionForce;           //When exactly at runtime are these explosionForce and explosionRadius variables being set?   A: 
    private float explosionRadius;          //Extra Credit: Why would we want to set these variables in this way at runtime? Hint: There may be multiple answers.   A: 

    public void Initialize(float eF, float radius)
    {
        explosionForce = eF;
        explosionRadius = radius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] objectsHit = Physics.OverlapSphere(this.transform.position, explosionRadius);    //What does this Physics.OverlapSphere function do, and what do the passed variables represent in the function?   A: 
        //What does the [] mean above in Collider[]?  Hint: Array (What does it being an array mean?)   A: 

        for (int i = 0; i < objectsHit.Length; i++)     //How many times does this for loop go through?   A: 
        {
            if (objectsHit[i].CompareTag("Destructible"))
            {
                Destroy(objectsHit[i].gameObject);      //What object is being destroyed here?   A: 
            }
            else
            {
                if (objectsHit[i].attachedRigidbody != null)    //Why would we need to check if this attachedRigidbody is null before the next line?   A: 
                {
                    objectsHit[i].attachedRigidbody.AddExplosionForce(explosionForce, objectsHit[i].transform.position, explosionRadius);    //Which component does the "AddExplosionForce()" function run from?
                    //Extra Credit: There's an issue with the logic in this AddExplosionForce. It works, but doesn't work right... What is the issue, and how do you fix it?  Hint: The grenade is the thing exploding, right?   A: (Change the code to reflect your answer as well)
                }
            }
        }

        Destroy(this.gameObject);   //If you comment this out, what happens? Hint: Just comment it out and check it out lol   A:
    }
}
