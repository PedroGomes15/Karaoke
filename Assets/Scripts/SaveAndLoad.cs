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

    public void Save(string fileName, string json, string extension = ".json")
    {
        Directory.CreateDirectory(Application.streamingAssetsPath);
        File.WriteAllText(Application.streamingAssetsPath+"/"+ fileName+extension, json);
    }

    public void SaveSong(Song song)
    {
        string songsFolder = "/Songs/";
        Directory.CreateDirectory(Application.streamingAssetsPath + songsFolder);

        string songText = SerializeObject(song);
        Save(songsFolder + song.songName, songText);
    }

    public string Load(string fileName, string extension = ".json")
    {
        string url = Application.streamingAssetsPath + "/" + fileName + extension;
        
        if (!File.Exists(url))
        {
            Debug.LogError("Arquivo nao encontrado");
            return null;
        }
        return File.ReadAllText(url);
    }

    public string LoadSimple(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Debug.LogError("Arquivo nao encontrado");
            return null;
        }
        return File.ReadAllText(fileName);
    }

    public List<Song> LoadSongs()
    {
        List<Song> songs = new List<Song>();
        foreach(var aux in Directory.GetFiles(Application.streamingAssetsPath + "/Songs/"))
        {
            if (aux.EndsWith(".json"))
            {
                var simple = LoadSimple(aux);
                Song mySong = (Song)DeserializeObject<Song>(simple);
                songs.Add(mySong);
            }
        }
        return songs;
    }

    public Sprite SpriteLoadCover(string filename)
    {
        return Resources.Load<Sprite>("Cover/" + filename);
    }
}
