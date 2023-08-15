using UnityEngine;

[CreateAssetMenu(fileName ="Data", menuName ="ScriptableObjects/Sounds")]
public class SoundsData : ScriptableObject
{
    [SerializeField]
    private AudioClip _shoot;

    [SerializeField]
    private AudioClip _loose;

    public AudioClip Shoot => _shoot;

    public AudioClip Loose => _loose; 
}
