using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Genres
{
    public Genre[] genres;

    public Genres(Genre[] genres)
    {
        this.genres = genres;
    }
}
