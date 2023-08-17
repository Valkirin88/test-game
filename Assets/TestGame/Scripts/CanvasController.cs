using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour
{
    //[SerializeField]
    //private GameObject _finScreen;

    //[SerializeField]
    //private GameObject _gameOverScreen;

    //[SerializeField]
    //private Button _restartButton;

    [SerializeField]
    private TextMeshProUGUI _text;

    private PlayerView _playerView;

    public void Initialize(PlayerView playerView)
    {
        _playerView = playerView;
        //_playerView.OnFinish += ShowFin;
        //_playerView.OnLoose += ShowGameOver;
        // _restartButton.onClick.AddListener(Restart);
        _text.text = "Game Over";
    }

    private void ShowFin()
    {
        //_finScreen.SetActive(true);
    }

    private void ShowGameOver() 
    {
        //_gameOverScreen.SetActive(true);
    }
    private void Restart()
    {

    }
    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        _playerView.OnFinish -= ShowFin;
        _playerView.OnLoose -= ShowGameOver;
        //_restartButton.onClick.RemoveListener(Restart);
    }
}
