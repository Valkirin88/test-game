using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private const string Shoot = "shoot";
    private PlayerView _view;
    private InputController _inputController;
    public PlayerController(PlayerView view, InputController inputController)
    {
        _view = view;
        _inputController = inputController;
        _inputController.OnShoot += PlayerShoot;
    }

    private void PlayerShoot(Vector3 target)
    {
        _view.ShowAnimation(Shoot);

    }
}
