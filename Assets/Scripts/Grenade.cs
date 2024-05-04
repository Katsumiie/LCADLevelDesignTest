using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float explosionForce;           //***When exactly at runtime are these explosionForce and explosionRadius variables being set?   A: At the start 
    private float explosionRadius;          //Extra Credit: Why would we want to set these variables in this way at runtime? Hint: There may be multiple answers.   A: 

    public void Initialize(float eF, float radius)
    {
        explosionForce = eF;
        explosionRadius = radius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] objectsHit = Physics.OverlapSphere(this.transform.position, explosionRadius);    //What does this Physics.OverlapSphere function do, and what do the passed variables represent in the function?   A: The Physics.OverlapSphere returns an array of all colliders touching or inside of the sphere. The variables passed in the function represent where the sphere is being cast and how big it will be. 
        //What does the [] mean above in Collider[]?  Hint: Array (What does it being an array mean?)   A: This is a collection of colliders (helps define the shape of an object for physical collisions) that is being stored and accessed through a single variable 

        for (int i = 0; i < objectsHit.Length; i++)     //***How many times does this for loop go through?   A: Infinitely 
        {
            if (objectsHit[i].CompareTag("Destructible"))
            {
                Destroy(objectsHit[i].gameObject);      //What object is being destroyed here?   A: Destrutible Cube GameObject
            }
            else
            {
                if (objectsHit[i].attachedRigidbody != null)    //***Why would we need to check if this attachedRigidbody is null before the next line?   A: It sets a condition for when the grenade hits a GameObject that does not have reference to anything else (objects that aren't destructible) 
                {
                    objectsHit[i].attachedRigidbody.AddExplosionForce(explosionForce, objectsHit[i].transform.position, explosionRadius);    //***Which component does the "AddExplosionForce()" function run from? The AddExplosionForce is being called from the Rigidbody of the object that was hit by the grenade, not the grenade's rigidbody itself
                    //Extra Credit: There's an issue with the logic in this AddExplosionForce. It works, but doesn't work right... What is the issue, and how do you fix it?  Hint: The grenade is the thing exploding, right?   A: (Change the code to reflect your answer as well)
                }
            }
        }

        Destroy(this.gameObject);   //If you comment this out, what happens? Hint: Just comment it out and check it out lol   A: The grenade remains intact and does not disappear on impact 
    }
}
