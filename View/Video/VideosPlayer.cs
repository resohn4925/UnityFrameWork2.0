using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideosPlayer : BaseVideosPlayer
{
    protected override void Start()
    {
        base.Start();
        EventManager.GetInstance().AddEventListener("VideoSkip", CloseAll);
        EventManager.GetInstance().AddEventListener("NormalStart", Play);
        EventManager.GetInstance().AddEventListener("XfdStart", Play);

        Play(0);
    }

    protected override void OnVideoEnd(VideoPlayer vp)
    {
        foreach (GameObject video in listVideo)
        {
            if (video.GetComponent<VideoPlayer>() == vp)
            {
                video.SetActive(false);
                EventManager.GetInstance().Trigger("VideoSkip", 0);
            }
        }
    }
}
