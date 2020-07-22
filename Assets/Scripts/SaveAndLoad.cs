using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad instance = null;
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }
    public string SerializeObject<T>(T obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public T DeserializeObject<T>(string jsonValue)
    {
        return JsonUtility.FromJson<T>(jsonValue);
    }

    public void Save(string fileName, string json)
    {
        Directory.CreateDirectory(Application.streamingAssetsPath);
        File.WriteAllText(Application.streamingAssetsPath+"/"+ fileName+".json", json);
    }

    public Sprite SpriteLoadCover(string filename)
    {
        return Resources.Load<Sprite>("Cover/" + filename);
    }
}
