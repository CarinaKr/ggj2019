using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class AssignPlayers : MonoBehaviour {

    //bool playerIndexSet = false;
    //PlayerIndex playerIndex;
    //GamePadState state;

    public GameObject[] players;

    private PlayerManager[] playerManagers;
    private InteractionController[] playersInteraction;
    private MovementController[] playersMovement;

    // Use this for initialization
    void Start () {
        playersInteraction = new InteractionController[players.Length];
        playersMovement = new MovementController[players.Length];
        playerManagers = new PlayerManager[players.Length];
        CheckForControllers();
        AssignRandomPlayers();
        StartCoroutine("HighlightPlayers");
    }

    private IEnumerator HighlightPlayers()
    {
        Camera[] cams = new Camera[players.Length];
        Rect[] oldRects = new Rect[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            cams[i] = players[i].GetComponentInChildren<Camera>();
            oldRects[i] = cams[i].rect;
            cams[i].rect = new Rect(0, 0, 0, 0);
        }

        for (int i=0;i<players.Length;i++)
        {
            yield return new WaitForSeconds(1f);
            cams[i].rect = new Rect(0, 0, 1, 1);
            PlayerManager manager = cams[i].GetComponentInParent<PlayerManager>();
            int playerNum = cams[i].GetComponentInParent<PlayerManager>().playerNum;

            GamePad.SetVibration((PlayerIndex)playerNum, 1f, 1f);   //rumble controller
            yield return new WaitForSeconds(0.4f);
            GamePad.SetVibration((PlayerIndex)playerNum, 0, 0);
            //yield return new WaitForSeconds(0.1f);
            //GamePad.SetVibration((PlayerIndex)playerNum, 0.5f, 0.5f);
            //yield return new WaitForSeconds(0.4f);
            //GamePad.SetVibration((PlayerIndex)playerNum, 0, 0);
            cams[i].rect = new Rect(0, 0, 0, 0);    

        }

        for (int i = 0; i < players.Length; i++)
        {
            cams[i].rect = oldRects[i];                      //reset camera rect
            GameManager.self.isRunning = true;
            playerManagers[i].StartCoroutine("LosePoints");
        }
    }

    private void AssignRandomPlayers()
    {
        HashSet<int> playerNum = new HashSet<int>();
        for (int i = 0; i < 4; i++)
        {
            int randNum = Random.Range(0, 4);
            while (playerNum.Contains(randNum))
            {
                randNum = Random.Range(0, 4);
            }
            playerNum.Add(randNum);

            playersMovement[i] = players[i].GetComponent<MovementController>();
            playersMovement[i].horizontal = "Horizontal" + randNum;
            playersMovement[i].vertical = "Vertical" + randNum;
            playersMovement[i].turn = "Camera" + randNum;

            playerManagers[i] = players[i].GetComponent<PlayerManager>();
            playerManagers[i].playerNum = randNum;

            playersInteraction[i] = players[i].GetComponent<InteractionController>();
            playersInteraction[i].pickUp = "PickUp" + randNum;
            playersInteraction[i].holdInteraction = "Hold" + randNum;
        }
    }
	
    private void CheckForControllers()
    {
        for (int i = 0; i < 4; ++i)
        {
            PlayerIndex testPlayerIndex = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected)
            {
                Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
            }
        }
    }
}
