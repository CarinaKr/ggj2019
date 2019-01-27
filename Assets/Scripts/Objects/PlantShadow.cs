using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShadow : InteractableObject {

    public bool countPoints;

    private Vector3 frameBox;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        isMovable = true;
        StartCoroutine("AddPoints");
        frameBox = new Vector3(1,1.6f,1);
    }

    public override void PickUp(GameObject player)
    {
        base.PickUp(player);
    }

    public override void Drop(GameObject player)
    {
        base.Drop(player);
    }
    
    private IEnumerator AddPoints()
    {
        yield return new WaitForSeconds(10f);
        while (countPoints)
        {
            yield return new WaitForSeconds(1f);
            if (gameManager.isRunning)
            {
                bool inShadow = false;
                bool atWindow = false;

                Collider[] colliders = Physics.OverlapBox(transform.position, frameBox / 2);
                foreach(Collider col in colliders)
                {
                    if(col.tag=="Object")
                    {
                        InteractableObject currentColliderObject = col.gameObject.GetComponent<InteractableObject>();
                        if (currentColliderObject is Curtains)
                        {
                            atWindow = true;
                            if (!currentColliderObject.state)
                                inShadow = true;
                        }
                    }
                }

                if (inShadow && atWindow && currentPlayer==null)
                {
                    GameManager.self.princessManager.points = Mathf.Min(GameManager.self.princessManager.points + GameManager.self.pointsPrincessPlants, GameManager.self.princessManager.maxPoints);
                }

                if (!atWindow && currentPlayer == null)
                {
                    GameManager.self.coboltManager.points = Mathf.Min(GameManager.self.coboltManager.points + GameManager.self.pointsCoboltPlants, GameManager.self.coboltManager.maxPoints);
                }

            }
        }
    }

}
