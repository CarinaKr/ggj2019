using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public int maxPoints;
    public float pointsDeductionPerSecond;
    public GameObject manualImage;

    public Image pointsCircle;

    //public bool started { get; set; }
    public int playerNum { get; set; }
    public string manual { get; set; }
    private float _points;


    private void Update()
    {
        if(Input.GetButtonDown(manual))
        {
            if (manualImage.activeSelf)
            {
                manualImage.SetActive(false);
            }
            else
                manualImage.SetActive(true);
        }
    }

    private IEnumerator LosePoints()
    {
        while(GameManager.self.isRunning)
        {
            yield return new WaitForSeconds(1f);
            points =Mathf.Max(0,points-pointsDeductionPerSecond);
        }
        
    }

    public float points
    {
        get
        {
            return _points;
        }
        set
        {
            _points = value;
            pointsCircle.fillAmount = _points / maxPoints;
        }
    }

	
}
