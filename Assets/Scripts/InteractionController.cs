using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour {
    
    public string holdInteraction="Hold0";
    public string pickUp="PickUp0";
    public Image[] holdCounter;

    private Dictionary<InteractableObject, float> holdTime;
    private bool isHolding;
    private InteractableObject isObject;
    private Rigidbody rb;
    private List<InteractableObject> objects;


	// Use this for initialization
	void Start () {
        objects = new List<InteractableObject>();
        rb = GetComponent<Rigidbody>();
        holdTime = new Dictionary<InteractableObject, float>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton(holdInteraction))
        {
            if (!isHolding)
            {
                isHolding = true;
                for (int i = 0; i < objects.Count; i++)
                {
                    holdTime.Add(objects[i], objects[i].holdTime);
                    holdCounter[i].enabled = true;
                }
                if (objects.Count == 1)
                {
                    //holdCounter[0].rectTransform.position = new Vector2(0, 0);
                }
                else if (objects.Count == 2)
                {
                    holdCounter[0].rectTransform.position = new Vector2(0 - holdCounter[0].minWidth / 2, 0);
                    holdCounter[1].rectTransform.position = new Vector2(0 + holdCounter[0].minWidth / 2, 0);
                }
            }
            else
            {
                List<InteractableObject> obj = new List<InteractableObject>(holdTime.Keys);
                for (int i = 0; i < obj.Count; i++)
                {
                    holdTime[obj[i]] = holdTime[obj[i]] - Time.deltaTime;
                    holdCounter[i].fillAmount = obj[i].holdTime / holdTime[obj[i]];
                    if (holdTime[obj[i]] <= 0)
                    {
                        obj[i].HoldInteraction();
                    }
                }
            }
        }
        else if (Input.GetButtonUp(holdInteraction))
        {
            isHolding = false;
            holdTime.Clear();
        }
        else if (Input.GetButtonDown(pickUp))
        {
            if (!isObject)
            {
                foreach (InteractableObject obj in objects)
                {
                    obj.PickUp(gameObject);
                    isObject = obj;
                }
            }
            else
            {
                isObject.Drop(gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Object")
        {
            objects.Add(other.GetComponent<InteractableObject>());
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Object")
        {
            InteractableObject currentObject = other.GetComponent<InteractableObject>();
            if (objects.Contains(currentObject))
            {
                objects.Remove(currentObject);
            }
            if(holdTime.ContainsKey(currentObject))
            {
                holdTime.Remove(currentObject);
            }
        }
    }
}