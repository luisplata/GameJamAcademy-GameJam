using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundsInUnity : MonoBehaviour, ITriggerSoundEffect
{
    [SerializeField] AudioSource m_AudioSource;

    [SerializeField] AudioSource m_AudioSourceAmbientDay;
    [SerializeField] AudioSource m_AudioSourceAmbientNight;

    
    [SerializeField] AudioMixerSnapshot M_SnapShotDay;
    [SerializeField] AudioMixerSnapshot M_SnapShotNight;

    [SerializeField] List<AudioClip> m_SoundsToPlay;

    Dictionary<string, AudioClip> m_SoundDictionary;

    private void Awake()
    {
        m_SoundDictionary = new Dictionary<string, AudioClip>();

        foreach (var audio in m_SoundsToPlay)
        {
            m_SoundDictionary.Add(audio.name, audio);
        }
    }

    public void PlayShortSoundOnce(string audioClip)
    {
        m_AudioSource.PlayOneShot(FindAudioClipByName(audioClip));
    }


    private AudioClip FindAudioClipByName(string audioClipName)
    {

        m_SoundDictionary.TryGetValue(audioClipName, out var foundSound);

        return foundSound;  
    }

    public void PlayAmbientSound()
    {
        m_AudioSourceAmbientDay.clip = FindAudioClipByName("AmbienceBase");
        m_AudioSourceAmbientDay.loop = true;
        M_SnapShotDay.TransitionTo(1f);
        m_AudioSourceAmbientDay.Play();
    }
}
