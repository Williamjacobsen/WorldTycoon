using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Region : MonoBehaviour
{
    private string[] RegionsUnlocked;
    private void Awake()
    {
        GameObject.Find("North_America_Overlap").SetActive(false);


        //RegionsUnlocked = new JSONReader().GetProgress().RegionsUnlocked;

        //foreach (string region in RegionsUnlocked)
        //{
        //    GameObject.Find(region.Replace(" ", "_") + "_Overlap").SetActive(false);
        //}
    }
}
