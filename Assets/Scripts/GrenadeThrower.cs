using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;

    public Transform grenadeSpawnLocation;      //***Why might we want to have a grenade spawn location that isn't on "this.transform.position"?   A:  Spawning it at a different location would allow the grenade to spawn out of a weapon position if we had a model, or if we wanted to throw it from one side because it's a throw from an arm or something.

    [SerializeField] private float grenadeExplosionRadius = 5f;
    [SerializeField] private float grenadeExplosionForce = 15f;     //What does this [SerializeField] tag do to the variable that comes after it?   A: The SerializeField tag is used to make the private variables accessible without making them a public VARIABLE

    [SerializeField] private float grenadeThrowPower = 25f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))     //Which button is this?   A: Left mouse button 
        {
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()     //***When does this function get called?   A: This function is getting called when the left mouse button is clicked. The function is to spawn the grenade and throw it, so it's the steps before your answer, unfortunately.
    {
        GameObject go = Instantiate(grenadePrefab, grenadeSpawnLocation.position, this.transform.rotation);      //***Please explain what this line does and what assigning it to "GameObject go" lets us do.   A: This line creates new GameObjects, which, in this case, is the grenadePrefab, during runtime. Basically allows you to shoot multiple grenades consecutively.  The second part of the answer for GameObject go is to keep reference to the object we spawn so we can access other things on it, like the Grenade script and the Rigidbody component.

        go.GetComponent<Grenade>().Initialize(grenadeExplosionForce, grenadeExplosionRadius);

        go.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * grenadeThrowPower);     //***What is the point of calling AddForce on the rigidbody of the spawned object?   A: This AddForce specifically is not for the explosion, but for throwing the grenade from the spawn position, so it travels instead of falling to the floor after spawning.

        //***Why might we want to add force in the direction of the camera's forward instead of the player's forward?   A: The player's forward is constant, but we want to make sure the grenade is thrown in the direction the player is looking. If we use the player's forward, it will always throw it in the same direction out in front of the player without any variation based on where the player is looking.

    }
