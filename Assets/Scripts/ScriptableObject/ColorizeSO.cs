using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Colorize SO", menuName = "ScriptableObjects/Colorize SO", order = 0)]
public class ColorizeSO : ScriptableObject
{
    public string colorName;
    public List<Colorize> colorizers;
}
