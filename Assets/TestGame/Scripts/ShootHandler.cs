using UnityEngine;
using System;

public class ShootHandler
{
    public Action OnShoot;
    public void CheckHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject.GetComponent<EnemyView>())
            {
                OnShoot?.Invoke();
                hit.collider.gameObject.GetComponent<EnemyView>().Dead(hit.point);
            }
    }
}

