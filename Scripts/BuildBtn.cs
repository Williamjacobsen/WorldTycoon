using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// class BuildBtn
/// <para>Changes BuildBtn Icon when pressed</para>
/// </summary>
public class BuildBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite BuildingIcon;
    [SerializeField] private Sprite CancelIcon;
    private Image BtnImage;
    private SpriteRenderer TileColor;

    private void Start() 
    {
        BtnImage = gameObject.GetComponent<Image>();    
        TileColor = GameObject.Find("Tile").GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (BtnImage.sprite.name == "CancelIcon")
        {
            try
            {
                TileColor.color = new Color(255, 255, 255);
                Destroy(GameObject.Find("Tile").transform.GetChild(0).gameObject);
            }
            catch {}
            try
            {
                GameObject.Find("FactoryMenu").SetActive(false);
            }
            catch {}
        }

        if (BtnImage.sprite.name == "BuildingIcon")
        {
            BtnImage.sprite = CancelIcon;

            // sorry for the mess.. :(
            try {GameObject.Find("Tile").transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);} catch {}
            TileColor.color = new Color(255, 0, 0);
        }
        else
        {
            BtnImage.sprite = BuildingIcon;
        }
    }
}
