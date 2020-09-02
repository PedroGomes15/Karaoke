using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using System;

public class ConfigPanel_Decade : ConfigPanel
{

    void Start()
    {
        List<string> decades = new List<string>();

        var tempList = SaveAndLoad.LoadSongs();
        tempList = tempList.OrderBy(o => o.year).ToList();

        foreach (var aux in tempList)
        {
            var dec = ConfigUtils.YearToDecade(aux.year);
            if (!decades.Contains(dec))
            {
                decades.Add(dec);
            }
        }

        foreach (var aux in decades)
        {
            CreateDecade(aux);
        }
    }

    void CreateDecade(string decade)
    {
        GameObject goDecade = Instantiate(object_reference, this.transform);
        goDecade.transform.name += decade + "'s";
        goDecade.GetComponentInChildren<TextMeshProUGUI>().text = decade + "'s";
        listToggle.Add(goDecade.GetComponent<Toggle>());
    }

    public override string FormatText(string txt)
    {
        return txt.Substring(0, 2);
    }
}
