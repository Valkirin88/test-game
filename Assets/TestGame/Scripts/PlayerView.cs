using UnityEngine;
using Spine.Unity;
using System;
using DG.Tweening;

public class PlayerView : MonoBehaviour
{
    private const string RunAnimationName = "run";
    private const string LooseAnimationName = "loose";
    private const string ShootAnimationName = "shoot";

    public Action OnLoose;
    public Action OnWin;

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private SkeletonAnimation _animation;
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private Transform _gunTransform;
    [SerializeField]
    private GameObject _explosionPrefab;

    private bool _isAlive;

    public Transform GunTransform => _gunTransform;

    public bool IsAlive  => _isAlive; 

    public void Initialize()
    {
        _isAlive = true;
        Run();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (IsAlive)
        {
            if (collision.GetComponent<EnemyView>())
            {
                Loose();
            }
            if (collision.GetComponent<Finish>())
            {
                Win();
            }
        }
    }
    private void Update()
    {
        transform.position = transform.position + _speed * Time.deltaTime * new Vector3(1, 0, 0);
    }

    private void Run()
    {
        _animation.AnimationState.SetAnimation(0, RunAnimationName, true);
    }
    public void Loose()
    {
        _isAlive = false;
        _animation.ClearState();
        _animation.AnimationState.SetAnimation(0, LooseAnimationName, false);
        OnLoose?.Invoke();
        _speed = 0;
    }

    public void Shoot()
    {
        if (IsAlive)
        {
            _animation.AnimationState.SetAnimation(1, ShootAnimationName, false);
            _animation.AnimationState.AddAnimation(1, RunAnimationName, true, 1);
            GameObject explosionEffect = Instantiate(_explosionPrefab, GunTransform);
            Destroy(explosionEffect, 2);
            Recoil();
        }
    }

    private void Recoil()
    {
        transform.DOMoveX(transform.position.x - 0.5f, 0.5f);
    }
    private void Win()
    {
        OnWin?.Invoke();
    }
}
