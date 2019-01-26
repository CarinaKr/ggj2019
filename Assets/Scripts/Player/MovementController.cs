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


	// Use this for initializations
	void Start () {
        rb = GetComponent<Rigidbody>();
        gameManager = GameManager.self;
        verticalPush = 2.4f;
	}
	
	// Update is called once per frame
	void Update () {

        if (!gameManager.isRunning) return;
        movement = new Vector3(
                (transform.forward.x *Input.GetAxis(vertical) + transform.right.x * Input.GetAxis(horizontal)) * speed * Time.deltaTime,
                rb.velocity.y,
                (transform.forward.z * Input.GetAxis(vertical) + transform.right.z * Input.GetAxis(horizontal)) * speed * Time.deltaTime);

        rb.velocity = movement;

        transform.Rotate(transform.up, Input.GetAxis(turn)* turnSpeed);
	}
}
