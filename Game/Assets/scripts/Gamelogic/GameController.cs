using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    /// where it originates
    /// </summary>
    private SimpleCords originLocation;
    /// <summary>
    /// a list of all Gameobjects used to display possible droppoints
    /// </summary>
    List<GameObject> possiblePositionsGO;
    /// <summary>
    /// a list of all possible Coordinates of droppoints
    /// </summary>
    List<SimpleCords> possiblePositions = new List<SimpleCords>();
    SimpleCords holdPosition;
    /// <summary>
    /// The time the mouse has been held down
    /// </summary>
    public float holdTime = 0f;
    public bool isHolding = false;
    public float requiredHoldTime = 0.1f;
    private BaseMaterial holdingMaterial;
    // objects that need to be moved back to original location
    List<KeyValuePair<GameObject, Vector3>> ObjectsToReturn = new List<KeyValuePair<GameObject, Vector3>>();

    /// <summary>
    /// The time the mouse has remained above an Object
    /// </summary>
    public float hoverTime = 0f;
    public bool isHovering = false;
    public float requiredHoverTime = 0.5f;
    public bool isHoveringMaterial = false; // material or building

    public float restart = 0f;
    public float restartTime = 2f;

    private BaseMaterial hoverMaterial;
    private BaseBuilding hoverBuilding;

    private List<GameObject> possibleBuildingHammer = new List<GameObject>();

    public Button btn1;
    public Button btn2;
    public Button btn3;

    public Text txt;

    public GameObject WinScreen;
    public float winMet = 0f;
    public bool winThere = false;
    public float winDelay = 3f;

    // Use this for initialization
    void Start() {

        btn1.onClick.AddListener(() => { activeTool = Tool.Shovel; txt.text = "Shovel"; });
        btn2.onClick.AddListener(() => { activeTool = Tool.Move; txt.text = "Move"; });
        btn3.onClick.AddListener(() => { activeTool = Tool.Delete; txt.text = "Destroy"; });

        space = new Space(6, 6);
        blueprints = new BlueprintLibrary();
        buildings = new BuildingLibrary();
        materials = new MaterialLibrary();
        toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<TooltipScript>();
	}

    bool spawned = false;

	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.R))
        {
            restart += Time.deltaTime;
            if (restart > restartTime)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            restart = 0f;
        }

        if (space.GetAvaiableMaterial().ContainsKey("Amazing Product")||(Input.GetKey( KeyCode.B)&&Input.GetKey(KeyCode.M)))
        {
            winThere = true;
        }

        if (winThere)
        {
            winMet += Time.deltaTime;
        }

        if (winMet >= winDelay)
        {
            WinScreen.SetActive(true);
        }

        MoveAllObjectsBack();
        
        //TODO delete this
        if (!spawned && Time.time > 1 )
        {
            Debug.Log("Something should have happend");

            //space.SpawnMaterial(materials.GetMaterialByName("Dirt"), new SimpleCords(1, 1));
            //space.SpawnMaterial(materials.GetMaterialByName("Dirt"), new SimpleCords(4, 1));
            //space.SpawnMaterial(materials.GetMaterialByName("Dirt"), new SimpleCords(1, 3));

            //space.SpawnMaterial(materials.GetMaterialByName("Clay"), new SimpleCords(0, 2));
            //space.SpawnMaterial(materials.GetMaterialByName("Clay"), new SimpleCords(0, 3));

            //space.SpawnMaterial(materials.GetMaterialByName("Clay"), new SimpleCords(2, 2));
            //space.SpawnMaterial(materials.GetMaterialByName("Clay"), new SimpleCords(2, 3));

            //space.SpawnMaterial(materials.GetMaterialByName("Clay"), new SimpleCords(4, 2));
            //space.SpawnMaterial(materials.GetMaterialByName("Clay"), new SimpleCords(4, 3));

            space.SpawnMaterial(materials.GetMaterialByName("Dirt"),new SimpleCords(3,2));
            AdvanceToProcessing();
            spawned = true;
        }

        
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // set the hitmask to be layer 10 (floor) and 11 (Hoverable)

         // flow control
        switch (State)
        {
            case GameState.Menu:
                // check menu items for clicks with raycasts

                //TODO: make a menu

                break;
            case GameState.PauseMenu:
                

                break;
            case GameState.Idle:
                // check everything for clicks with raycasts
                // check for hover
                // if hover start displaying Information (i think just the name for now)
                // check for legal moves on drag and so on
                if (space.GetAvaiableMaterial().Count==0&&space.IsBuildingDelivering())
                {
                    State = GameState.Skipping;
                    // skipp ahead 
                }
                else
                {
                    #region Idle Mouse things
                    // normal user input proceeding
                    if (Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0))
                    {

                        // stop hovering because of click

                        if (isHovering)
                        {
                            toolTip.HideToolTip();
                            isHovering = false;
                            hoverTime = 0f;
                        }

                        switch (activeTool)
                        {
                            case Tool.Shovel:
                                int m = 1 << 10;
                                //Debug.Log("HELLO?");
                                RaycastHit hit1;
                                if (Physics.Raycast(ray, out hit1, 100, m))
                                {
                                    
                                    Vector3 hitLoc = hit1.point;
                                    SimpleCords location = new SimpleCords((int)Mathf.Round(hitLoc.x), (int)0, (int)Mathf.Round(hitLoc.z));
                                    Tile t = space.Map.SaveGet(location.x, location.z);
                                    //Debug.Log("Shovel attack"+hitLoc);
                                    if (t.occupation == TileOccupation.Empty)
                                    {
                                        space.SpawnMaterial(materials.GetMaterialByName("Dirt"), t.position);
                                    }
                                    activeTool = Tool.Move;
                                    txt.text = "Move";
                                    AdvanceToProcessing();
                                }
                                break;
                            case Tool.Move:
                                if (isHolding)
                                {
                                    // move the held Object around until we drop it
                                    // get location
                                    int mask = 1 << 10;
                                    if (Physics.Raycast(ray, out hit, 100, mask))
                                    {
                                        //Debug.Log("hit something and i am starting to calculate");
                                        Vector3 hitLoc = hit.transform.position;
                                        SimpleCords location = new SimpleCords((int)Mathf.Round(hitLoc.x), (int)originLocation.y, (int)Mathf.Round(hitLoc.z));

                                        bool contains = false;
                                        for (int i = 0; i < possiblePositions.Count; i++)
                                        {
                                            if (possiblePositions[i].Equals(location))
                                            {
                                                holdPosition = location;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // we dont care that can happen when going to far
                                        //Debug.Log("spam");
                                    }
                                    ObjectsToReturn.RemoveAll((x) => x.Key == heldMaterial.GameObject);
                                    heldMaterial.GameObject.transform.position = Vector3.Lerp(heldMaterial.GameObject.transform.position, new Vector3(0f, 1.5f, 0f) + (Vector3)holdPosition, 8 * Time.deltaTime);
                                }
                                else
                                {
                                    // get gameobject we are pointing at
                                    int hitmask = 1 << 11;
                                    // if we dont hit anything we dont want to grab
                                    // lets work on changing that
                                    if (Physics.Raycast(ray, out hit, 100, hitmask))
                                    {

                                        Vector3 hitLoc = hit.transform.position;
                                        SimpleCords location = new SimpleCords((int)Mathf.Round(hitLoc.x), (int)Mathf.Round(hitLoc.y), (int)Mathf.Round(hitLoc.z));
                                        Tile t = space.Map.SaveGet(location.x, location.z);
                                        // 
                                        if (t.occupation == TileOccupation.Material)
                                        {
                                            holdTime += Time.deltaTime;
                                            holdingMaterial = t.Material;
                                            if (holdTime > requiredHoldTime)
                                            {
                                                // we have to switch a lot around
                                                isHolding = true;
                                                moveState = MoveState.Raise;
                                                originLocation = location;
                                                heldMaterial = t.Material;
                                                holdPosition = location;
                                                ShowPossibleDroplocations();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // we dont point at anything so we just reset some numbers
                                        holdTime = 0f;
                                    }
                                }
                                break;
                            case Tool.Delete:

                                int ma = 1 << 11;
                                if (Physics.Raycast(ray, out hit, 100, ma))
                                {
                                    //Debug.Log("hit something and i am starting to calculate");
                                    Vector3 hitLoc = hit.transform.position;
                                    SimpleCords location = new SimpleCords((int)Mathf.Round(hitLoc.x), 0, (int)Mathf.Round(hitLoc.z));
                                    Tile t = space.Map.SaveGet(location.x, location.z);

                                    if (t.occupation == TileOccupation.Building)
                                    {
                                        RemoveOccupation(t);
                                        activeTool = Tool.Move;
                                        txt.text = "Move";
                                        AdvanceToProcessing();
                                    }                                    
                                }
                                break;
                            default:
                                break;
                        }                        

                        
                    }
                    else
                    {
                        // if we were holding something lets put it back
                        DropMaterial();


                        // hover calculations
                        int hitmask = 1 << 11 | 1 << 10;
                        if (Physics.Raycast(ray, out hit, 100, hitmask))
                        {

                            Vector3 hitLoc = hit.transform.position;
                            SimpleCords location = new SimpleCords((int)Mathf.Round(hitLoc.x), (int)Mathf.Round(hitLoc.y), (int)Mathf.Round(hitLoc.z));
                            Tile t = space.Map.SaveGet(location.x, location.z);
                            //Debug.Log(t.occupation);
                            if (isHovering)
                            {
                                if (t.occupation == TileOccupation.Material && isHoveringMaterial && t.Material == hoverMaterial)
                                {
                                    // still hovering over the same Material                        
                                }
                                else
                                {
                                    if (t.occupation == TileOccupation.Building && isHoveringMaterial && t.Building == hoverBuilding)
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
                                    if (t.occupation == TileOccupation.Building && isHoveringMaterial && t.Building == hoverBuilding)
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
                       


                    }



 #endregion
                }




                break;
            case GameState.Processing:
                // work through the ProcessingQueue 
                // every process has to finish by calling the "ReportDone" Method
                if (ProcessQueue.Count==0 && ProcessCompleted)
                {
                    State = GameState.Idle;
                    Debug.Log("Moving to Idle");
                }
                else
                {
                    if (ProcessCompleted)
                    {
                        //Debug.Log("Process Complete and redoing");
                        // execute the first delegate (this looks really funny :D)
                        ProcessCompleted = false;
                        ProcessQueue.Dequeue().Invoke();
                        
                        //Debug.Log("Invoked and waiting");
                    }
                    else
                    {
                        
                    }
                }
                break;
            case GameState.Skipping:
                // temporary state that is just for skipping the players input phase
                // because there is nothing to do
                AdvanceToProcessing();

                break;
            default:
                break;
        }

    }

    private void DropMaterial()
    {
        if (isHolding)
        {
            moveState = MoveState.Return;
            bool contains = false;
            for (int i = 0; i < possiblePositions.Count; i++)
            {
                if (possiblePositions[i].Equals(holdPosition))
                {
                    contains = true;
                }
            }


            //Debug.Log("contains");
            MoveMaterial(originLocation, holdPosition, heldMaterial);
            // return to new location
            ObjectsToReturn.RemoveAll((x)=>x.Key==heldMaterial.GameObject);
            ObjectsToReturn.Add(new KeyValuePair<GameObject, Vector3>(heldMaterial.GameObject, new Vector3(0, 0.50f, 0) + (Vector3)holdPosition));



            heldMaterial = null;
            isHolding = false;
            holdTime = 0f;

            HidePossiblePositions();
        }
    }

    private void MoveMaterial(SimpleCords from, SimpleCords to, BaseMaterial m)
    {
        if (from.Equals(to))
        {
            return;
        }

        Tile f = space.Map.SaveGet(from.x, from.z);
        Tile t = space.Map.SaveGet(to.x, to.z);

        f.occupation = TileOccupation.Empty;
        f.Material = null;
        t.occupation = TileOccupation.Material;
        t.Material = m;
        m.position = t.position;
        AdvanceToProcessing();
    }
    /// <summary>
    /// remove a material
    /// </summary>
    /// <param name="t">the tile with the material on it</param>
    private void RemoveOccupation(Tile t)
    {
        Debug.Log("Called");
        if (t.occupation == TileOccupation.Material)
        {
            t.occupation = TileOccupation.Empty;
            space.Materials.Remove(t.Material);
            ObjectsToReturn.RemoveAll((x) => { return x.Key == t.Material.GameObject; });
            Destroy(t.Material.GameObject);
            t.Material = null;            
        }
        if (t.occupation == TileOccupation.Building)
        {
            BaseBuilding b = t.Building;
            Destroy(b.Clock.gameObject);
            foreach (var item in b.occupying)
            {
                SimpleCords removLoc = b.CenterLocation.OffsetBy(item);
                Tile tile = space.Map.SaveGet(removLoc.x, removLoc.z);
                if (tile.occupation == TileOccupation.Building)
                {
                    tile.Building = null;
                    tile.occupation = TileOccupation.Empty;
                }
            }
            space.Buildings.Remove(t.Building);
            Destroy(b.GameObject);            
        }
    }


    private void AdvanceToProcessing()
    {
        Debug.Log("advance to processing");
        State = GameState.Processing;
        //TODO: look closely
        //register all the things to the queue
        ProcessQueue.Enqueue(HidePossibleBuildings);
        ProcessQueue.Enqueue(DoInput);
        ProcessQueue.Enqueue(AdvanceTimers);
        ProcessQueue.Enqueue(DoOutput);
        ProcessQueue.Enqueue(ShowPossibleBuildings);
    }



    private void MoveAllObjectsBack()
    {
        List<KeyValuePair<GameObject, Vector3>> toremove = new List<KeyValuePair<GameObject, Vector3>>(ObjectsToReturn);
        if (ObjectsToReturn.Count>0)
        {
            foreach (var item in toremove)
            {
                item.Key.transform.position = Vector3.Lerp(item.Key.transform.position, item.Value, 8 * Time.deltaTime);
                if (item.Key.transform.position == item.Value)
                {
                    ObjectsToReturn.Remove(item);
                }                
            }
        }
        
    }

    public void ReportDone()
    {
        //Debug.Log("I am done");
        ProcessCompleted = true;
    }

    // you can use lambda expressions for processing
    
    void HidePossiblePositions()
    {
        foreach (var item in possiblePositionsGO)
        {
            GameObject.DestroyImmediate(item.gameObject,true);
        }
        

        possiblePositions.RemoveRange(0, possiblePositions.Count);
        possiblePositionsGO.RemoveRange(0, possiblePositionsGO.Count);

    }

    void HidePossibleBuildings()
    {
        List<GameObject> list = new List<GameObject>(possibleBuildingHammer);
        foreach (var item in list)
        {
            DestroyImmediate(item, true);
            possibleBuildingHammer.Remove(item);
        }
        ReportDone();
    }

    void DoInput()
    {
        foreach (var item in space.Buildings)
        {
            if (item.Input.enabled)
            {
                SimpleCords inputLocation = item.CenterLocation.OffsetBy(item.Input.InputLocation);
                if (item.Input.ConsumeToGo>0)
                {
                    Tile t = space.Map.SaveGet(inputLocation.x, inputLocation.z);
                    if (t.occupation == TileOccupation.Material && t.Material.Name == item.Input.MaterialName)
                    {
                        item.Input.ConsumeToGo--;
                        item.Output.ConsumeToGo--;
                        RemoveOccupation(t);
                    }
                }
            }            
        }
        ReportDone();
    }

    void AdvanceTimers()
    {
        foreach (var item in space.Buildings)
        {
            if (item.Input.enabled)
            {
                if (item.Output.ConsumeToGo==0)
                {
                    if (item.Output.TimeToGo==-1)
                    {
                        item.Clock.SetTimer(item.Output.DeliverTimer);
                        item.Output.TimeToGo = item.Output.DeliverTimer;
                    }
                    else
                    {
                        if (item.Output.TimeToGo>0)
                        {
                            item.Output.TimeToGo--;
                            item.Clock.SetTimer(item.Output.TimeToGo);
                        }                        
                    }
                }
            }
            else
            {
                //Debug.Log(item.Output.TimeToGo);
                if (item.Output.TimeToGo == -1)
                {
                    item.Clock.SetTimer(item.Output.DeliverTimer);
                    item.Output.TimeToGo = item.Output.DeliverTimer;
                }
                else
                {
                    if (item.Output.TimeToGo > 0)
                    {
                        item.Output.TimeToGo--;
                        item.Clock.SetTimer(item.Output.TimeToGo);
                    }
                }
            }
        }
        ReportDone();
    }

    void DoOutput()
    {
        foreach (var item in space.Buildings)
        {
            if ((item.Output.ConsumeToGo == 0 && item.Output.TimeToGo==0)|| (!item.Input.enabled && item.Output.TimeToGo == 0))
            {
                //Debug.Log("should do output");
                SimpleCords spawnlocation = item.CenterLocation.OffsetBy(item.Output.DeliveryLocation);
                string materialName = item.Output.MaterialName;
                Tile t = space.Map.SaveGet(spawnlocation.x, spawnlocation.z);
                if (t.occupation == TileOccupation.Empty)
                {
                    BaseMaterial mat = materials.GetMaterialByName(materialName);
                    space.SpawnMaterial(mat, spawnlocation);

                    if (item.Input.enabled)
                    {
                        item.Output.ConsumeToGo = item.Output.ConsumeAmount;
                        item.Input.ConsumeToGo = item.Input.ConsumeAmount;
                        item.Output.TimeToGo = -1;
                    }
                    else
                    {
                        item.Output.TimeToGo = item.Output.DeliverTimer;
                    }
                    item.Clock.SetTimer(item.Output.TimeToGo);
                }
                item.Clock.SetTimer(item.Output.TimeToGo);
            }
            
        }
        ReportDone();
    }

    void ShowPossibleBuildings()
    {
        List<DetectedBuilding> possible = BuildingDetector.DetectBuildings(space, blueprints);
        Debug.Log(possible.Count+" Buildings found");
        foreach (var item in possible)
        {
            if (item != null)
            {
                
                GameObject h = GameObject.Instantiate(ResourceLibrary.GetPrefabByName("prop_Hammer"));
                possibleBuildingHammer.Add(h);
                h.transform.position = item.Location;
                BuildMe script = h.GetComponentInChildren<BuildMe>();
                script.Information = item;
                script.clicker = () =>
                {
                    BuildBuilding(item);
                };
            }            
        }
        ReportDone();
    }

    private void BuildBuilding(DetectedBuilding detectedBuilding)
    {
        BaseBuilding b = buildings.GetBuildingByName(detectedBuilding.BuildingName);        
        foreach (var item in b.occupying)
        {
            SimpleCords cords = detectedBuilding.Location.OffsetBy(item.Rotate(detectedBuilding.Orientation));
            Debug.Log("occupying: "+cords);
            RemoveOccupation(space.Map.SaveGet(cords.x,cords.z));
        }
        space.SpawnBuilding(b, detectedBuilding.Location, detectedBuilding.Orientation);

        AdvanceToProcessing();
    }

    void ShowPossibleDroplocations()
    {
        SimpleCords origin = originLocation;
        GameObject GOo = GameObject.Instantiate(ResourceLibrary.GetPrefabByName("prop_TileHighlightOrigin"));
        GOo.transform.position = origin;
        possiblePositionsGO = new List<GameObject>();
        possiblePositions = new List<SimpleCords>();
        possiblePositionsGO.Add(GOo);
        possiblePositions.Add(origin);

        //TODO: change it to whatever we want
        Offset[] miniOffsets = new Offset[]
        {
            new Offset(1,0),
            new Offset(-1,0),
            new Offset(0,1),
            new Offset(0,-1),
        };

        foreach (var item in miniOffsets)
        {
            SimpleCords pos = origin;
            pos = pos.OffsetBy(item);
            Tile currCheck;
            while ((currCheck = space.Map.SaveGet(pos.x,pos.z)).occupation == TileOccupation.Empty)
            {
                GameObject tmp = GameObject.Instantiate(ResourceLibrary.GetPrefabByName("prop_TileHighlightGood"));
                tmp.transform.position = pos;
                possiblePositions.Add(pos);
                possiblePositionsGO.Add(tmp);
                pos = pos.OffsetBy(item);
            }
        }
    }
}
