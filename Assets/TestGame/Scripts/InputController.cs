using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController 
{
    public Action<Vector3> OnShoot;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if (hit.collider.gameObject.GetComponent<Enemies>())
                    OnShoot?.Invoke(Input.mousePosition);
        }
    }
}