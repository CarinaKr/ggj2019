using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    public int holdTime;
    public Transform[] dropOffPoints;
    
    private bool state;

    virtual public void HoldInteraction() { }
    virtual public void PickUp(GameObject player) { }
    virtual public void Drop(GameObject player) { }
}
