using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour {
    private Transform target;
    private int waveIndex = 0;
    public int speed = 20;
	// Use this for initialization
	void Start () {
        target = Waypoint.points[0];
        Debug.Log(Waypoint.points.Length);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

	}
    void GetNextWayPoint()
    {
        
        if(waveIndex >= Waypoint.points.Length -1)
        {
            waveIndex = 0;
        }
        waveIndex++;
        //Debug.Log(waveIndex);
        target = Waypoint.points[waveIndex];
    }
    
   
}
