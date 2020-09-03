using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FilterManager : MonoBehaviour
{
    public List<SongControl> songs = new List<SongControl>();

    public ConfigPanel_Decade panelDecade;
    public ConfigPanel_Genre panelGenre;
    public ConfigPanel_Category panelCategory;

    public void LoadSongs(List<SongControl> songs)
    {
        this.songs = songs;
    }

    public void ResetFilter()
    {
        panelDecade.Reset();
        panelGenre.Reset();
        panelCategory.Reset();

        //ApplyFilter();
    }

    public void UncheckAll()
    {
        panelDecade.UncheckAll();
        panelGenre.UncheckAll();
        panelCategory.UncheckAll();

        //ApplyFilter();
    }

    //Filter

    public void ApplyFilter()
    {
        List<string> decades = panelDecade.SelectedToggle();
        List<string> genres = panelGenre.SelectedToggle();
        List<string> categories = panelCategory.SelectedToggle();

        foreach (var auxSongs in songs)
        {
            if (FilterDecade(decades, auxSongs.song.year) && 
                genres.Contains(ConfigUtils.GetGenre(auxSongs.song.genre).ToString()) && 
                categories.Contains(ConfigUtils.GetCategory(auxSongs.song.categorie).ToString()))
            {
                auxSongs.gameObject.SetActive(true);
            }
            else
            {
                auxSongs.gameObject.SetActive(false);
            }
        }
    }

    public bool FilterDecade(List<string> decades, int year)
    {
        List<int> fullDecade = new List<int>();
        foreach (var aux in decades)
        {
            fullDecade.Add(ConfigUtils.DecadeToYear(aux));
        }

        if (fullDecade.Count > 0)
        {
            foreach (var aux in fullDecade)
            {
                if (aux < year && (aux + 9) > year)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    //Reorder
    public List<SongControl> ReorderByName(List<SongControl> songs)
    {
        songs = songs.OrderBy(o => o.song.songName).ToList();
        for(int i =0;i< songs.Count;i++)
        {
            songs[i].gameObject.transform.SetSiblingIndex(i);
        }

        return songs;
    }

    public List<SongControl> ReorderByDate(List<SongControl> songs)
    {
        songs = songs.OrderBy(o => o.song.year).ToList();

        for (int i = 0; i < songs.Count; i++)
        {
            songs[i].gameObject.transform.SetSiblingIndex(i);
        }

        return songs;
    }
}
