using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : baseAudioPlayer
{
    private void Start()
    {
        EventManager.GetInstance().AddEventListener("ChangeBGM", ChangeBGM);
    }
}
