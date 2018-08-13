using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        cam = Camera.main.transform;
        anim = GetComponent<Animator>();
	}

    Transform cam;

    public Animator anim;

	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position- cam.position);
        
	}

    public void SetTimer(int number)
    {
        if (anim == null)
        {
            Debug.Log("where is the animator?");
        }
        else
        {
            anim.SetInteger("Number", number);
        }
        
    }



}
