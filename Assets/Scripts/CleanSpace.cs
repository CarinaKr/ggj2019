using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanSpace : MonoBehaviour {

    public bool countPoints;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.self;
        StartCoroutine("AddPoints");
    }

    private IEnumerator AddPoints()
    {
        yield return new WaitForSeconds(10f);
        while (countPoints)
        {
            yield return new WaitForSeconds(1f);
            if (gameManager.isRunning)
            {

                Collider[] colliders = Physics.OverlapBox(transform.position, transform.lossyScale / 2);
                bool isClear = true;
                foreach (Collider coll in colliders)
                {
                    if (coll.transform.tag == "Object")
                    {
                        isClear = false;
                    }
                }

                if (isClear)
                {
                    GameManager.self.frankManager.points = Mathf.Min(GameManager.self.frankManager.points + GameManager.self.pointsFrankSofa, GameManager.self.frankManager.maxPoints);
                }
                else if (!isClear)
                {
                    GameManager.self.coboltManager.points = Mathf.Min(GameManager.self.coboltManager.points + GameManager.self.pointsCoboltSofa, GameManager.self.coboltManager.maxPoints);
                }

            }
        }
    }

}
