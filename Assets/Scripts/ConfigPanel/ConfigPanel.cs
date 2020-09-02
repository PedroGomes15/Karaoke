using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfigPanel : MonoBehaviour
{
    public GameObject object_reference;

    protected List<Toggle> listToggle = new List<Toggle>();

    public FilterManager filter;

    public void Reset()
    {
        foreach (var aux in listToggle)
        {
            aux.isOn = true;
        }
    }

    public List<string> SelectedToggle()
    {
        List<string> seleced = new List<string>();
        foreach (var aux in listToggle)
        {
            if (aux.isOn)
            {
                seleced.Add(FormatText(aux.GetComponentInChildren<TextMeshProUGUI>().text));
            }
        }
        return seleced;
    }

    public virtual string FormatText(string txt)
    {
        return txt;
    }

    public void UncheckAll()
    {
        foreach (var aux in listToggle)
        {
            aux.isOn = false;
        }
    }
}
