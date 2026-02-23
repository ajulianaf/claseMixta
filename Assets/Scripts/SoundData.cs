using UnityEngine;

[CreateAssetMenu (menuName = "Audio/Sound Data")]
public class SoundData : ScriptableObject 
{
    public string id;
    public AudioClip clip;
    public float volume=1f;
    public bool loop = false;
    [Range(0f, 1f)] public float spatialBlend = 0f; 
}
