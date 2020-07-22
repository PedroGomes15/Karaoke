using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Song song;

    void Start()
    {
       /* Notes[] notes =
        {
            new Notes("0:24", "0:33", "Quando eu digo que deixei de te amar\nÉ porque eu te amo"),
            new Notes("0:34", "0:42", "Quando eu digo que não quero mais você\nÉ porque eu te quero"),
        };
        song = new Song("Evidências","evidencias_cover.png", "Evidencias", "4:55","Sertanejo", "Chitãozinho e Xororó",1990,SingType.SOLO, notes);*/

        string songText = SaveAndLoad.instance.SerializeObject<Song>(song);
        SaveAndLoad.instance.Save(song.songName, songText);
    }
}
