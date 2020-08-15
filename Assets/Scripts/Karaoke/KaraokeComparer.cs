using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KaraokeComparer : MonoBehaviour
{
    public InputMic mic;

    private int _sampleWindow = 128;

    public AudioSource audioSource;

    public NoteController nMic, nSound;


    void Update()
    {
        float s1 = (float)Math.Round(mic.TestSound() * 10, 4);
        float s2 = (float)Math.Round(GetSound() * 10, 4);

        if (s2 != 0.0)
        {
            CompareSounds(s1, s2, 0.01f);
        }

        nMic.ScaleInVolume(s1);
        nSound.ScaleInVolume(s2);
    }

    bool CompareSounds(float s1, float s2, float range)
    {
        return Mathf.Abs(s1 - s2) < range ? true : false;
    }

    float GetSound()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1);
        if (micPosition < 0)
        {
            return 0;
        }
        audioSource.clip.GetData(waveData, micPosition);
        for (int i = 0; i < _sampleWindow; ++i)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }
}
