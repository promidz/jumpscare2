using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    Rigidbody rigidbodi;
    [SerializeField]
    int forwardForce = -2000;
    [SerializeField]
    int sideForce = 1000;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rigidbodi.AddForce(forwardForce * Time.deltaTime,0,0);

        if (Input.GetKey(KeyCode.D))
        {
            rigidbodi.AddForce(0, 0, sideForce * Time.deltaTime,ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbodi.AddForce(0, 0, -sideForce * Time.deltaTime,ForceMode.VelocityChange);
        }
	}
}
