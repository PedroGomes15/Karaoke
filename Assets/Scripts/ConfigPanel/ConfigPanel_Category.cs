using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using System;

public class ConfigPanel_Category : ConfigPanel
{
    void Start()
    {
        var tempList = System.Enum.GetValues(typeof(CategoryType)).Cast<CategoryType>();
        //tempList = tempList.OrderBy(o => o.ToString()).ToList();

        foreach (var aux in tempList)
        {
            CreateCategory(aux.ToString());
        }
        this.gameObject.SetActive(false);
    }

    void CreateCategory(string category)
    {
        GameObject goDecade = Instantiate(object_reference, this.transform);
        goDecade.transform.name += "_" + category;
        goDecade.GetComponentInChildren<TextMeshProUGUI>().text = ConfigUtils.GenreFormat(category);
        listToggle.Add(goDecade.GetComponent<Toggle>());
    }
}
