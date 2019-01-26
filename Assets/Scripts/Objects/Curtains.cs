using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtains : InteractableObject {

    public Color open, closed;

    private Material currentMaterial;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        isMovable = false;
        currentMaterial = GetComponent<Renderer>().material;
        currentMaterial.color = closed;
	}

    public override void HoldInteraction()
    {
        Debug.Log("draw or close curtains");
        state = !state;
        if (state)                          //state=true=open
            currentMaterial.color = open;
        else
            currentMaterial.color = closed;
    }

    
}
