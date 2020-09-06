using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Colorized", menuName = "ScriptableObjects/Colorized SO")]
public class ColorizeSO : ScriptableObject
{
    public string name;
    public List<Colorize> colorizers= new List<Colorize>();
}

[System.Serializable]
public class Colorize
{
    public string objName;
    public Color color;
}
