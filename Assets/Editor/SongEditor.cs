using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using UnityEngine.UI;
using System.Linq;

public class SongEditor : EditorWindow
{
    static EditorWindow window;

    [MenuItem("Karaoke/Song Editor")]
    static void Init()
    {
        window = GetWindow<SongEditor>("Song Editor");
        window.position = new Rect(150, 150, 870, 500);
        window.Show();
    }

    private void Awake()
    {
        song = new Song();
        textureSalvar = Resources.Load("salvar") as Texture;
        textureExcluir = Resources.Load("excluir") as Texture;
        song.notes.Add(new Notes());
    }

    void OnGUI()
    {
        SetupSong();
    }

    Song song;

    Sprite texture;
    GenreType genre;
    CategoryType category;
    SingType sType;

    string fileSongPath;

    Texture textureSalvar;
    Texture textureExcluir;

    Vector2 pos;
    
    string fullSubtitle = "";

    void SetupSong()
    {
        GUILayout.BeginArea(new Rect(10, 35, 850, 850));

        EditorGUIUtility.labelWidth = 120;

        GUILayout.BeginHorizontal(GUILayout.Height(100));

        GUILayout.BeginVertical();

        GUIContent sName = new GUIContent();
        texture = EditorGUILayout.ObjectField(sName, texture, typeof(Sprite), true,
            GUILayout.Width(EditorGUIUtility.singleLineHeight * 8),
            GUILayout.Height(EditorGUIUtility.singleLineHeight * 8)) as Sprite;

        if (texture != null)
            song.coverFilename = texture.name;

        if (GUILayout.Button("Carregar", GUILayout.Width(EditorGUIUtility.singleLineHeight * 8)))
        {
            var fileImage = EditorUtility.OpenFilePanel("Carregar Image", "", "png,jpg,jpge");

            var resources = Application.dataPath + "/Resources/Cover";
            var filename = Path.GetFileName(fileImage);
            string[] paths = { resources, filename};
            var fullFilename = Path.Combine(paths);

            File.Copy(fileImage, fullFilename);

            AssetDatabase.Refresh();
            texture = Resources.Load<Sprite>("Cover/" + Path.GetFileNameWithoutExtension(filename));
        }

        
        GUILayout.EndVertical();

        EditorGUILayout.Space(20);

        GUILayout.BeginVertical();

            sName.text = "Nome da Musica: ";
            song.songName = EditorGUILayout.TextField(sName, song.songName, GUILayout.Width(400));


        GUILayout.BeginHorizontal();

            sName.text = "Arquivo da Musica: ";
            song.songFilename = EditorGUILayout.TextField(sName, song.songFilename, GUILayout.Width(316));

            if(GUILayout.Button("Carregar", GUILayout.Width(80)))
            {
                fileSongPath = EditorUtility.OpenFilePanel("Carregar Musica", "", "mp3");
                song.songFilename = Path.GetFileNameWithoutExtension(fileSongPath);
            }

        GUILayout.EndHorizontal();

            sName.text = "Nome do Cantor: ";
            song.singer = EditorGUILayout.TextField(sName, song.singer, GUILayout.Width(400));

            sName.text = "Genero Musical: ";
            genre = (GenreType)EditorGUILayout.EnumPopup(sName, genre, GUILayout.Width(300));
            song.genre = genre.ToString();

            sName.text = "Ano da Musica: ";
            song.year = EditorGUILayout.IntField(sName, song.year, GUILayout.Width(175));
            
            sName.text = "Categoria: ";
            category = (CategoryType)EditorGUILayout.EnumPopup(sName, category, GUILayout.Width(400));
            song.categorie = category.ToString();

            sName.text = "Tipo de Cantor: ";
            song.singType = (SingType)EditorGUILayout.EnumPopup(sName, song.singType, GUILayout.Width(300));

        GUILayout.EndVertical();

        GUILayout.BeginVertical();

        if (GUILayout.Button(textureExcluir, GUILayout.Width(60), GUILayout.Height(60)))
        {
            var popup = GetWindow<SongEditorConfirm>("Format");
            popup.position = new Rect(350, 350, 350, 75);
            popup.ShowPopup();
            popup.Focus();
        }

        if (GUILayout.Button(textureSalvar, GUILayout.Width(60), GUILayout.Height(60)))
        {
            SaveSong();
        }
           
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        GUILayout.Space(5);

        //Notas
        var style = new GUIStyle(GUI.skin.textArea) {alignment = TextAnchor.MiddleCenter};
        //fullSubtitle = EditorGUILayout.TextArea(fullSubtitle, style,GUILayout.ExpandWidth(true), GUILayout.Height(70));
        GUILayout.Space(5);

        pos = EditorGUILayout.BeginScrollView(pos, false, true, GUILayout.Height(300));

        GUILayout.BeginVertical();

        sName.text = "Nova Legenda";
        if (GUILayout.Button(sName, GUILayout.Width(Screen.width - 40)))
        {
            song.notes.Add(new Notes());
        }

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();

        if (Event.current.type == EventType.KeyUp && 
        (Event.current.modifiers == EventModifiers.Control || Event.current.modifiers == EventModifiers.Command) && 
        GUI.GetNameOfFocusedControl() == "Subtitle")
        {
            if (Event.current.keyCode == KeyCode.V)
            {
                var sub = song.notes[0].subtitle;
                song.notes.Clear();

                SaveAndLoad.Save("Teste", sub,".txt");

                using (StringReader reader = new StringReader(sub))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(line != "")
                            song.notes.Add(new Notes(line));
                    }
                }
            }
        }

        GUILayout.Label("Tempo de Inicio");

        GUILayout.FlexibleSpace();

        GUILayout.Label("Letra");

        GUILayout.FlexibleSpace();

        GUILayout.Label("Tempo de Encerramento");

        if(song.singType == SingType.DUET)
        {
            GUILayout.FlexibleSpace();

            GUILayout.Label("Cantor do dueto");
        }

        GUILayout.Space(15);

        GUILayout.EndHorizontal();

        foreach (var note in song.notes.ToList())
        {
            GUILayout.BeginHorizontal();

            sName.text = "x";
            if (GUILayout.Button(sName))
            {
                song.notes.Remove(note);
            }

            note.startTime = EditorGUILayout.TextField(formatTime(note.startTime), GUILayout.Width(75));

            GUILayout.FlexibleSpace();

            GUI.SetNextControlName("Subtitle");
            note.subtitle = EditorGUILayout.TextArea(note.subtitle, GUILayout.Width(song.singType != SingType.DUET?600:500));

            GUILayout.FlexibleSpace();

            note.endTime = EditorGUILayout.TextField(formatTime(note.endTime), GUILayout.Width(75));

            if (song.singType == SingType.DUET)
            {
                GUILayout.FlexibleSpace();

                note.duetSinger = (DuetSinger)EditorGUILayout.EnumPopup(note.duetSinger, GUILayout.Width(100));
            }
            GUILayout.Space(15);


            GUILayout.EndHorizontal();
        }

        GUILayout.Space(20);

        GUILayout.EndVertical();

        GUILayout.EndArea();


        GUILayout.EndScrollView();


        Event e = Event.current;

        if (e.commandName == "Confirmar")
        {
            Clean();
        }
    }


    private void SaveSong()
    {
        var resources = Application.dataPath + "/Resources/Song";
        var filenameLyric = song.songFilename + Path.GetExtension(fileSongPath);
        string[] paths = {resources, "Lyric", filenameLyric};
        var fullFileNameLyic = Path.Combine(paths);

        File.Copy(fileSongPath, fullFileNameLyic);        

        SaveAndLoad.SaveSong(song);
        AssetDatabase.Refresh();
    }

    private String formatGenreText(string txt)
    {
        string _txt = txt.ToLower();
        return _txt.First().ToString().ToUpper() + _txt.Substring(1);
    }

    private void Clean()
    {
        song = new Song();
    }

    private string formatTime(string time)
    {
        if (time == "" || time == null)
        {
            time = "0";
        }

        if (!time.Contains(":"))
        {
            if (time.Length > 0)
            {
                if (time.Length == 1)
                {
                    time = "0:0" + time;
                }
                else if (time.Length == 2)
                {
                    time = "0:" + time;
                }
                else
                {
                    time = time.Remove(time.Length - 2, 2) + ":" + time.Substring(time.Length - 2, 2);
                }
            }
            else
            {
                time += ":00";
            }
        }
        return time;
    }
}

public class SongEditorConfirm : EditorWindow
{
    void OnGUI()
    {
        this.Focus();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal("box");
        GUILayout.FlexibleSpace();
        GUILayout.Label("Deseja limpar as informações");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();

        GUIContent sName = new GUIContent();
        sName.text = "Confirmar";

        if (GUILayout.Button(sName, GUILayout.Height(30)))
        {
            var popup = GetWindow<SongEditor>();
            popup.SendEvent(EditorGUIUtility.CommandEvent("Confirmar"));
            this.Close();
        }

        sName.text = "Cancelar";
        if (GUILayout.Button(sName, GUILayout.Height(30)))
        {
            this.Close();
        }

        GUILayout.EndHorizontal();
    }
}
