using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using System;

public class ConfigPanel_Genre : ConfigPanel
{

    void Start()
    {
        var tempList = System.Enum.GetValues(typeof(GenreType)).Cast<GenreType>();
        tempList = tempList.OrderBy(o => o.ToString()).ToList();

        foreach (var aux in tempList)
        {
            CreateGenre(aux.ToString());
        }
        this.gameObject.SetActive(false);
    }

    void CreateGenre(string genre)
    {
        GameObject goDecade = Instantiate(object_reference, this.transform);
        goDecade.transform.name += "_" + genre;
        goDecade.GetComponentInChildren<TextMeshProUGUI>().text = ConfigUtils.GenreFormat(genre);
        listToggle.Add(goDecade.GetComponent<Toggle>());
    }
}
