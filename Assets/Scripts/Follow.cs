using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform followObject;
    private Vector3 offsetPosition,offsetRotation;

	// Use this for initialization
	void Start () {
        offsetPosition = transform.position - followObject.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = followObject.position + offsetPosition;
	}
}
