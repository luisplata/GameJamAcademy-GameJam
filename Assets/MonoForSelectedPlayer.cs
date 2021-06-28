using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoForSelectedPlayer : MonoBehaviour
{
    [SerializeField] private string music;
    void Start()
    {
        //Music_Relax
        ServiceLocator.Instance.GetService<IMusic>().Stop();
        //Music_Relax
        ServiceLocator.Instance.GetService<IMusic>().StartMusic(music);
    }
}
