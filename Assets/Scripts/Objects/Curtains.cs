using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtains : InteractableObject {

    public Color open, closed;

    private Material currentMaterial;

	// Use this for initialization
	protected override void Start () {
        currentMaterial = GetComponent<Renderer>().material;
        currentMaterial.color = closed;
	}

    public override void HoldInteraction()
    {
        Debug.Log("draw or close curtains");
        state = !state;
        if (state)
            currentMaterial.color = open;
        else
            currentMaterial.color = closed;
    }

    private IEnumerator AddPoints()
    {
        while (countPoints)
        {
            yield return new WaitForSeconds(1f);
            if (gameManager.isRunning)
            {
                if (state)
                {
                    GameManager.self.coboltManager.points = Mathf.Min(GameManager.self.coboltManager.points + GameManager.self.pointsCoboltCurtains, GameManager.self.coboltManager.maxPoints);
                }
                else if (!state)
                {
                    GameManager.self.vampireManager.points = Mathf.Min(GameManager.self.vampireManager.points + GameManager.self.pointsVampCurtains, GameManager.self.vampireManager.maxPoints);
                }
            }
        }
    }
}
