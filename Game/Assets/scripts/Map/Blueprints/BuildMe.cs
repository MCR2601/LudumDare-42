using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMe : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public DetectedBuilding Information;

    public ProcessingStep clicker;

    public void OnMouseDown()
    {
        if (clicker != null)
        {
            clicker();
        }
    }

    public void OnMouseEnter()
    {
        
    }

    public void OnMouseExit()
    {
        
    }



}
