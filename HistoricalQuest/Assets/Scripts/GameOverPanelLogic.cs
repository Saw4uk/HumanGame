using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelLogic : MonoBehaviour
{
    [SerializeField] private Button ExitButton;

    [SerializeField] private Button RestartButton;

    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Awake()
    {
        ExitButton.onClick.AddListener(OnExitButtonClick);
        RestartButton.onClick.AddListener(OnRestartButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawExit(string str)
    {
        text.text = str;
    }
    
    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnRestartButtonClick()
    {
        Victorina.SetDefaults();
        SceneManager.LoadScene("SampleScene");
    }
}
