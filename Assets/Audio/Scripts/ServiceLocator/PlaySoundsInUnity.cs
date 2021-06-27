using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundsInUnity : MonoBehaviour, ITriggerSoundEffect, ISoundBossScream, IUiSound
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

    #region 2DSounds
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
    public void PlayPossitiveQuote()
    {
        List<AudioClip> quote = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("GJA_NPC_AllySupport"))
            {
                quote.Add(clip);
            }
        }
        var random = Random.Range(0, quote.Count);
        PlayShortSoundOnce(quote[random].name);
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
    #endregion

    #region 3DSounds
    public AudioClip SelectFootStepsSounds()
    {
        List<AudioClip> footStepSound = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("FS_Retro_Wood"))
            {
                footStepSound.Add(clip);
            }
        }
        var random = Random.Range(0, footStepSound.Count);

        return footStepSound[random];
    }
    public AudioClip SelectGruntSounds()
    {
        List<AudioClip> grunt = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("GJA_NPC_Grunts[001]"))
            {
                grunt.Add(clip);
            }
        }
        var random = Random.Range(0, grunt.Count);

        return grunt[random];
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
    public AudioClip SelectPaperSound()
    {
        List<AudioClip> paper = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("GJA_ITEMS_Arcade"))
            {
                paper.Add(clip);
            }
        }
        var random = Random.Range(0, paper.Count);

        return paper[random];
    }
    public AudioClip SelectProjectileSound()
    {
        List<AudioClip> projectileSounds = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("Flame"))
            {
                projectileSounds.Add(clip);
            }
        }
        var random = Random.Range(0, projectileSounds.Count);

        return projectileSounds[random];
    }
    public AudioClip SelectBossSound()
    {
        List<AudioClip> bossScream = new List<AudioClip>();
        foreach (var clip in m_SoundsToPlay)
        {
            if (clip.name.Contains("GJA_NPC_BossScreams[001]"))
            {
                bossScream.Add(clip);
            }
        }
        var random = Random.Range(0, bossScream.Count);

        return bossScream[random];
    }
    #endregion

}