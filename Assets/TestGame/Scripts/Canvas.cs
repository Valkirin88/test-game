using System;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField]
    private GameObject _finScreen;

    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private Button _restartButton;

    private PlayerView _playerView;
    public void Initialize(PlayerView playerView)
    {
        _playerView = playerView;
        _playerView.OnFinish += ShowFin;
        _restartButton.onClick.AddListener(Restart);
    }

    private void ShowFin()
    {
        _finScreen.SetActive(true);
    }
    private void Restart()
    {

    }

    private void OnDestroy()
    {
        _playerView.OnFinish -= ShowFin;
        _restartButton.onClick.RemoveListener(Restart);
    }
}
