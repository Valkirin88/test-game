using UnityEngine;

public class InputController 
{
    private ShootHandler _shootHandler;
    
    public InputController(ShootHandler shootHandler)
    {
        _shootHandler = shootHandler;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
           _shootHandler.CheckHit();
    }
}
