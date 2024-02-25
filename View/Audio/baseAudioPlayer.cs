using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseAudioPlayer : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> listBGM;//bgm列表
    [SerializeField]
    protected List<GameObject> listEffectAudio;//音效列表

    /// <summary>
    /// BGM同时只播放一首
    /// </summary>
    /// <param name="i"></param>
    protected void ChangeBGM(int i)
    {
        foreach(GameObject BGM in listBGM)
        {
            BGM.GetComponent<AudioSource>().Stop();
        }
        listBGM[i].GetComponent<AudioSource>().Play();
    }

    protected void Play(int i)
    {
        listEffectAudio[i].GetComponent<AudioSource>().Play();
    }

    protected void Pause(int i)
    {
        listEffectAudio[i].GetComponent<AudioSource>().Pause();
    }

    protected void CloseBGM(int i)
    {
        foreach (GameObject BGM in listBGM)
        {
            BGM.GetComponent<AudioSource>().Stop();
        }
    }

    protected void Close(int i)
    {
        listEffectAudio[i].GetComponent<AudioSource>().Stop();
    }
}
