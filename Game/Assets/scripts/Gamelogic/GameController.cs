using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private BlueprintLibrary blueprints;
    private BuildingLibrary buildings;
    private MaterialLibrary materials;

    private Space space;

    public GameState State = GameState.Idle;
    public Tool activeTool = Tool.Shovel;

    
	// Use this for initialization
	void Start () {
        space = new Space(6, 6);
        blueprints = new BlueprintLibrary();
        buildings = new BuildingLibrary();
        materials = new MaterialLibrary();
	}

    bool spawned = false;

	// Update is called once per frame
	void Update () {

        if (!spawned && Time.time > 3 )
        {
            Debug.Log("Something should have happend");
            BaseMaterial tmp = materials.GetMaterialByName("Dirt");
            tmp.Place(new SimpleCords(2, 2));
            spawned = true;
        }

	}
}
