using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Colorizer : MonoBehaviour
{
    public void ApplyColor()
    {
        this.GetComponent<Image>().color = GetColor();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    Color GetColor()
    {
        return new Color();
    }
}
