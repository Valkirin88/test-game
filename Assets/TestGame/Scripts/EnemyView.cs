using UnityEngine;
using Spine.Unity;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private SkeletonAnimation _animation;
    [SerializeField]
    private SoundsData _sound;
    [SerializeField]
    private GameObject _deathEffectPrefab;

    private void Update()
    {
        transform.position += new Vector3(-1,0,0) * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
            Dead(other.transform.position);
    }

    public void Dead(Vector3 hitPosition)
    {
        GameObject deathEffect = Instantiate(_deathEffectPrefab);
        deathEffect.transform.position = hitPosition;
        Destroy(deathEffect, 0.3f);
        Destroy(gameObject);
    }
}
