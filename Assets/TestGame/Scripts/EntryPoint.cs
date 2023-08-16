using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private EnemyView[] _enemyViews;

    private PlayerController _playerController;
    private InputController _inputController;
    private EnemyController[] _enemyControllers;
    
    private void Awake()
    {
        _inputController = new InputController();
        _playerController = new PlayerController(_playerView, _inputController);
        _enemyControllers = new EnemyController[_enemyViews.Length];
        InstantiateEnemies();
        Initialization();
    }

    private void Update()
    {
        _inputController.Update();
    }

    private void Initialization()
    {
        _playerView.Initialize();
    }

    private void OnDestroy()
    {
        _playerController.Dispose();
        DisposeEnemies();
        
    }

    private void InstantiateEnemies()
    {
        for (int i = 0; i < _enemyViews.Length; i++) 
        {
            _enemyControllers[i] = new EnemyController(_enemyViews[i], _inputController);
        }
    }
    private void DisposeEnemies()
    {
        for (int i = 0; i < _enemyViews.Length; i++)
        {
            _enemyControllers[i].Dispose();
        }
    }
}
