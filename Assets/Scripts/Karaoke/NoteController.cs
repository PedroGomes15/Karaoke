using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoteController : MonoBehaviour
{
    float yStartScale;
    public float scaleValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        yStartScale = this.transform.localScale.y;
    }

    public void ScaleInVolume(float volume)
    {
        var scale = this.transform.localScale;

        var newV = (float)Math.Round(volume,1);
        //Debug.Log(newV);

        scale.y = Mathf.Lerp(yStartScale + newV * scaleValue, yStartScale, Time.deltaTime);
        this.transform.localScale = scale;
    }
}
