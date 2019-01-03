using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameMaster gamemaster;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && GameMaster.instance.isOver == false)
        {
            gamemaster.LevelComplete();
            GameMaster.instance.isOver = true;
        }
            
    }
}
