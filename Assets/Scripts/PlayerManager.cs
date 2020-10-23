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

    public Image handler;

    public Image fill;

    float halfWidth = 0;

    bool drag = false;

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
        Debug.Log(subtitleTester.song.songFilename);
        source.clip = Resources.Load("Song/Lyric/" + subtitleTester.song.songFilename) as AudioClip;
        txtEndTime.text = ConvertTime(source.clip.length);
        source.Play();

        halfWidth = fill.rectTransform.rect.width / 2;
    }


    private void Update()
    {
        txtCurrentTime.text = ConvertTime(source.time);

        if (!drag)
        {
            fill.fillAmount = Mathf.InverseLerp(0, source.clip.length, source.time);
            Vector2 aux = handler.transform.localPosition;
            aux.x = Mathf.Lerp(-halfWidth, halfWidth, fill.fillAmount);
            handler.transform.localPosition = aux;
        }
    }

    public void Drag()
    {
        drag = true;

        Vector3 point = Input.mousePosition;
        point.x = Mathf.Clamp(point.x, fill.transform.position.x + -halfWidth, fill.transform.position.x + halfWidth);
        point.y = handler.transform.position.y;
        handler.transform.position = point;
        
        fill.fillAmount = Mathf.InverseLerp(-halfWidth, halfWidth, handler.transform.localPosition.x);

        source.time = Mathf.Lerp(0, source.clip.length, fill.fillAmount);
    }

    public void Drop()
    {
        drag = false;
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
