using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundsForItems : MonoBehaviour
{
    [SerializeField] PlaySoundsInUnity m_PlaySounds;
    [SerializeField] AudioSource m_AudioSource;

    [SerializeField] Items m_AttachedItem = new Items();

    private void Awake()
    {
        if(m_AudioSource == null)
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        if(m_PlaySounds == null)
        {
            m_PlaySounds = GameObject.FindObjectOfType<PlaySoundsInUnity>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            switch(m_AttachedItem)
            {
                  case Items.Arcade:
                    if(!m_AudioSource.isPlaying)
                    {
                         m_AudioSource.PlayOneShot(m_PlaySounds.SelectArcadeSound());
                    }
                    break;                     
            }          
        }
    }
}
