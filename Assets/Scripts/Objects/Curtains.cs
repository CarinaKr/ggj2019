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
        animator = GetComponentInChildren<Animator>();
        StartCoroutine("ToggleCurtains", state);
	}

    public override void HoldInteraction()
    {
        Debug.Log("draw or close curtains");
        state = !state;
        //if (state)
        //{                      //state=true=open
        //    godRay.SetActive(false);
        //    animator.SetBool("CurtainOn", true);
        //}
        //else
        //{ 
        //    animator.SetBool("CurtainOn", false);
        //    godRay.SetActive(true);
        //}
        StartCoroutine("ToggleCurtains",state);
    }

    private IEnumerator ToggleCurtains(bool open)
    {
        if(open)
        {
            animator.SetBool("CurtainOn", !open);
            yield return new WaitForSeconds(0.5f);
            GetComponent<AudioSource>().Play();
            godRay.SetActive(open);
        }
        else
        {
            animator.SetBool("CurtainOn", !open);
            yield return new WaitForSeconds(0.5f);
            GetComponent<AudioSource>().Play();
            godRay.SetActive(open);
        }
        
    }
}
