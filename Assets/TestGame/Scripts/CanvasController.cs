using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{

    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private GameObject _restartButtonObject;

    [SerializeField]
    private TextMeshProUGUI _text;

    private PlayerView _playerView;

    public void Initialize(PlayerView playerView)
    {
        _playerView = playerView;
        _playerView.OnFinish += ShowFin;
        _playerView.OnLoose += ShowGameOver;
        _restartButton.onClick.AddListener(Restart);
    }

    private void ShowFin()
    {
        _text.text = "Well Done";
    }

    private void ShowGameOver() 
    {
        _text.text = "Game Over";
        _restartButtonObject.SetActive(true);
    }
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        _playerView.OnFinish -= ShowFin;
        _playerView.OnLoose -= ShowGameOver;
        _restartButton.onClick.RemoveListener(Restart);
    }
}
