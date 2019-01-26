using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : InteractableObject {

    public override void PickUp(GameObject player)
    {
        player.transform.position = transform.position;
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<MeshRenderer>().enabled = false;
        transform.SetParent(player.transform);
    }
}
