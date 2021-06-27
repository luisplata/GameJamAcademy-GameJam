using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundsInUnity : MonoBehaviour, ITriggerSoundEffect, ISoundBossScream
{
    [SerializeField] AudioSource m_AudioSource;

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

    public void ShotScreamBoss()
    {
        List<AudioClip> boss = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("GJA_NPC_BossScreams[001]"))
            {
                boss.Add(clip);
            }
        }
        var random = Random.Range(0, boss.Count);
        PlayShortSoundOnce(boss[random].name);
    }

    public void PlayHoverMouseSounds()
    {
        List<AudioClip> mouseHover = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("GJA_Gui_MouseHover"))
            {
                mouseHover.Add(clip);
            }
        }
        var random = Random.Range(0, mouseHover.Count);
        PlayShortSoundOnce(mouseHover[random].name);
    }

    public void PlayMouseClickSounds()
    {
        List<AudioClip> mouseClick = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("GJA_GUI_MouseClick"))
            {
                mouseClick.Add(clip);
            }
        }
        var random = Random.Range(0, mouseClick.Count);
        PlayShortSoundOnce(mouseClick[random].name);
    }

    public void PlayFootStepsSounds()
    {
        List<AudioClip> footStep = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("FS_Retro_Wood"))
            {
                footStep.Add(clip);
            }
        }
        var random = Random.Range(0, footStep.Count);
        PlayShortSoundOnce(footStep[random].name);
    }


    public AudioClip SelectArcadeSound()
    {
        List<AudioClip> arcadeSound = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("GJA_ITEMS_Arcade"))
            {
                arcadeSound.Add(clip);
            }
        }
        var random = Random.Range(0, arcadeSound.Count);

        return arcadeSound[random];
    }
    public void PlayAmbientSound()
    {
        throw new System.NotImplementedException();
    }
}
