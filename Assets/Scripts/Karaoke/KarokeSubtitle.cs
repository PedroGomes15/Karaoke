using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class KarokeSubtitle : MonoBehaviour
{
    public Song song;

    public float timer = 0.0f;
    public float timerClean = 0.0f;

    public TextMeshProUGUI txtSubtitle;

    private void Start()
    {
        song = SaveAndLoad.LoadSongs()[0];
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        timerClean += Time.deltaTime;
        ProcessNote(timer);
    }

    TimeSpan delay = new TimeSpan(0, 0, 1);

    public void ProcessNote(float time)
    {
        foreach(var aux in song.notes)
        {
            var sTime = DateTime.ParseExact(aux.startTime, "m:ss", CultureInfo.InvariantCulture).Subtract(delay);
            var eTime = DateTime.ParseExact(aux.endTime, "m:ss", CultureInfo.InvariantCulture).Subtract(delay);

            if(timerClean>10 && sTime.Subtract(new TimeSpan(0, 0, 3)).TimeOfDay.Seconds < time)
            {
                StartCoroutine(PrepareNote(3));
                timerClean = 0;
            }

            if (sTime.TimeOfDay.TotalSeconds < time && eTime.TimeOfDay.TotalSeconds > time)
            {
                ProcessSubtitle(aux);
            }
        }
    }

    public IEnumerator PrepareNote(int time)
    {
        txtSubtitle.text = time + "...";
        if(time>0)
        {
            time--;
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(PrepareNote(time));
        }
    }

    public void ProcessSubtitle(Notes note)
    {
        txtSubtitle.text = note.subtitle;

        timerClean = 0;

        if (note.duetSinger == DuetSinger.ONE)
        {
            txtSubtitle.color = Color.blue;
        }

        if (note.duetSinger == DuetSinger.TWO)
        {
            txtSubtitle.color = Color.magenta;
        }

        if (note.duetSinger == DuetSinger.BOTH)
        {
            txtSubtitle.color = Color.green;
        }

        var sTime = DateTime.ParseExact(note.startTime, "m:ss",CultureInfo.InvariantCulture);
        var eTime = DateTime.ParseExact(note.endTime, "m:ss", CultureInfo.InvariantCulture);

        var duration = eTime.Subtract(sTime).TotalSeconds;
        StartCoroutine(CleanText((float)duration));
    }

    public IEnumerator CleanText(float endTime)
    {
        yield return new WaitForSeconds(endTime);
        txtSubtitle.text = "";
    }
}
