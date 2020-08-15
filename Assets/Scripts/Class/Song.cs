using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Song
{
    public string songName;

    public string coverFilename;

    public string songFilename;

    public string genre;

    public string singer;

    public int year;

    public string categorie;

    public SingType singType;

    public List<Notes> notes = new List<Notes>();

    public Song()
    {
    }

    public Song(string songName, string coverFilename, string songFilename, GenreType genre, string singer, int year, string categorie, SingType singType, List<Notes> notes)
    {
        this.songName = songName;
        this.coverFilename = coverFilename;
        this.songFilename = songFilename;
        this.genre = genre.ToString();
        this.singer = singer;
        this.year = year;
        this.categorie = categorie;
        this.singType = singType;
        this.notes = notes;
    }
}
