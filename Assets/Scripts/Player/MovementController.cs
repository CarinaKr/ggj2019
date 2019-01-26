using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public string horizontal, vertical, turn;
    public float speed,turnSpeed;

    private GameManager gameManager;
    private Rigidbody rb;
    private Vector3 movement;
    private float verticalPush;
    private Animator animator;


	// Use this for initializations
	void Start () {
        rb = GetComponent<Rigidbody>();
        gameManager = GameManager.self;
        verticalPush = 2.4f;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!gameManager.isRunning) return;
        movement = new Vector3(
                (transform.forward.x *Input.GetAxis(vertical) + transform.right.x * Input.GetAxis(horizontal)) * speed * Time.deltaTime,
                rb.velocity.y,
                (transform.forward.z * Input.GetAxis(vertical) + transform.right.z * Input.GetAxis(horizontal)) * speed * Time.deltaTime);

        rb.velocity = movement;

        if(rb.velocity.magnitude > 0.3f)
        {
            animator.SetBool("IsRunning", true);
        }else if(rb.velocity.magnitude < 0.3 && animator.GetBool("IsRunning") == true)
        {
            animator.SetBool("IsRunning", false);
            Debug.Log("disableRunning");
        }

        transform.Rotate(transform.up, Input.GetAxis(turn)* turnSpeed);
	}
}
