using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : InteractableObject {

    public bool mirrorOpen = false;

    public GameObject closedMirror;
    public GameObject openMirror;

    private void Start()
    {
        isMovable = false;
    }

    public override void HoldInteraction()
    {
        Debug.Log("open or close mirror");
        state = !state;
        if (state) {
            mirrorOpen = true;
            openMirror.SetActive(true);
            openMirror.SetActive(false);
        }                     
        else
        {
            mirrorOpen = false;
            openMirror.SetActive(false);
            openMirror.SetActive(true);
        }
    }
}
