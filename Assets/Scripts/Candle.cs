using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : InteractableObject {

    private GameObject light;

    private void Start()
    {
        light = transform.GetChild(0).gameObject;
    }

    public override void HoldInteraction()
    {
        Debug.Log("Candle activated");
        light.SetActive(!light.activeSelf);
    }
}
