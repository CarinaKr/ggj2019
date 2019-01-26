using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : InteractableObject {

    private GameObject candleLight;

    override protected void Start()
    {
        base.Start();
        candleLight = transform.GetChild(0).gameObject;
        if (state)
            candleLight.SetActive(true);
        else if (!state)
            candleLight.SetActive(false);
    }

    public override void HoldInteraction()
    {
        Debug.Log("Candle activated");
        state = !state;
        if (state)
            candleLight.SetActive(true);
        else if (!state)
            candleLight.SetActive(false);
    }
    
}
