using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _mainMenuButton;
    [SerializeField]
    private GameObject _restartButtonObject;
    [SerializeField]
    private GameObject _mainMenuButtonObject;
    [SerializeField]
    private TextMeshProUGUI _text;

    private PlayerView _playerView;

    public void Initialize(PlayerView playerView)
    {
        _playerView = playerView;
        _playerView.OnWin += ShowFin;
        _playerView.OnLoose += ShowGameOver;
        _restartButton.onClick.AddListener(Restart);
        _mainMenuButton.onClick.AddListener(ShowMainMenu);
    }

    private void ShowFin()
    {
        _text.text = "Well Done";
        Time.timeScale = 0;
        _restartButtonObject.SetActive(true);
        _mainMenuButtonObject.SetActive(true);
    }

    private void ShowGameOver() 
    {
        _text.text = "Game Over";
        _restartButtonObject.SetActive(true);
        _mainMenuButtonObject.SetActive(true);
    }
    private void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    private void ShowMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        _playerView.OnWin -= ShowFin;
        _playerView.OnLoose -= ShowGameOver;
        _restartButton.onClick.RemoveListener(Restart);
        _mainMenuButton.onClick.RemoveListener(ShowMainMenu);
    }
}
