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

    private readonly Queue<ProcessingStep> ProcessQueue = new Queue<ProcessingStep>();
    
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
        //TODO delete this
        if (!spawned && Time.time > 3 )
        {
            Debug.Log("Something should have happend");
            BaseMaterial tmp = materials.GetMaterialByName("Dirt");
            tmp.Place(new SimpleCords(2, 2));
            spawned = true;
        }

        // flow control
        switch (State)
        {
            case GameState.Menu:
                // check menu items for clicks with raycasts


                break;
            case GameState.Idle:
                // check everything for clicks with raycasts
                // check for hover
                // if hover start displaying Information (i think just the name for now)
                // check for legal moves on drag and so on
                



                break;
            case GameState.Processing:
                break;
            case GameState.Skipping:
                break;
            default:
                break;
        }





    }

    // you can use lambda expressions for processing
    

    void AdvanceTimers()
    {

    }

    void DoInput()
    {

    }

    void DoOutput()
    {

    }




}
