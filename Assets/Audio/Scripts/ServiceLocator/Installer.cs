using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Audio
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] PlaySoundsInUnity m_PlaySoundsInUnity;

        private void Awake()
        {
            if (FindObjectsOfType<Installer>().Length >= 2)
            {
                Destroy(gameObject);
                return;
            }

            ServiceLocator.Instance.RegisterService<ITriggerSoundEffect>(m_PlaySoundsInUnity); //Servicio que voy a consumir.

            DontDestroyOnLoad(gameObject);
        }
    }

}