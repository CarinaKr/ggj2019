using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanket : InteractableObject {

    public bool inOrder = false;
    public bool countPoints;

    public GameObject unorderlyBlanket;
    public GameObject orderlyBlanket;

    protected override void Start()
    {
        base.Start();
        isMovable = false;
        StartCoroutine("AddPoints");
        if (state)
        {
            inOrder = true;
            orderlyBlanket.SetActive(true);
            unorderlyBlanket.SetActive(false);
        }
        else
        {
            inOrder = false;
            orderlyBlanket.SetActive(false);
            unorderlyBlanket.SetActive(true);
        }
    }

    public override void HoldInteraction()
    {
        state = !state;
        if (state)
        {
            inOrder = true;
            orderlyBlanket.SetActive(true);
            unorderlyBlanket.SetActive(false);
        }
        else
        {
            inOrder = false;
            orderlyBlanket.SetActive(false);
            unorderlyBlanket.SetActive(true);
        }
    }

    private IEnumerator AddPoints()
    {
        while (countPoints)
        {
            yield return new WaitForSeconds(1f);
            if (gameManager.isRunning)
            {
                if (inOrder)
                {
                    GameManager.self.princessManager.points = Mathf.Min(GameManager.self.princessManager.points + GameManager.self.pointsBlanketOrderly, GameManager.self.princessManager.maxPoints);
                    GameManager.self.frankManager.points = Mathf.Min(GameManager.self.frankManager.points + GameManager.self.pointsBlanketOrderly, GameManager.self.frankManager.maxPoints);
                }
                else if (!inOrder)
                {
                    GameManager.self.coboltManager.points = Mathf.Min(GameManager.self.coboltManager.points + GameManager.self.pointsBlanketUnorderly, GameManager.self.coboltManager.maxPoints);
                    GameManager.self.vampireManager.points = Mathf.Min(GameManager.self.vampireManager.points + GameManager.self.pointsBlanketUnorderly, GameManager.self.vampireManager.maxPoints);
                }

            }
        }
    }
}
