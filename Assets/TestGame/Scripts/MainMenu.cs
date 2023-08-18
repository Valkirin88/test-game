using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _startGameButton;

    private void Start()
    {
        _startGameButton.onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    private void OnDestroy()
    {
        _startGameButton.onClick.RemoveListener(LoadGame);
    }
}
