using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerCollision : MonoBehaviour {

    public PlayerController movement;
    public Score score;
    public GameObject scoreCanvas;
    public GameObject jumpScare;
    public GameObject gameOver;
    public GameMaster gamemaster;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            Debug.Log("we hit an obstacle");
            movement.enabled = false;
            score.isRun = false;
            StartCoroutine(GameMaster.instance.Activate());
            
        }
    }

    
}
