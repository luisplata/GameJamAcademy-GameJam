using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayFootstepsForCharacters : MonoBehaviour
{
    [SerializeField] PlaySoundsInUnity m_PlaySoundsInUnity;
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioMixerGroup m_Output;
    [Range(0f, 1f)]
    [SerializeField] float m_Volume = 0.5f;
    [SerializeField] float m_VolumeVariation = 0;

    private void Awake()
    {
        if(m_PlaySoundsInUnity == null)
        {
            m_PlaySoundsInUnity = GameObject.FindObjectOfType<PlaySoundsInUnity>();
        }
        if(m_AudioSource == null!)
        {
            m_AudioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        }    
    }

    public void TriggerFootStepSond()
    {
        m_AudioSource.playOnAwake = false;
        m_AudioSource.outputAudioMixerGroup = m_Output;
        m_AudioSource.spatialBlend = 0.5f;
        m_AudioSource.pitch = Random.Range(0.98f, 1.2f);
        m_AudioSource.volume = Random.Range(m_Volume - m_VolumeVariation, m_Volume + m_VolumeVariation);
        m_AudioSource.PlayOneShot(m_PlaySoundsInUnity.SelectFootStepsSounds());

    }
}
