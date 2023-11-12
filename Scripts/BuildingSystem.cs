using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Class BuildingSystem
/// <para>Shows white tile where mouse is.</para>
/// <para>If in building mode, it shows green or red tile and sprite -</para>
/// <para>based on if it's placeable.</para>
/// <para>And then spawns a factory.</para>
/// </summary>
public class BuildingSystem : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private GameObject tile;
    [SerializeField] private Grid grid;
    private float tileOffset;
    private GameObject BuildMenu;
    private GameObject FactoryMenu;

    private void Awake() 
    {
        FactoryMenu = GameObject.Find("FactoryMenu");
        BuildMenu = GameObject.Find("BuildMenu");
    }

    private void Start() 
    {
        cam = Camera.main;
        tileOffset = grid.GetComponent<Grid>().cellSize.x / 2;

        FactoryMenu.SetActive(false);
    }
    
    private void Update() 
    {
        SpawnFactoryListener();
        HandleTilePlaceholder();
        OnClickFactory();
    }

    private void SpawnFactoryListener()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // is not in factory build mode?
            if (tile.transform.childCount == 0) {return;}
            
            Factory factoryInfo = new();
            // kinda ugly but makes "Gold Mine(Clone)" => "Gold_mine"
            factoryInfo.GetFactory(tile.transform.GetChild(0).gameObject.name.Replace("(Clone)", "").Replace(" ", "_").ToLower().FirstCharacterToUpper());
            
            if (GameObject.Find("Money").GetComponent<HandleMoney>().amount < factoryInfo.cost) {return;}

            Vector2 tilePos = cam.WorldToScreenPoint(grid.CellToWorld(grid.WorldToCell(GetMousePosition())));
            if (!IsPlaceable(tilePos)) {return;}

            GameObject FactoryObjectPrefab = Resources.Load<GameObject>(tile.transform.GetChild(0).gameObject.name.Replace("(Clone)", "").Replace(" ", "_").ToLower().FirstCharacterToUpper() + "_factory");

            GameObject factory = Instantiate(FactoryObjectPrefab, grid.CellToWorld(grid.WorldToCell(GetMousePosition())), Quaternion.identity);
            factory.transform.localScale = new Vector3(factory.transform.localScale.x * 0.9f, factory.transform.localScale.y * 0.9f, factory.transform.localScale.z);
            factory.transform.parent = grid.transform;

            GameObject.Find("Money").GetComponent<HandleMoney>().amount -= factoryInfo.cost;
        }
    }

    private Vector3Int PrevGridPosition = new(0, 0, 0);
    private void HandleTilePlaceholder()
    {
        Vector3Int gridPosition = grid.WorldToCell(GetMousePosition());

        // have mouse/tile position not changed?
        if (PrevGridPosition == gridPosition) {return;}
        PrevGridPosition = gridPosition;

        tile.transform.position = grid.CellToWorld(gridPosition);

        // is not in factory build mode?
        if (tile.transform.childCount == 0) {return;}

        Vector2 tilePos = cam.WorldToScreenPoint(grid.CellToWorld(gridPosition));

        if (IsPlaceable(tilePos))
        {
            tile.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            tile.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else
        {
            tile.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            tile.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
    }

    private bool IsPlaceable(Vector2 tilePos)
    {
        // bad solution
        // should shoot raycast from each corner
        // instead of only shooting one
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(tilePos), Vector2.zero);
        
        bool North_America_Sea = false;
        bool North_America_Land = false;
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.name.Replace("factory", "") != hit.collider.gameObject.name) {return false;}

            switch (hit.collider.gameObject.name)
            {
                case "North_America_Sea":
                    North_America_Sea = true;
                    break;
                case "North_America_Land":
                    North_America_Land = true;
                    break;

            }
        }
        
        Factory factory = new();
        // kinda ugly but makes "Gold Mine(Clone)" => "Gold_mine"
        factory.GetFactory(tile.transform.GetChild(0).gameObject.name.Replace("(Clone)", "").Replace(" ", "_").ToLower().FirstCharacterToUpper());

        if (
            North_America_Land && factory.placeableArea == "Land" 
            || 
            North_America_Sea && factory.placeableArea == "Sea"
            )
        {
            return true;
        }
        return false;
    }

    [SerializeField] private Sprite CancelIcon;
    private void OnClickFactory()
    {
        if (tile.transform.childCount != 0) {return;}
        if (!Input.GetMouseButtonDown(0)) {return;}
        if (BuildMenu.activeSelf) {return;}

        Vector2 tilePos = cam.WorldToScreenPoint(grid.CellToWorld(grid.WorldToCell(GetMousePosition())));

        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(tilePos), Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.name.Replace("factory", "") != hit.collider.gameObject.name) 
            {
                GameObject.Find("BuildBtn").GetComponent<Image>().sprite = CancelIcon;
                GameObject.Find("DarkLayer").GetComponent<Image>().color = new Color(0, 0, 0, 0.33f);
                FactoryMenu.SetActive(true);
                FactoryMenu.GetComponent<FactoryMenu>().HideAll();

                string pattern = @"^([A-Za-z_]+)_factory";
                Match match = Regex.Match(hit.collider.gameObject.name, pattern);
                switch (match.Groups[1].Value)
                {
                    case "Gold_mine":
                        FactoryMenu.GetComponent<FactoryMenu>().Gold_mine.SetActive(true);
                        break;
                    case "Gold_forge":
                        FactoryMenu.GetComponent<FactoryMenu>().Gold_forge.SetActive(true);
                        break;
                    case "Gold_store":
                        FactoryMenu.GetComponent<FactoryMenu>().Gold_store.SetActive(true);
                        break;
                    case "Oil_platform":
                        FactoryMenu.GetComponent<FactoryMenu>().Oil_platform.SetActive(true);
                        break;
                    case "Windmill":
                        FactoryMenu.GetComponent<FactoryMenu>().Windmill.SetActive(true);
                        break;
                }

                GameObject.Find("Sell").GetComponent<SellBtn>().tilePos = grid.WorldToCell(GetMousePosition());
            }
        }
    }

    private Vector3 GetMousePosition()
    {
        return new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x + tileOffset, cam.ScreenToWorldPoint(Input.mousePosition).y + tileOffset, -1);
    }
}
