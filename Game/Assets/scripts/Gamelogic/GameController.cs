using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private BlueprintLibrary blueprints;
    private BuildingLibrary buildings;
    private MaterialLibrary materials;

    private Space space;

    private TooltipScript toolTip;

    public GameState State = GameState.Idle;
    public Tool activeTool = Tool.Shovel;

    private readonly Queue<ProcessingStep> ProcessQueue = new Queue<ProcessingStep>();
    private bool ProcessCompleted = true;

    /// <summary>
    /// The current state
    /// </summary>
    public MoveState moveState = MoveState.Idle;
    /// <summary>
    /// the Material currently beeing held
    /// </summary>
    private BaseMaterial heldMaterial;
    /// <summary>
    /// where it originatest
    /// </summary>
    private SimpleCords originLocation;
    /// <summary>
    /// a list of all Gameobjects used to display possible droppoints
    /// </summary>
    List<GameObject> possiblePositionsGO;
    /// <summary>
    /// a list of all possible Coordinates of droppoints
    /// </summary>
    List<SimpleCords> possiblePositions;

    /// <summary>
    /// The time the mouse has remained above an Object
    /// </summary>
    public float hoverTime = 0f;
    public bool isHovering = false;
    public float requiredHoverTime = 0.5f;
    public bool isHoveringMaterial = false; // material or building

    private BaseMaterial hoverMaterial;
    private BaseBuilding hoverBuilding;

    /// <summary>
    /// The time the mouse has been held down
    /// </summary>
    public float holdTime = 0f;
    public bool isHolding = false;
    public float requiredHoldTime = 0.2f;


	// Use this for initialization
	void Start () {
        space = new Space(6, 6);
        blueprints = new BlueprintLibrary();
        buildings = new BuildingLibrary();
        materials = new MaterialLibrary();
        toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<TooltipScript>();
	}

    bool spawned = false;

	// Update is called once per frame
	void Update () {
        //TODO delete this
        if (!spawned && Time.time > 1 )
        {
            Debug.Log("Something should have happend");
            BaseMaterial tmp = materials.GetMaterialByName("Dirt");
            tmp.Place(new SimpleCords(2, 2));
            space.Map[2, 2].Material = tmp;
            space.Map[2, 2].occupation = TileOccupation.Material;
            spawned = true;
        }

        #region Idle Mouse things
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // set the hitmask to be layer 10 (floor) and 11 (Hoverable)
        


        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            // do the calculations for drag (layer floor


        }
        else
        {
            // hover calculations
            int hitmask = 1 << 11 | 1 << 10;
            if (Physics.Raycast(ray, out hit, 100,hitmask))
            {
                
                Vector3 hitLoc = hit.transform.position;
                SimpleCords location = new SimpleCords((int)Mathf.Round(hitLoc.x), (int)Mathf.Round(hitLoc.y), (int)Mathf.Round(hitLoc.z));
                Tile t = space.Map.SaveGet(location.x, location.z);
                Debug.Log(t.occupation);
                if (isHovering)
                {
                    if (t.occupation == TileOccupation.Material && isHoveringMaterial && t.Material == hoverMaterial)
                    {
                        // still hovering over the same Material                        
                    }
                    else
                    {
                        if (t.occupation == TileOccupation.Building && !isHoveringMaterial && t.Building == hoverBuilding)
                        {
                            // still hovering over the same Building
                        }
                        else
                        {
                            // we are not hovering over the same anymore
                            // hide tooltip and so on
                            toolTip.HideToolTip();
                            isHovering = false;
                            hoverTime = 0f;
                            switch (t.occupation)
                            {
                                case TileOccupation.Empty:
                                    break;
                                case TileOccupation.Material:
                                    // new material
                                    isHoveringMaterial = true;
                                    hoverMaterial = t.Material;
                                    break;
                                case TileOccupation.Building:
                                    // new building
                                    isHoveringMaterial = false;
                                    hoverBuilding = t.Building;
                                    break;
                                case TileOccupation.Error:
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                }
                else
                {
                    if (t.occupation == TileOccupation.Material && isHoveringMaterial && t.Material == hoverMaterial)
                    {
                        hoverTime += Time.deltaTime;
                        // still hovering over the same Material
                        if (hoverTime >= requiredHoverTime)
                        {
                            isHovering = true;
                            toolTip.ShowToolTipMaterial(t.Material);
                        }
                    }
                    else
                    {
                        if (t.occupation == TileOccupation.Building && !isHoveringMaterial && t.Building == hoverBuilding)
                        {
                            hoverTime += Time.deltaTime;
                            // still hovering over the same Building
                            if (hoverTime >= requiredHoverTime)
                            {
                                isHovering = true;
                                toolTip.ShowToolTipBuilding(t.Building);
                            }                            
                        }
                        else
                        {
                            isHovering = false;
                            hoverTime = 0f;
                            switch (t.occupation)
                            {
                                case TileOccupation.Material:
                                    // new material
                                    isHoveringMaterial = true;
                                    hoverMaterial = t.Material;
                                    break;
                                case TileOccupation.Building:
                                    // new building
                                    isHoveringMaterial = false;
                                    hoverBuilding = t.Building;
                                    break;
                                default:
                                    hoverBuilding = null;
                                    hoverMaterial = null;
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (isHovering)
                {
                    toolTip.HideToolTip();
                    isHovering = false;
                    hoverTime = 0f;
                }
            }
            #endregion

            // flow control
            switch (State)
            {
                case GameState.Menu:
                    // check menu items for clicks with raycasts

                    //TODO: make a menu

                    break;
                case GameState.Idle:
                    // check everything for clicks with raycasts
                    // check for hover
                    // if hover start displaying Information (i think just the name for now)
                    // check for legal moves on drag and so on




                    break;
                case GameState.Processing:
                    // work through the ProcessingQueue 
                    // every process has to finish by calling the "ReportDone" Method



                    break;
                case GameState.Skipping:
                    // temporary state that is just for skipping the players input phase
                    // because there is nothing to do


                    break;
                default:
                    break;
            }
        }

    }

    public void ReportDone()
    {
        ProcessCompleted = true;
    }

    // you can use lambda expressions for processing
    
    void HidePossibleBuildings()
    {

    }
    
    void AdvanceTimers()
    {

    }

    void DoInput()
    {

    }

    void DoOutput()
    {

    }

    void ShowPossibleBuildings()
    {

    }

    public void ShowInfoAt(string message, SimpleCords location)
    {

    }




}
