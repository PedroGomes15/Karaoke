using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Genre
{
    public GenreType genre;

    public string color;

    public Genre(GenreType genre, string color)
    {
        this.genre = genre;
        this.color = color;
    }

//    public Genre[] genres =
  //  {
    //    new Genre(GenreType.FUNK,"ed9d24"),
      //  new Genre(GenreType.SERTANEJO,"24b4ed")
    //};
}
