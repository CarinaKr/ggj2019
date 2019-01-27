using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainsManager : MonoBehaviour {

    public bool countPoints;
    public Curtains[] curtains;

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
                int openCurtains = 0;
                int closedCurtains = 0;
                foreach(Curtains curtain in curtains)
                {
                    if(curtain.state)
                    {
                        openCurtains++; 
                    }
                    else if(!curtain.state)
                    {
                        closedCurtains++;
                    }
                }

                if (openCurtains==curtains.Length)
                {
                    GameManager.self.coboltManager.points = Mathf.Min(GameManager.self.coboltManager.points + GameManager.self.pointsCoboltCurtains, GameManager.self.coboltManager.maxPoints);
                }
                else if (closedCurtains==curtains.Length)
                {
                    GameManager.self.vampireManager.points = Mathf.Min(GameManager.self.vampireManager.points + GameManager.self.pointsVampCurtains, GameManager.self.vampireManager.maxPoints);
                }
                
            }
        }
    }
    
}
