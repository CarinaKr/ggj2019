using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : InteractableObject {

    public bool countPoints;
    public Transform frankBed;
    public float minDistance;

    private bool nextToFrank;

    override protected void Start()
    {
        base.Start();
        StartCoroutine("AddPoints");
        isMovable = true;
    }

    public override void PickUp(GameObject player)
    {
        base.PickUp(player);
    }

    public override void Drop(GameObject player)
    {
        base.Drop(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==frankBed)
        {
            nextToFrank = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == frankBed)
        {
            nextToFrank = false;
        }
    }

    private IEnumerator AddPoints()
    {
        while (countPoints)
        {
            yield return new WaitForSeconds(1f);
            if (gameManager.isRunning && currentPlayer==null)
            {
                nextToFrank = Vector3.Distance(transform.position, frankBed.position) < minDistance ? true : false;
                if (nextToFrank)
                {
                    GameManager.self.frankManager.points = Mathf.Min(GameManager.self.frankManager.points + GameManager.self.pointsFrankBed, GameManager.self.frankManager.maxPoints);
                }
                else if (!nextToFrank)
                {
                    GameManager.self.vampireManager.points = Mathf.Min(GameManager.self.vampireManager.points + GameManager.self.pointsVampBed, GameManager.self.vampireManager.maxPoints);
                }
                
            }
        }
    }
}
