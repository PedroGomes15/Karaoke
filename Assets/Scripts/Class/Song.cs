using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Song
{
    public string songName;

    public string coverFilename;

    public string songFilename;

    public string duration;

    public Genre genre;

    public string singer;

    public int year;

    public SingType singType;

    public Notes[] notes;

    public Song(string songName, string coverFilename, string songFilename, string duration, GenreType genre, string singer, int year, SingType singType, Notes[] notes)
    {
        this.songName = songName;
        this.coverFilename = coverFilename;
        this.songFilename = songFilename;
        this.duration = duration;
        this.genre.genre = genre;
        this.singer = singer;
        this.year = year;
        this.singType = singType;
        this.notes = notes;
    }
}
