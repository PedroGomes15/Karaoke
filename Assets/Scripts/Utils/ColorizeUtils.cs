using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class ColorizeUtils
{
    static string filename = "ColorizePattern.txt";

    public static string ReadFileColorized()
    {
        return File.ReadAllText(Application.streamingAssetsPath + "/" + filename);
    }

    public static void WriteFileColorized(string pattern)
    {
        File.WriteAllText(Application.streamingAssetsPath + "/" + filename, pattern);
    }

    public static List<string> ReadPatterns()
    {
        string file = ReadFileColorized();
        List<string> patterns = new List<string>();
        foreach (var aux in file.Split('\n'))
        {
            patterns.Add(aux);
        }
        return patterns;
    }
}

public class Colorize
{
    public string objName;
    public Color color;
}
