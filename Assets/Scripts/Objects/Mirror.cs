using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : InteractableObject
{

    public bool mirrorOpen = false;
    public bool countPoints;

    public GameObject closedMirror;
    public GameObject openMirror;

    protected override void Start()
    {
        base.Start();
        isMovable = false;
        StartCoroutine("AddPoints");
        if (state)
        {
            mirrorOpen = true;
            openMirror.SetActive(true);
            closedMirror.SetActive(false);
        }
        else
        {
            mirrorOpen = false;
            openMirror.SetActive(false);
            closedMirror.SetActive(true);
        }
    }

    public override void HoldInteraction()
    {
        Debug.Log("open or close mirror");
        state = !state;
        if (state)
        {
            mirrorOpen = true;
            openMirror.SetActive(true);
            closedMirror.SetActive(false);
        }
        else
        {
            mirrorOpen = false;
            openMirror.SetActive(false);
            closedMirror.SetActive(true);
        }
    }

    private IEnumerator AddPoints()
    {
        while (countPoints)
        {
            yield return new WaitForSeconds(1f);
            if (gameManager.isRunning)
            {
                if (mirrorOpen)
                {
                    GameManager.self.princessManager.points = Mathf.Min(GameManager.self.princessManager.points + GameManager.self.pointsPrincessMirror, GameManager.self.princessManager.maxPoints);
                }
                else if (!mirrorOpen)
                {
                    GameManager.self.vampireManager.points = Mathf.Min(GameManager.self.vampireManager.points + GameManager.self.pointsVampireMirror, GameManager.self.vampireManager.maxPoints);
                }

            }
        }
    }

}