using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipScript : MonoBehaviour {

    Text Name;
    Text Consumes;
    Text Produces;

    public Vector3 startlocation;
    public Vector3 hideLocation;

    public Vector3 currentGoalLocation;
    public float Speed = 10f;

    Animator anim;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();


        Text[] list = GetComponentsInChildren<Text>();
        foreach (var item in list)
        {
            if (item.transform.name=="Name")
            {
                Name = item;
            }
            if (item.transform.name == "Consumes")
            {
                Consumes = item;
            }
            if (item.transform.name == "Produces")
            {
                Produces = item;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
    }


    public void HideToolTip()
    {
        anim.SetTrigger("Hide");
    }

    public void ShowToolTipMaterial(BaseMaterial material)
    {
        anim.SetTrigger("Show");
        Name.text = material.Name + " - Material";
        Consumes.text = "-";
        Produces.text = "-";
    }
    public void ShowToolTipBuilding(BaseBuilding building)
    {
        anim.SetTrigger("Show");
        currentGoalLocation = startlocation;
        Name.text = building.Name + " - Building";
        Consumes.text = building.Input.enabled ? "Consumes: "+building.Input.ConsumeAmount + "x " + building.Input.MaterialName : "Consumes: None";
        Produces.text = "Produces: " + building.Output.MaterialName + " (" + building.Output.DeliverTimer + " turns)";
    }

}
