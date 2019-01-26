using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : InteractableObject {

    
    private bool isAtWall;
    private bool coroutinePointsRunning;

    override protected void Start()
    {
        base.Start();
        isMovable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Footer")
        {
            isAtWall = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Footer")
        {
            isAtWall = false;
        }
    }

    public override void PickUp(GameObject player)
    {
        base.PickUp(player);
    }

    public override void Drop(GameObject player)
    {
        base.Drop(player);
    }
    

}
