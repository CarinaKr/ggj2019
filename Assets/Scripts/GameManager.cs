using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager self;

    public PlayerManager vampireManager, frankManager, coboltManager, princessManager;
    public float pointsVampSofa, pointsCoboltSofa;

    public bool isRunning {get;set;}

    private void Awake()
    {
        if(!self)
        {
            self = this;
        }
        if(self!=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


   
}
