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
    public Action OnFinish;

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

    [Header("Audio")]
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private SoundsData _sounds;

    private bool _isAlive;

    public Transform GunTransform => _gunTransform; 

    public void Initialize()
    {
        _isAlive = true;
        Run();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (_isAlive)
        {
            if (collision.GetComponent<EnemyView>())
            {
                Loose();
            }
            if (collision.GetComponent<Finish>())
            {
                Finish();
            }
        }
    }
    private void Update()
    {
        transform.position = transform.position + new Vector3(1, 0, 0) * _speed * Time.deltaTime;
        
    }

    private void Run()
    {
        _animation.AnimationState.SetAnimation(0, RunAnimationName, true);
        
    }
    public void Loose()
    {
        _isAlive = false;
        _animation.AnimationState.SetAnimation(0, LooseAnimationName, false);
        PlayClip(_sounds.Loose);
        OnLoose?.Invoke();
        _speed = 0;
    }

    public void Shoot()
    {
        if (_isAlive)
        {
            _animation.AnimationState.SetAnimation(1, ShootAnimationName, false);
            _animation.AnimationState.AddAnimation(1, RunAnimationName, true, 1);
            PlayClip(_sounds.Shoot);
            GameObject explosionEffect = Instantiate(_explosionPrefab, GunTransform);
            Destroy(explosionEffect, 2);
            Recoil();
        }
    }

    private void Recoil()
    {
        transform.DOMoveX(transform.position.x - 0.5f, 0.5f);
    }

    private void PlayClip(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    private void Finish()
    {
        OnFinish?.Invoke();
    }

}
