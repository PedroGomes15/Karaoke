using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notes
{
    public string startTime;

    public string endTime;

    public string subtitle;

    public DuetSinger duetSinger = DuetSinger.NONE;

    public Notes()
    {
    }

    public Notes(string startTime, string endTime, string subtitle, DuetSinger duetSinger = DuetSinger.NONE)
    {
        this.startTime = startTime;
        this.endTime = endTime;
        this.subtitle = subtitle;
        this.duetSinger = duetSinger;
    }
}
