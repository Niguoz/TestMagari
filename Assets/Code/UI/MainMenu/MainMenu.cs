using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button _playButton;
    private Button _optionsButton;
    private Button _exitButton;

    private void Awake()
    {
        _playButton = transform.Find("New Game").GetComponent<Button>();
        _optionsButton = transform.Find("Options").GetComponent<Button>();
        _exitButton = transform.Find("Exit").GetComponent<Button>();

        _playButton.onClick.AddListener(StartGame);
        _optionsButton.onClick.AddListener(Options);
        _exitButton.onClick.AddListener(QuitGame);
    }


    private void StartGame()
    {
        Debug.Log("Start");
    }

    private void Options()
    {
        Debug.Log("Options");
    }

    private void QuitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
