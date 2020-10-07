using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleTest : MonoBehaviour
{
    public Song song;

    public SubtitleController controller;

    public void Awake()
    {
        controller.song = song;
    }

    public void PlaySubtitle()
    {

    }

    public void PauseSubtitle()
    {

    }
}
