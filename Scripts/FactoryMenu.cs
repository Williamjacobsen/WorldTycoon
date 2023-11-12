using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMenu : MonoBehaviour
{
    public GameObject Gold_mine;
    public GameObject Gold_forge;
    public GameObject Gold_store;
    public GameObject Oil_platform;
    public GameObject Windmill;

    private void Awake() 
    {
        Gold_mine = gameObject.transform.GetChild(0).gameObject;
        Gold_forge = gameObject.transform.GetChild(1).gameObject;
        Gold_store = gameObject.transform.GetChild(2).gameObject;
        Oil_platform = gameObject.transform.GetChild(3).gameObject;
        Windmill = gameObject.transform.GetChild(4).gameObject;
    }

    private void Start() 
    {
        HideAll();
    }

    public void HideAll()
    {
        Gold_mine.SetActive(false);
        Gold_forge.SetActive(false);
        Gold_store.SetActive(false);
        Oil_platform.SetActive(false);
        Windmill.SetActive(false);
    }
}
