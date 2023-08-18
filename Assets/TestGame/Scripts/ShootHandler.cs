using UnityEngine;
using System;

public class ShootHandler
{
    public Action OnShoot;

    private GameObject _bulletPrefab;
    private PlayerView _playerView;

    public ShootHandler(GameObject bulletPrefab, PlayerView playerView)
    {
        _bulletPrefab = bulletPrefab;
        _playerView = playerView;
    }
    public void CheckHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject.GetComponent<EnemyView>())
            {
                OnShoot?.Invoke();
                GameObject bullet = UnityEngine.Object.Instantiate(_bulletPrefab, _playerView.GunTransform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().Target = hit.point;
            }
    }
}

