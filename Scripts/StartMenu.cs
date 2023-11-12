using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    private GameObject _start;
    private GameObject _tutorial;
    private GameObject _tutorialText;
    private GameObject _quitOrBack;

    private void Start() 
    {
        _start = GameObject.Find("Start");
        _tutorial = GameObject.Find("HowToPlay");
        _tutorialText = GameObject.Find("HowToPlayText");
        _tutorialText.SetActive(false);
        _quitOrBack = GameObject.Find("Quit");    
    }

    public void _Start()
    {
        SceneManager.LoadScene("Main");
    }

    public void Tutorial()
    {
        _start.SetActive(false);
        _tutorial.SetActive(false);
        _tutorialText.SetActive(true);
        _quitOrBack.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Back";
    }

    public void QuitOrBack()
    {
        if (_start.activeSelf)
        {
            Application.Quit();
            return;
        }

         _start.SetActive(true);
        _tutorial.SetActive(true);
        _tutorialText.SetActive(false);
        _quitOrBack.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Quit";
    }
}
