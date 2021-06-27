using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCharacterSounds : MonoBehaviour
{
    [SerializeField] List<AudioClip> m_Footsteps;
    [SerializeField] AudioSource m_AudioSource;

    [Range(0f, 0.3f)]
    [SerializeField] float m_PitchVariation = 0;

    public void PlayFootSteps()
    {
        AudioClip currentClip = m_Footsteps[Random.Range(0, m_Footsteps.Count)];
        m_AudioSource.pitch = Random.Range(1f - m_PitchVariation, 1f + m_PitchVariation);
        m_AudioSource.PlayOneShot(currentClip);
    }
}
