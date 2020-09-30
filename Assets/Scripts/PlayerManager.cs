using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public AudioSource source;

    public SubtitleTest subtitleTester;

    public TextMeshProUGUI txtEndTime, txtCurrentTime;

    public Slider slider;

    public Image handler;

    public Image fill;

    public void btn_Play()
    {
        if(source.isPlaying)
        {
            source.Pause();
            subtitleTester.PauseSubtitle();
        }
        else
        {
            source.Play();
            subtitleTester.PlaySubtitle();
        }
    }

    public void btn_Restart()
    {

    }

    public void Start()
    {
        source.clip = Resources.Load("Song/Lyric/" + subtitleTester.song.songFilename) as AudioClip;
        slider.maxValue = source.clip.length;
        txtEndTime.text = ConvertTime(source.clip.length);
        source.Play();
    }


    private void Update()
    {
        txtCurrentTime.text = ConvertTime(source.time);
        //source.time = slider.value;

        Vector2 t = handler.transform.localPosition;
        t.x = fill.fillAmount * fill.rectTransform.rect.width;
        Debug.Log(t);
        handler.rectTransform.localPosition = t;
    }

    private string ConvertTime(float secs)
    {
        TimeSpan t = TimeSpan.FromSeconds(secs);

        string answer = string.Format("{0:D0}m:{1:D1}s",
                        t.Minutes,
                        t.Seconds);

        return answer;
    }
}
