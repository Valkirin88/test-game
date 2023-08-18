using UnityEngine;
using System;
using System.Collections;

public class ShootHandler
{
    public Action OnShoot;

    [SerializeField]
    private float _rechargeCounter;

    private GameObject _bulletPrefab;
    private PlayerView _playerView;
    private bool _isReadyForShoot;
    
    private float _rechargeTime = 1f;

    public ShootHandler(GameObject bulletPrefab, PlayerView playerView)
    {
        _bulletPrefab = bulletPrefab;
        _playerView = playerView;
        _isReadyForShoot = true;
    }
    public void CheckHit()
    {
        if (_isReadyForShoot && _playerView.IsAlive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if (hit.collider.gameObject.GetComponent<EnemyView>())
                {
                    OnShoot?.Invoke();
                    GameObject bullet = UnityEngine.Object.Instantiate(_bulletPrefab, _playerView.GunTransform.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().Target = hit.point;
                    _isReadyForShoot = false;
                }
            
        }
        
    }

    public void Update()
    {
        if (!_isReadyForShoot)
            _rechargeCounter += Time.deltaTime;
        if(_rechargeCounter >= _rechargeTime && !_isReadyForShoot)
        {
            _rechargeCounter = 0;
            _isReadyForShoot = true;
        }
    }

}

