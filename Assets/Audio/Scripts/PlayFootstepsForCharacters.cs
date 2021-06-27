using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepsForCharacters : MonoBehaviour
{
    [SerializeField] PlaySoundsInUnity m_PlaySoundsInUnity;
    [SerializeField] AudioSource m_AudioSource;

    private void Awake()
    {
        if(m_PlaySoundsInUnity == null)
        {
            m_PlaySoundsInUnity = GameObject.FindObjectOfType<PlaySoundsInUnity>();
        }
    }

    public void TriggerFootStepSond()
    {
        
    }
}
