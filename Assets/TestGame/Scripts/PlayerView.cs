using UnityEngine;
using Spine.Unity;
using System;

public class PlayerView : MonoBehaviour
{
    private const string Run = "run";
    private const string Loose = "loose";
    private const string Shoot = "shoot";

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
    private GameObject _explosion;

    [Header("Audio")]
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private SoundsData _sounds;

    public void Initialize()
    {
        ShowRun();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<EnemyView>())
        {
            ShowLoose();
        }
        if (collision.GetComponent<Finish>())
        {
            ShowFinish();
        }
            
    }
    private void Update()
    {
        _player.transform.position += (new Vector3(1, 0, 0) * _speed * Time.deltaTime);
    }

    private void ShowRun()
    {
        _animation.AnimationState.SetAnimation(0, Run, true);
        
    }
    public void ShowLoose()
    {
        _animation.AnimationState.SetAnimation(0, Loose, false);
        PlayClip(_sounds.Loose);
        OnLoose?.Invoke();
    }

    public void ShowShoot()
    {
        _animation.AnimationState.SetAnimation(1, Shoot, false);
        _animation.AnimationState.AddAnimation(1, Run, true, 1);
        PlayClip(_sounds.Shoot);
        Instantiate(_explosion, _gunTransform);
        Destroy(_explosion, 2);
    }

    private void PlayClip(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    private void ShowFinish()
    {
        OnFinish?.Invoke();
    }

}
