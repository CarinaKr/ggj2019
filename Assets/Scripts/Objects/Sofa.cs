using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : InteractableObject {

    private GameObject currentPlayer;

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
        foreach(Transform dropOff in dropOffPoints)
        {
            Collider[] collider = Physics.OverlapBox(dropOff.position, new Vector3(player.transform.lossyScale.x / 2, player.transform.lossyScale.y / 2, player.transform.lossyScale.z / 2),transform.rotation,0,QueryTriggerInteraction.Ignore);
            if(collider.Length==0)
            {
                transform.SetParent(null);
                player.transform.position = dropOff.position;
                player.GetComponent<MeshRenderer>().enabled = true;
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(),false);
                return;
            }
        }
        Debug.Log("no free drop off space found");
    }

    private void OnDrawGizmosSelected()
    {
        if (currentPlayer == null) return;
        foreach (Transform dropOff in dropOffPoints)
        {
            Gizmos.DrawWireCube(dropOff.position, new Vector3(currentPlayer.transform.lossyScale.x / 2, currentPlayer.transform.lossyScale.y / 2, currentPlayer.transform.lossyScale.z / 2));
        }
    }
}
