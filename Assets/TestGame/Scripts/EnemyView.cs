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
    private GameObject _deathObject;

    [SerializeField]
    private Transform _hitTransform;

    private void Update()
    {
        transform.position += new Vector3(-1,0,0) * Time.deltaTime * _speed;
    }

    public void Dead(Vector3 hitPosition)
    {
        Debug.Log(hitPosition);
        _hitTransform.position = hitPosition;
        StartCoroutine(Hit());
    }

    private IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.6f);
        Instantiate(_deathObject, _hitTransform);
        Destroy(gameObject, 0.3f);
    }
}
