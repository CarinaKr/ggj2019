using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : InteractableObject {

    
    private bool isAtWall;
    private bool coroutinePointsRunning;

    override protected void Start()
    {
        base.Start();
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
        currentPlayer = player;
        player.transform.position = transform.position;
        //player.GetComponent<CapsuleCollider>().enabled = false;
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        player.GetComponent<MeshRenderer>().enabled = false;
        transform.SetParent(player.transform);
    }

    public override void Drop(GameObject player)
    {
        base.Drop(player);
        //if(isAtWall)
        //{
        //    if(!coroutinePointsRunning)
        //        StartCoroutine("AddPoints");
        //}
    }

    private IEnumerator AddPoints()
    {
        yield return null;
    }
    

}
