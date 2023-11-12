using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// class InteractiveUI
/// <para>Run when BuildBtn is pressed</para>
/// <para>Shows BuildMenu</para>
/// </summary>
public class InteractiveUI : MonoBehaviour, IPointerClickHandler
{
    // todo: make buildbtn only switch on/off state, and interactiveUI on canvas instead

    private bool UIState = false;
    [SerializeField] private GameObject DarkLayer;
    private Image DarkLayerImage;
    [SerializeField] private GameObject BuildMenu;

    private void Start()
    {
        DarkLayerImage = DarkLayer.GetComponent<Image>();
        BuildMenu.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIState = !BuildMenu.activeSelf;
        try 
        {
            if (GameObject.Find("FactoryMenu").activeSelf)
            {
                UIState = !UIState;
            }
        }
        catch {}
        SwitchDarkLayer();
    }

    private void SwitchDarkLayer()
    {
        if (GameObject.Find("Tile").transform.childCount != 0)
        {
            return;
        }

        if (UIState)
        {
            DarkLayerImage.color = new Color(0, 0, 0, 0.33f);
            BuildMenu.SetActive(true);
        }
        else
        {
            DarkLayerImage.color = Color.clear;
            BuildMenu.SetActive(false);
        }
    }
}