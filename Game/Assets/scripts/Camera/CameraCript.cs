using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCript : MonoBehaviour {

    public float rotSpeed = 250;
    public float damping = 10;
    public float rotAngle = 90;
    private float desiredRot;

    // Use this for initialization
    void Start(){
        desiredRot = transform.eulerAngles.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                desiredRot += rotAngle;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                desiredRot -= rotAngle;
            }
        }
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }
}
