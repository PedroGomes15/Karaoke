using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SongControl : MonoBehaviour
{
    private Image cover;

    private TextMeshProUGUI songName;

    public List<Transform> tags;

    private TextMeshProUGUI singerName;

    private TextMeshProUGUI yearName;

    public GenreManager genreManager;

    [HideInInspector]
    public Song song;

    private void Awake()
    {
        cover = this.transform.Find("Cover").GetComponent<Image>();

        Transform vertical = this.transform.Find("VerticalLayout").GetComponent<Transform>();

        songName = vertical.Find("SongName").GetComponent<TextMeshProUGUI>();
        foreach(Transform aux in vertical.Find("Tags"))
        {
            tags.Add(aux);
        }
        singerName = vertical.Find("Singer").GetComponent<TextMeshProUGUI>();
        yearName = vertical.Find("Year").GetComponent<TextMeshProUGUI>();

    }

    public void SetupSong(Song song)
    {
        this.song = song;
        this.transform.name = song.songName;
        cover.sprite = SaveAndLoad.SpriteLoadCover(song.coverFilename);

        songName.text = song.songName;
        singerName.text = song.singer;

        Genre genre = genreManager.getGenre(song.genre);

        SetupTags(tags[0], genre.color, genre.genre.ToString());
        SetupTags(tags[1], genre.color, "Decada: " + ConfigUtils.YearToDecade(song.year));
        SetupTags(tags[2], genre.color, song.categorie.ToString());
        SetupTags(tags[3], genre.color, FormatText(song.singType.ToString()));

        songName.text = song.songName;
        yearName.text = "Ano: " + song.year;
    }

    public void SetupTags(Transform tag, string backgroundColor,string text)
    {
        /*Color color;
        if (ColorUtility.TryParseHtmlString(backgroundColor, out color))
        { tag.GetComponent<Image>().color = color; }*/
        tag.GetComponent<TextMeshProUGUI>().text = FormatText(text);
    }

    public string FormatText(string txt)
    {
        string _txt = txt.ToLower();
        return _txt.First().ToString().ToUpper() + _txt.Substring(1);
    }
}
