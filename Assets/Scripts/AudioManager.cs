using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IaudioManager
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private List<SoundData> sounds;

    private Dictionary<string, SoundData> SoundDictionary;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad (gameObject);
        SoundDictionary = new Dictionary<string, SoundData> ();

        foreach (var sound in sounds)
        {
            SoundDictionary.Add (sound.id, sound);
        }
    }

    public void Play2D(string soundID)
    {
        if (!SoundDictionary.TryGetValue(soundID, out var sound))
            return;

        Play(sound, Vector3.zero, false);
    }

    public void Play3D(string soundID, Vector3 position)
    {
        if (!SoundDictionary.TryGetValue(soundID, out var sound))
            return;

        Play(sound, position, true);
    }

    private void Play(SoundData sound, Vector3 position, bool is3D)
    {
        GameObject go = new GameObject( "Audio_" + sound.id );
        go.transform.position = position;

        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = sound.clip;
        source.volume = sound.volume;
        source.loop = sound.loop;
        source.spatialBlend = is3D ? 1f : 0f;

        source.Play();

        if (!sound.loop)
            Destroy(go, sound.clip.length);
    }
}

public interface IaudioManager
{
    void Play2D(string id);

    void Play3D(string id, Vector3 location);
}
