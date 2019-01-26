using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public string horizontal, vertical, camera;
    public float speed,turnSpeed;
    public bool started { get; set; }

    private Rigidbody rb;
    private Vector3 movement;
    private float verticalPush;


	// Use this for initializations
	void Start () {
        rb = GetComponent<Rigidbody>();
        verticalPush = 2.4f;
	}
	
	// Update is called once per frame
	void Update () {

        if (!started) return;
        movement = new Vector3(
                (transform.forward.x *Input.GetAxis(vertical) + transform.right.x * Input.GetAxis(horizontal)),
                0,
                (transform.forward.z * Input.GetAxis(vertical) + transform.right.z * Input.GetAxis(horizontal)))
                * speed * Time.deltaTime;

        rb.velocity = movement;

        transform.Rotate(transform.up, Input.GetAxis(camera)* turnSpeed);
	}
}
