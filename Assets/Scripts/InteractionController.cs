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
                    holdCounter[0].rectTransform.localPosition = new Vector3(0, 0,0);
                }
                else if (objects.Count == 2)
                {
                    holdCounter[0].rectTransform.localPosition = new Vector3(0 - holdCounter[0].rectTransform.sizeDelta.x / 2, 0,0);
                    holdCounter[1].rectTransform.localPosition = new Vector3(0 + holdCounter[0].rectTransform.sizeDelta.x / 2, 0,0);
                }
            }
            else
            {
                List<InteractableObject> obj = new List<InteractableObject>(holdTime.Keys);
                for (int i = 0; i < holdTime.Count; i++)
                {
                    holdTime[obj[i]] = holdTime[obj[i]] - Time.deltaTime;
                    Debug.Log("calculate fill amount: "+ holdTime[obj[i]] + " / " + (float)obj[i].holdTime);
                    holdCounter[i].fillAmount = holdTime[obj[i]]/ (float)obj[i].holdTime;
                    Debug.Log("fill amount: " + holdCounter[i].fillAmount);
                    if (holdTime[obj[i]] <= 0)
                    {
                        obj[i].HoldInteraction();
                        holdTime.Remove(obj[i]);
                    }
                }
            }
        }
        else if (Input.GetButtonUp(holdInteraction))
        {
            foreach(Image counter in holdCounter)
            {
                counter.enabled = false;
            }
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
                isObject = null;
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