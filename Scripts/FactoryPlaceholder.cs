using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// class FactoryPlaceholder
/// <para>Used for handling UI BuildMenu factory placeholders</para>
/// <para>And shows factory on tile/cursor when in building mode</para>
/// </summary>
public class FactoryPlaceholder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image backgroundColor;
    private GameObject BuildMenu;
    private Image DarkLayerImage;

    private void Awake() 
    {
        BuildMenu = GameObject.Find("BuildMenu");
        DarkLayerImage = GameObject.Find("DarkLayer").GetComponent<Image>();
    }

    private void Start() 
    {
        backgroundColor = gameObject.GetComponent<Image>();
        backgroundColor.color = new Color(255, 255, 255, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        backgroundColor.color = new Color(255, 255, 255, 0.33f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundColor.color = new Color(255, 255, 255, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Factory factoryInfo = new();

        factoryInfo.GetFactory(name.Replace(" ", "_").ToLower().FirstCharacterToUpper());
        if (GameObject.Find("Money").GetComponent<HandleMoney>().amount < factoryInfo.cost) 
        {
            return;
        }

        backgroundColor.color = new Color(255, 255, 255, 0);

        BuildMenu.SetActive(false);
        DarkLayerImage.color = Color.clear;

        GameObject GridTile = GameObject.Find("Tile");
        GameObject PrefabTilePlaceholder = Resources.Load<GameObject>(name.Replace(" ", "_").ToLower().FirstCharacterToUpper());
        PrefabTilePlaceholder = Instantiate(PrefabTilePlaceholder, GridTile.transform.position, Quaternion.identity);
        PrefabTilePlaceholder.transform.parent = GridTile.transform;
        //PrefabTilePlaceholder.name = "PrefabTilePlaceholder";

        // quick fix, make factory small instead of tile bigger
        PrefabTilePlaceholder.transform.localScale = new Vector3(0.45f / PrefabTilePlaceholder.GetComponent<SpriteRenderer>().bounds.size.x, 0.45f / PrefabTilePlaceholder.GetComponent<SpriteRenderer>().bounds.size.y, 1);
    }
}
