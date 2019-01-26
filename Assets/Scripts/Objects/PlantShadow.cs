using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShadow : InteractableObject {


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        isMovable = true;
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
