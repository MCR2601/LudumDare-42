using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickme : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GetComponentInParent<BuildMe>().OnMouseDown();
    }

    public void OnMouseEnter()
    {
        GetComponentInParent<BuildMe>().OnMouseEnter();
    }

    public void OnMouseExit()
    {
        GetComponentInParent<BuildMe>().OnMouseExit();
    }

}
