
public class EnemyController 
{
    private EnemyView _view;
    private InputController _inputController;

    public EnemyController(EnemyView view, InputController inputController)
    {
        _view = view;
        _inputController = inputController;
        _inputController.OnShoot += _view.Dead;
    }

    public void Dispose()
    {
        _inputController.OnShoot -= _view.Dead;
    }
}
