using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SellBtn : MonoBehaviour, IPointerClickHandler
{
    private GameObject grid;
    public Vector3Int tilePos;
    [SerializeField] Sprite BuildingIcon;

    private void Awake() 
    {
        grid = GameObject.Find("WorldBuildingGrid");    
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Factory factory = new();
        factory.GetFactory(gameObject.transform.parent.name);

        string pattern = @"\(([^)]*)\)";
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            Match match = Regex.Match(grid.transform.GetChild(i).name, pattern);
            string content = match.Groups[1].Value;
            string[] values = content.Split(',');
            int x = int.Parse(values[0]);
            int y = int.Parse(values[1]);
            int z = int.Parse(values[2]);

            if (new Vector3(x, y, z) == tilePos)
            {
                Destroy(grid.transform.GetChild(i).gameObject);

                GameObject.Find("Money").GetComponent<HandleMoney>().amount += factory.cost / 2;
                GameObject.Find("Money").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Money").GetComponent<HandleMoney>().amount.ToString();
                
                GameObject.Find("BuildBtn").GetComponent<Image>().sprite = BuildingIcon;
                GameObject.Find("DarkLayer").GetComponent<Image>().color = new Color(0, 0, 0, 0);
                GameObject.Find("FactoryMenu").SetActive(false);

                break;
            }
        }
    }
}
