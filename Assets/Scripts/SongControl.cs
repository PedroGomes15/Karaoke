using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongControl : MonoBehaviour
{
    private Image cover;

    private TextMeshProUGUI songName;

    private GameObject[] tags;

    private TextMeshProUGUI singerName;

    private TextMeshProUGUI durationName;

    private TextMeshProUGUI yearName;

    private void Awake()
    {
        cover = this.transform.Find("Cover").GetComponent<Image>();
        songName = this.transform.Find("Tags").GetComponent<TextMeshProUGUI>();
        tags = this.transform.Find("Tags").GetComponentsInChildren<GameObject>();
        singerName = this.transform.Find("Singer").GetComponent<TextMeshProUGUI>();
        durationName = this.transform.Find("Duration").GetComponent<TextMeshProUGUI>();
        yearName = this.transform.Find("Year").GetComponent<TextMeshProUGUI>();
    }

    public void SetupSong(Song song)
    {
        cover.sprite = SaveAndLoad.instance.SpriteLoadCover(song.coverFilename);

        songName.text = song.songName;

        SetupTags(tags[0],)

        songName.text = song.songName;
        songName.text = song.songName;
        songName.text = song.songName;
    }

    public void SetupTags(GameObject tag, Color backgroundColor,string text)
    {
        tag.GetComponent<Image>().color = backgroundColor;
        tag.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}
