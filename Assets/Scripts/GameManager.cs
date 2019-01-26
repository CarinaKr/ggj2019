using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager self;

    public PlayerManager vampireManager, frankManager, coboltManager, princessManager;
    public float pointsFrankSofa, pointsCoboltSofa;
    public float pointsVampCurtains, pointsCoboltCurtains;
    public float pointsPrincessCandles, pointsFrankCandels;
    public float pointsVampBed, pointsFrankBed;
    public float pointsPrincessPlants, pointsCoboltPlants;

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
