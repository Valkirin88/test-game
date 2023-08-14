using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView;

    private PlayerController _playerController;
    private InputController _inputController;
    private void Awake()
    {
        _inputController = new InputController();
        _playerController = new PlayerController(_playerView, _inputController);
        Initialization();
    }

    private void Update()
    {
        _inputController.Update();
    }

    private void Initialization()
    {
        _playerView.Initialization();
    }

}
