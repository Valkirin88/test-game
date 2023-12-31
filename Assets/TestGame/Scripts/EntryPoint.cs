using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private EnemyView[] _enemyViews;
    [SerializeField]
    private CanvasController _canvas;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private SoundsData _soundData;

    private PlayerController _playerController;
    private InputController _inputController;
    private ShootHandler _shootHandler;
    private AudioController _audioController;
    
    private void Start()
    {
        _shootHandler = new ShootHandler(_bulletPrefab, _playerView);
        _inputController = new InputController(_shootHandler);
        _playerController = new PlayerController(_playerView, _shootHandler);
        _audioController = new AudioController(_playerView, _soundData, _shootHandler);
        Initialization();
    }

    private void Update()
    {
        _inputController.Update();
        _shootHandler.Update();
    }

    private void Initialization()
    {
        _playerView.Initialize();
        _canvas.Initialize(_playerView);
    }

    private void OnDestroy()
    {
        _playerController.Dispose();
        _audioController.Dispose();
    }
}
