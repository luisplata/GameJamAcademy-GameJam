using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerSoundEffect
{
    void PlayShortSoundOnce(string audioClip);
    void StopSFX();
}