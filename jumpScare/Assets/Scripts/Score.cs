using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text textBox;
    public bool isRun;
    int pointscore = 0;
    private void Start()
    {
        isRun = true;
    }
    /* void Update()
    {
        
        textBox.text = "Score :" + player.position.x.ToString("0"); 
    }*/
    private void Update()
    {
        if (isRun == true)
            increasePoint();
        else
            return;

        textBox.text = "Score :" + pointscore;
    }

    public void increasePoint()
    {
        pointscore++;
    }
    public int GetPointScore()
    {
        return pointscore;
    }
}
