using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SubtitleController : MonoBehaviour
{
    public GameObject prefabSubtitle;

    public Transform content;

    public float timer = 0.0f;

    public Song song;

    public float delay = 10;

    public int nextIndex;

    public float[] limitY;

    public List<SubtitleSingleController> subtitleControllers = new List<SubtitleSingleController>();

    void Start()
    {
        for(int i =0; i<3;i++)
            CreateSubtitle(i);
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    public void CreateSubtitle(int i)
    {
        if (song.notes.Count - 1 >= nextIndex)
        {
            Notes aux = song.notes[nextIndex];
            GameObject temp = Instantiate(prefabSubtitle, content);
            temp.GetComponent<TextMeshProUGUI>().text = aux.subtitle;
            SubtitleSingleController singleController = temp.GetComponent<SubtitleSingleController>();
            singleController.controller = this;
            singleController.note = aux;
            singleController.index = i;
            subtitleControllers.Add(singleController);
            nextIndex++;
        }
    }

    public void SubtractIndex()
    {
        foreach(var aux in subtitleControllers)
        {
            aux.index--;
        }
    }

    public void DestroyLast()
    {
        if (subtitleControllers.Exists(x => x.index == 3))
        {
            DestroyImmediate(subtitleControllers.Find(x => x.index == 3).gameObject);
        }
    }

    public float CurrentSeconds()
    {
        return timer;
    }
}
