using UnityEngine;

[CreateAssetMenu(fileName ="Data", menuName ="ScriptableObjects/Sounds")]
public class SoundsData : ScriptableObject
{
    [SerializeField]
    private AudioClip _shoot;
    [SerializeField]
    private AudioClip _loose;
    [SerializeField]
    private AudioClip _win;

    public AudioClip Shoot => _shoot;

    public AudioClip Loose => _loose;

    public AudioClip Win => _win; 
}
