using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;

public class PlayerView : MonoBehaviour
{
    private const string Run = "run";
    private const string Loose = "loose";
    private const string Shoot = "shoot";

    public Action OnLoose;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private SkeletonAnimation _animation;

    [SerializeField]
    private float _speed = 1f;
        
    public void Initialization()
    {
        ShowAnimation(Run); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemies>())
        {
            ShowAnimation(Loose);
            OnLoose?.Invoke();
        }
            
    }
    private void Update()
    {
        _player.transform.position += (new Vector3(1, 0, 0) * _speed * Time.deltaTime);
    }

    public void ShowAnimation(String animation)
    {
        _animation.AnimationName = animation;

    }


 




}
