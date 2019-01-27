using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float timeGame;
    [Tooltip("order: VAMP, PRINCESS, FRANK, COBOLT")]
    public Sprite[] winnerSprites;

    private Image gameOverImage;
    private Text winnerText;
    private int currentLevel=0;
    private float[] finalPoints;
    private enum winner
    {
        VAMP,
        COBOLT,
        FRANK,
        PRINCESS
    }
    private winner isWinner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PickUp0"))
        {
            if (currentLevel == 0)
                SceneManager.LoadScene(1);
            else if (currentLevel == 1)
                SceneManager.LoadScene(2);
            else if (currentLevel == 3)
            {
                SceneManager.LoadScene(0);
                Destroy(GameManager.self.gameObject);
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        currentLevel = level;
        if (level == 1)
        {
            StartCoroutine("RunGameLevel");
        }
        else if(level==2)
        {
            winnerText = GameObject.Find("WinnerText").GetComponent<Text>();
            if (isWinner == winner.VAMP)
                winnerText.text = "The Vampire won!";
            else if (isWinner == winner.PRINCESS)
                winnerText.text = "The Princess won!";
            else if (isWinner == winner.FRANK)
                winnerText.text = "Frankenstein won!";
            else if (isWinner == winner.COBOLT)
                winnerText.text = "The Cobolt won!";
        }
    }

    private IEnumerator RunGameLevel()
    {
        while (!GameManager.self.isRunning)
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(timeGame);
        GameManager.self.isRunning = false;
        DetermineWinner();
    }

    private void DetermineWinner()
    {
        finalPoints = new float[4];
        finalPoints[0] = GameManager.self.vampireManager.points;
        finalPoints[1] = GameManager.self.frankManager.points;
        finalPoints[2] = GameManager.self.coboltManager.points;
        finalPoints[3] = GameManager.self.princessManager.points;

        float minPoints = Mathf.Min(finalPoints[0], Mathf.Min(finalPoints[1], Mathf.Min(finalPoints[2], finalPoints[3])));

        if (minPoints == GameManager.self.vampireManager.points)
            isWinner = winner.VAMP;
        else if (minPoints == GameManager.self.frankManager.points)
            isWinner = winner.FRANK;
        else if (minPoints == GameManager.self.coboltManager.points)
            isWinner = winner.COBOLT;
        else if (minPoints == GameManager.self.princessManager.points)
            isWinner = winner.PRINCESS;

        SceneManager.LoadScene(2);
    }
}
