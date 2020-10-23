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
            string genresLoaded = SaveAndLoad.Load("Genres");
            genres = SaveAndLoad.DeserializeObject<Genres>(genresLoaded).genres.ToList();
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
