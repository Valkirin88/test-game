using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private const string Shoot = "shoot";
    private PlayerView _view;
    private ShootHandler _shootHandler;
    public PlayerController(PlayerView view, ShootHandler shootHandler)
    {
        _view = view;
        _shootHandler = shootHandler;
        _shootHandler.OnShoot += _view.Shoot;
    }

    public void Dispose()
    {
        _shootHandler.OnShoot -= _view.Shoot;
    }

}
