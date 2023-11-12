using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEthics : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(updateMoney());
    }

    IEnumerator updateMoney()
    {
        HandleEthics handleEthics = gameObject.GetComponent<HandleEthics>();

        while (true)
        {
            handleEthics.ethicsAmount += handleEthics.ethicsChange;
            if (handleEthics.ethicsLevel != (int)(handleEthics.ethicsAmount * 0.004))
            {
                handleEthics.ethicsLevel = (int)(handleEthics.ethicsAmount * 0.004); // 0-7 ethic meter levels
                if (handleEthics.ethicsLevel < 0)
                {
                    handleEthics.ethicsLevel = 0;
                }
                else if (handleEthics.ethicsLevel == 7)
                {
                    Application.Quit();
                    //Debug.Log("YOU LOST....");
                }

                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("EthicMeter/EthicMeter" + handleEthics.ethicsLevel.ToString());
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
