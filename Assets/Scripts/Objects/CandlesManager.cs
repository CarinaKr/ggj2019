using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlesManager : MonoBehaviour {

    public bool countPoints;
    public Candle[] candles;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.self;
        StartCoroutine("AddPoints");
    }

    private IEnumerator AddPoints()
    {
        while (countPoints)
        {
            yield return new WaitForSeconds(1f);
            if (gameManager.isRunning)
            {
                int onCandles = 0;
                int offCandles = 0;
                foreach (Candle candle in candles)
                {
                    if (candle.state)
                    {
                        onCandles++;
                    }
                    else if (!candle.state)
                    {
                        offCandles++;
                    }
                }

                if (onCandles == candles.Length)
                {
                    GameManager.self.princessManager.points = Mathf.Min(GameManager.self.princessManager.points + GameManager.self.pointsCoboltCurtains, GameManager.self.princessManager.maxPoints);
                }
                else if (offCandles == candles.Length)
                {
                    GameManager.self.frankManager.points = Mathf.Min(GameManager.self.frankManager.points + GameManager.self.pointsVampCurtains, GameManager.self.frankManager.maxPoints);
                }

            }
        }
    }
}
