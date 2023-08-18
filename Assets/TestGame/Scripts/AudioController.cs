using UnityEngine;

public class AudioController 
{
    private PlayerView _playerView;
    private SoundsData _soundsData;
    private ShootHandler _shootHandler;
    private AudioSource _audioSource;

    public AudioController(PlayerView playerView, SoundsData soundsData, ShootHandler shootHandler)
    {
        _playerView = playerView;
        _soundsData = soundsData;
        _shootHandler = shootHandler;
        _audioSource = _playerView.GetComponent<AudioSource>();
        _playerView.OnWin += PlayWin;
        _playerView.OnLoose += PlayLoose;
        _shootHandler.OnShoot += PlayShoot;
    }

    private void PlayWin()
    {
        _audioSource.clip = _soundsData.Win;
        _audioSource.Play();
    }

    private void PlayLoose()
    {
        _audioSource.clip = _soundsData.Loose;
        _audioSource.Play();
    }

    private void PlayShoot()
    {
        _audioSource.clip = _soundsData.Shoot;
        _audioSource.Play();
    }

    public void Dispose()
    {
        _playerView.OnWin -= PlayWin;
        _playerView.OnLoose -= PlayLoose;
        _shootHandler.OnShoot -= PlayShoot;
    }
}
