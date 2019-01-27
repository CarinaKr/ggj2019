using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    
    public int holdTime;
    public Transform[] dropOffPoints;
    

    //public bool countPoints;
    public bool state { get; set; }
    public bool isMovable;

    protected GameManager gameManager;
    protected GameObject currentPlayer;

    protected virtual void Start()
    {
        gameManager = GameManager.self;
        //StartCoroutine("AddPoints");
    }

    virtual public void HoldInteraction() { }
    virtual public void PickUp(GameObject player)
    {
        if (currentPlayer != null) return;
        currentPlayer = player;
        player.transform.position = transform.position;
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        player.transform.GetChild(0).gameObject.SetActive(false);
        transform.SetParent(player.transform);
    }
    virtual public void Drop(GameObject player)
    {
        foreach (Transform dropOff in dropOffPoints)
        {
            Collider[] collider = Physics.OverlapBox(dropOff.position, new Vector3(player.transform.lossyScale.x / 2, player.transform.lossyScale.y / 2, player.transform.lossyScale.z / 2), transform.rotation, 0, QueryTriggerInteraction.Ignore);
            if (collider.Length == 0)
            {
                transform.SetParent(null);
                player.transform.position = dropOff.position;
                player.transform.GetChild(0).gameObject.SetActive(true);
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
                currentPlayer = null;
                return;
            }
        }
        Debug.Log("no free drop off space found");
    }


    //private void OnDrawGizmosSelected()
    //{
    //    if (currentPlayer == null) return;
    //    foreach (Transform dropOff in dropOffPoints)
    //    {
    //        Gizmos.DrawWireCube(dropOff.position, new Vector3(currentPlayer.transform.lossyScale.x / 2, currentPlayer.transform.lossyScale.y / 2, currentPlayer.transform.lossyScale.z / 2));
    //    }
    //}
}
