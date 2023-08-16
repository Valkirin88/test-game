using System;
using UnityEngine;

public class InputController 
{
    public Action OnShoot;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if (hit.collider.gameObject.GetComponent<EnemyView>())
                    OnShoot?.Invoke();
        }
    }
}
