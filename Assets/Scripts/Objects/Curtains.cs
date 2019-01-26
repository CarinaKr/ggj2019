using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtains : InteractableObject {

    public Color open, closed;
    public GameObject godRay;

    private Material currentMaterial;
    private Animator animator;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        isMovable = false;
        animator = GetComponent<Animator>();
        //currentMaterial = GetComponent<Renderer>().material;
        //currentMaterial.color = closed;
	}

    public override void HoldInteraction()
    {
        Debug.Log("draw or close curtains");
        state = !state;
        if (state)
        {                      //state=true=open
            godRay.SetActive(false);
            animator.SetBool("CurtainOn", true);
        }
        else
        { 
            animator.SetBool("CurtainOn", false);
            godRay.SetActive(true);
        }
    }

    
}
