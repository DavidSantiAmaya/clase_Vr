using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;


public class AudioManager : MonoBehaviour, IaudioManager
{    
    public static AudioManager Instance {  get; private set; }

    [SerializeField] private List<SoundData> sounds;

    private Dictionary<string, SoundData> soundDictionary;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        soundDictionary = new Dictionary<string, SoundData>();

        foreach (var sound in sounds)
        {
            soundDictionary.Add(sound.id, sound);
        }
    }

    public void Play2D(string soundID)
    {
        if (!soundDictionary.TryGetValue(soundID, out var sound))
            return;
        Play(sound, Vector3.zero, false);
    }

    public void Play3D(string soundID,Vector3 position)
    {
        if (!soundDictionary.TryGetValue(soundID, out var sound))
            return;
        Play(sound, position, false);
    }

    private void Play(SoundData sound , Vector3 position, bool is3D)
    {
        GameObject go = new GameObject("Audio_"+ sound.id);
        go.transform.position = position;

        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = sound.clip;
        source.volume = sound.volume;
        source.loop = sound.loop;
        source.spatialBlend = is3D ? 1f : 0f;

        source.Play();

        if(!sound.loop)
            Destroy(go, sound.clip.length);
    }

    public void Upda3D(string id, Vector3 location)
    {
        throw new System.NotImplementedException();
    }
}


public interface IaudioManager
{
    void Play2D(string id);
    void Upda3D(string id, Vector3 location);

}
