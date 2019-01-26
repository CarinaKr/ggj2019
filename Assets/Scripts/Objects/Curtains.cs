using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtains : InteractableObject {

    

	// Use this for initialization
	void Start () {
	}

    public override void HoldInteraction()
    {
        Debug.Log("draw or close curtains");
    }

    
}
