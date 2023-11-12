using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleEthics : MonoBehaviour
{
    public int ethicsLevel;
    public float ethicsChange;
    public float ethicsAmount;

    private void Awake() 
    {
        ethicsLevel = 0;
        ethicsChange = 0f;
        ethicsAmount = 0f;
    }
}
