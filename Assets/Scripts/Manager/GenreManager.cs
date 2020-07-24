using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenreManager : MonoBehaviour
{
    public List<Genre> genres = new List<Genre>();

    public bool forceDownload = true;

    void Awake()
    {
        if (forceDownload)
        {
            Loader.instance.StartLoader("1k6uoxVGg9UnGe2v_vRkoOmjiSpqFA1wv4iZf5hw-_zg", ProcessLineFromCSV, EndProcessLines);
        }
        else
        {
            string genresLoaded = SaveAndLoad.instance.Load("Genres");
            genres = SaveAndLoad.instance.DeserializeObject<Genres>(genresLoaded).genres.ToList();
        }
    }

    public void ProcessLineFromCSV(List<string> currLineElements, int currLineIndex)
    {
        if (currLineIndex != 0)
        {
            if (currLineElements.Count > 1)
            {
                Genre genre = new Genre((GenreType)System.Enum.Parse(typeof(GenreType), currLineElements[0].ToUpper()), currLineElements[1]);
                genres.Add(genre);
            }
            else
            {
                Debug.LogError("Database line did not fall into one of the expected categories.");
            }
        }
    }

    public void EndProcessLines()
    {
        Genres allGenres = new Genres(genres.ToArray());
        string s_Genres = SaveAndLoad.instance.SerializeObject(allGenres);
        SaveAndLoad.instance.Save("Genres", s_Genres);
    }

    public Genre getGenre(string genre)
    {
        foreach(var aux in genres)
        {
            if(aux.genre.ToString() == genre.ToUpper())
            {
                return aux;
            }
        }
        return null;
    }
}
