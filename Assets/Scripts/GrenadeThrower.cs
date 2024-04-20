using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;

    public Transform grenadeSpawnLocation;      //Why might we want to have a grenade spawn location that isn't on "this.transform.position"?   A: 

    [SerializeField] private float grenadeExplosionRadius = 5f;
    [SerializeField] private float grenadeExplosionForce = 15f;     //What does this [SerializeField] tag do to the variable that comes after it?   A: 

    [SerializeField] private float grenadeThrowPower = 25f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))     //Which button is this?   A: 
        {
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()     //When does this function get called?   A: 
    {
        GameObject go = Instantiate(grenadePrefab, grenadeSpawnLocation.position, this.transform.rotation);      //Please explain what this line does and what assigning it to "GameObject go" lets us do.   A: 

        go.GetComponent<Grenade>().Initialize(grenadeExplosionForce, grenadeExplosionRadius);

        go.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * grenadeThrowPower);     //What is the point of calling AddForce on the rigidbody of the spawned object?   A: 
        //Why might we want to add force in the direction of the camera's forward instead of the player's forward?   A: 
    }
}
