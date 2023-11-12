using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FactoryObject : MonoBehaviour
{
    private Grid grid;
    private float tileOffset;

    private void Awake() 
    {
        grid = GameObject.Find("WorldBuildingGrid").GetComponent<Grid>();    
        tileOffset = grid.cellSize.x / 2;
    }

    private void Start() 
    {
        Vector3Int tilePos = grid.WorldToCell(GetMousePosition());
        gameObject.name = gameObject.name.Replace("(Clone)", "") + tilePos.ToString();

        Factory factory = new();
        factory.GetFactory(gameObject.GetComponent<SpriteRenderer>().sprite.name);

        HandleMoney handleMoney = GameObject.Find("Money").GetComponent<HandleMoney>();
        handleMoney.earn += factory.earn;

        HandleEthics handleEthics = GameObject.Find("EthicMeter").GetComponent<HandleEthics>();
        handleEthics.ethicsChange += factory.ethics;
    }

    private Vector3 GetMousePosition()
    {
        return new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + tileOffset, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + tileOffset, -1);
    }
}
