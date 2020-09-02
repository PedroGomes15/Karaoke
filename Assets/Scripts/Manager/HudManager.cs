using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public ScrollRect svSongs;

    public GameObject songControl_reference;

    public GenreManager genreManager;

    public FilterManager filter;

    public List<SongControl> songs = new List<SongControl>();

    public Button btn_ReorderByName,btn_ReorderByDate;

    public void Start()
    {

        SetupButtons();
    }

    public SongControl CreateSong(Song song)
    {
        GameObject songGo = Instantiate(songControl_reference, svSongs.content);
        songGo.GetComponent<SongControl>().genreManager = this.genreManager;
        songGo.GetComponent<SongControl>().SetupSong(song);

        var sControll = songGo.GetComponent<SongControl>();

        songs.Add(sControll);
        return sControll;
    }

    public void SetupButtons()
    {
        btn_ReorderByName.onClick.AddListener(() => { songs = filter.ReorderByName(songs); });

        btn_ReorderByDate.onClick.AddListener(() => { songs = filter.ReorderByDate(songs); });
    }
}
