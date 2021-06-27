using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepsForCharacters : MonoBehaviour
{
    [SerializeField] PlaySoundsInUnity m_PlaySoundsInUnity;

    private void Awake()
    {
        if(m_PlaySoundsInUnity == null)
        {
            m_PlaySoundsInUnity = GetComponent<PlaySoundsInUnity>();
        }
    }

    public void TriggerFootStepSond()
    {
        m_PlaySoundsInUnity.PlayFootStepsSounds();
    }
}
