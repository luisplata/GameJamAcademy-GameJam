using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnAwakeForSkills : MonoBehaviour
{
    [SerializeField] PlaySoundsInUnity m_PlaySoundsInUnity;
    [SerializeField] AudioSource m_AudioSource;

    private void Awake()
    {
        if(m_PlaySoundsInUnity ==null!)
        {
            m_PlaySoundsInUnity = GameObject.FindObjectOfType<PlaySoundsInUnity>();
        }

        //ServiceLocator.Instance.GetService<PlaySoundsInUnity>().ShotScreamBoss();

        m_AudioSource.PlayOneShot(m_PlaySoundsInUnity.SelectBossSound());
    }
}
