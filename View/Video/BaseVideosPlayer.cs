using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BaseVideosPlayer : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> listVideo;

    protected virtual void Start()
    {
        AddEndListener();
    }

    private void AddEndListener()
    {
        foreach(GameObject video in listVideo)
        {
            video.GetComponent<VideoPlayer>().loopPointReached += OnVideoEnd;
        }
    }
    protected void Play(int i)
    {
        listVideo[i].SetActive(true);
        listVideo[i].GetComponent<VideoPlayer>().Play();
    }
    /// <summary>
    /// 从头播放
    /// </summary>
    /// <param name="i"></param>
    protected void RePlay(int i)
    {
        listVideo[i].SetActive(true);
        VideoPlayer vp = listVideo[i].GetComponent<VideoPlayer>();
        vp.time = 0f;
        listVideo[i].GetComponent<VideoPlayer>().Play();
    }
    protected void Pause(int i)
    {
        if (listVideo[i].GetComponent<VideoPlayer>().isPlaying)
        {
            listVideo[i].GetComponent<VideoPlayer>().Pause();
        }
    }

    protected void Close(int i)
    {
        listVideo[i].GetComponent<VideoPlayer>().Stop();
        listVideo[i].SetActive(false);
    }
    protected void CloseAll(int index)
    {
        for(int i = 0; i < listVideo.Count; ++i)
        {
            listVideo[i].GetComponent<VideoPlayer>().Stop();
            listVideo[i].SetActive(false);
        }
    }
    protected virtual void OnVideoEnd(VideoPlayer vp)
    {
        foreach(GameObject video in listVideo)
        {
            if(video.GetComponent<VideoPlayer>() == vp)
            {
                video.SetActive(false);
            }
        }
    }
}
