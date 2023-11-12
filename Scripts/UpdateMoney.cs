using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateMoney : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(updateMoney());
    }

    IEnumerator updateMoney()
    {
        HandleMoney handleMoney = gameObject.GetComponent<HandleMoney>();
        TextMeshProUGUI counter = gameObject.GetComponent<TextMeshProUGUI>();

        while (true)
        {
            handleMoney.amount += handleMoney.earn/5;
            handleMoney.amount = (float)Math.Round(handleMoney.amount, 2);
            counter.text = handleMoney.amount.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
