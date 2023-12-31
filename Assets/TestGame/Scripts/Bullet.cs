using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [HideInInspector]
    public Vector3 Target;
    [SerializeField]
    private float _speed = 10;

    private Vector3 _direction;

    private void Start()
    {
        Destroy(gameObject,3);
        _direction = Target - transform.position;
        _direction.Normalize();
        transform.Rotate(0,0,90);
    }
    private void Update()
    {
        transform.position += Time.deltaTime * _speed * _direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyView>())
            Destroy(gameObject);
    }
}
