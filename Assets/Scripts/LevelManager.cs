using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager self;

    public float timeGame;
    [Tooltip("order: VAMP, PRINCESS, FRANK, COBOLT")]
    public Transform[] characters;

    private Image gameOverImage;
    private Text winnerText;
    private int currentLevel=0;
    private List<PlayerManager> finalPointsChar;

    private Transform[] podestPositions;
    private PlayerManager first, second, third, forth;
    private winner firstWinner, secondWinner, thirdWinner, forthWinner;

    private enum winner
    {
        VAMP,
        COBOLT,
        FRANK,
        PRINCESS
    }

    private void Awake()
    {
        if (!self)
        {
            self = this;
        }
        if (self != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

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
        if (level == 2)
        {
            StartCoroutine("RunGameLevel");
        }
        else if(level==3)
        {
            ////winnerText = GameObject.Find("WinnerText").GetComponent<Text>();
            //if (isWinner == winner.VAMP)
            //    winnerText.text = "The Vampire won!";
            //else if (isWinner == winner.PRINCESS)
            //    winnerText.text = "The Princess won!";
            //else if (isWinner == winner.FRANK)
            //    winnerText.text = "Frankenstein won!";
            //else if (isWinner == winner.COBOLT)
            //    winnerText.text = "The Cobolt won!";
            podestPositions = new Transform[4];
            podestPositions[0] = GameObject.Find("firstPosition").transform;
            podestPositions[1] = GameObject.Find("secondPosition").transform;
            podestPositions[2] = GameObject.Find("thirdPosition").transform;
            podestPositions[3] = GameObject.Find("forthPosition").transform;
            characters[0] = GameObject.Find("Vampir").transform;
            characters[1] = GameObject.Find("Kobold").transform;
            characters[2] = GameObject.Find("Frankenstein").transform;
            characters[3] = GameObject.Find("Princess").transform;

            characters[(int)firstWinner].position = podestPositions[0].position;
            characters[(int)secondWinner].position = podestPositions[1].position;
            characters[(int)thirdWinner].position = podestPositions[2].position;
            characters[(int)forthWinner].position = podestPositions[3].position;

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
        finalPointsChar = new List<PlayerManager>();
        finalPointsChar.Add(GameManager.self.vampireManager);
        finalPointsChar.Add(GameManager.self.frankManager);
        finalPointsChar.Add(GameManager.self.coboltManager);
        finalPointsChar.Add( GameManager.self.princessManager);

        //float minPoints = Mathf.Min(finalPointsChar[0], Mathf.Min(finalPointsChar[1], Mathf.Min(finalPointsChar[2], finalPointsChar[3])));

        //first
        float minPoints = finalPointsChar[0].points;
        first = finalPointsChar[0];
        for (int i=0;i<finalPointsChar.Count;i++)
        {
            if (minPoints <= finalPointsChar[i].points)
            {
                minPoints = finalPointsChar[i].points;
                first = finalPointsChar[i];
            }
        }
        finalPointsChar.Remove(first);

        //second
        minPoints = finalPointsChar[0].points;
        second = finalPointsChar[0];
        for (int i = 0; i < finalPointsChar.Count; i++)
        {
            if (minPoints <= finalPointsChar[i].points)
            {
                minPoints = finalPointsChar[i].points;
                second = finalPointsChar[i];
            }
        }
        finalPointsChar.Remove(second);

        //third
        minPoints = finalPointsChar[0].points;
        third = finalPointsChar[0];
        for (int i = 0; i < finalPointsChar.Count; i++)
        {
            if (minPoints <= finalPointsChar[i].points)
            {
                minPoints = finalPointsChar[i].points;
                third = finalPointsChar[i];
            }
        }
        finalPointsChar.Remove(third);

        //forth
        forth = finalPointsChar[0];

        if (first == GameManager.self.vampireManager)
            firstWinner = winner.VAMP;//characters[0].position = podestPositions[0].position;
        else if (first == GameManager.self.princessManager)
            firstWinner = winner.PRINCESS;//characters[1].position = podestPositions[0].position;
        else if (first == GameManager.self.frankManager)
            firstWinner = winner.FRANK;//characters[2].position = podestPositions[0].position;
        else if (first == GameManager.self.coboltManager)
            firstWinner = winner.COBOLT;//characters[3].position = podestPositions[0].position;

        if (second == GameManager.self.vampireManager)
            secondWinner = winner.VAMP;//coboltManagercharacters[0].position = podestPositions[1].position;
        else if (second == GameManager.self.princessManager)
            secondWinner = winner.PRINCESS;//characters[1].position = podestPositions[1].position;
        else if (second == GameManager.self.frankManager)
            secondWinner = winner.FRANK;//characters[2].position = podestPositions[1].position;
        else if (second == GameManager.self.coboltManager)
            secondWinner = winner.COBOLT;//characters[3].position = podestPositions[1].position;

        if (third == GameManager.self.vampireManager)
            thirdWinner = winner.VAMP;//characters[0].position = podestPositions[2].position;
        else if (third == GameManager.self.princessManager)
            thirdWinner = winner.PRINCESS;//characters[1].position = podestPositions[2].position;
        else if (third == GameManager.self.frankManager)
            thirdWinner = winner.FRANK;//characters[2].position = podestPositions[2].position;
        else if (third == GameManager.self.coboltManager)
            thirdWinner = winner.COBOLT;//characters[3].position = podestPositions[2].position;

        if (forth == GameManager.self.vampireManager)
            forthWinner = winner.VAMP;//characters[0].position = podestPositions[3].position;
        else if (forth == GameManager.self.princessManager)
            forthWinner = winner.PRINCESS;//characters[1].position = podestPositions[3].position;
        else if (forth == GameManager.self.frankManager)
            forthWinner = winner.FRANK;//characters[2].position = podestPositions[3].position;
        else if (forth == GameManager.self.coboltManager)
            forthWinner = winner.COBOLT;//characters[3].position = podestPositions[3].position;

        SceneManager.LoadScene(3);
    }
}
