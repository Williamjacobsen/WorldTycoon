using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMoney : MonoBehaviour
{
    public float amount;
    public float earn;

    private void Awake() 
    {
        amount = 400;
        earn = 0;
    }
}
