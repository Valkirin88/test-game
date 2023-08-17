using UnityEngine;
using Spine.Unity;
using System.Collections;

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

    public void Dead(Vector3 hitPosition)
    {
        Debug.Log(hitPosition);
        StartCoroutine(Hit(hitPosition));
    }

    private IEnumerator Hit(Vector3 hitPosition)
    {
        yield return new WaitForSeconds(0.6f);
        GameObject deathEffect = Instantiate(_deathEffectPrefab);
        deathEffect.transform.position = hitPosition;
        Destroy(deathEffect,0.3f);
        Destroy(gameObject, 0.3f);
    }
}
