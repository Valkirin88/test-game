using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [HideInInspector]
    public Vector3 Target;

    [SerializeField]
    private float _speed = 10;


    private void Start()
    {
        Destroy(gameObject,5);
    }
    private void Update()
    {
        transform.position +=  new Vector3(Target.x, Target.y, Target.z) * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyView>())
            Destroy(gameObject);
    }
}
