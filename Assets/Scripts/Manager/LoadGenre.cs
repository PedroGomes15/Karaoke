using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGenre : MonoBehaviour
{

    public List<Genre> genres = new List<Genre>();

    void Start()
    {
        Loader.instance.StartLoader("1k6uoxVGg9UnGe2v_vRkoOmjiSpqFA1wv4iZf5hw-_zg", ProcessLineFromCSV);
    }

    public void ProcessLineFromCSV(List<string> currLineElements, int currLineIndex)
    {
        foreach (var aux in currLineElements)
        {
            Debug.Log("Teste - " + aux + " - " + currLineIndex);
        }

        if (currLineIndex != 0)
        {
            if (currLineElements.Count > 1)
            {
                Genre genre = new Genre((GenreType)System.Enum.Parse(typeof(GenreType), currLineElements[0].ToUpper()), currLineElements[1]);
                genres.Add(genre);
                //print( "englishSpelling: >" + englishSpelling + "<" );
            }
            else
            {
                Debug.LogError("Database line did not fall into one of the expected categories.");
            }
        }


        /*
        // This line contains the column headers, telling us which languages are in which column
        if (currLineIndex == 0)
        {
            languages = new List<string>();
            for (int columnIndex = 0; columnIndex < currLineElements.Count; columnIndex++)
            {
                string currLanguage = currLineElements[columnIndex];
                Assert.IsTrue((columnIndex != 0 || currLanguage == "English"), "First column first row was:" + currLanguage);
                Assert.IsFalse(Manager.instance.translator.termData.languageIndicies.ContainsKey(currLanguage));
                Manager.instance.translator.termData.languageIndicies.Add(currLanguage, currLineIndex);
                languages.Add(currLanguage);
            }
            UnityEngine.Assertions.Assert.IsFalse(languages.Count == 0);
        }
        // This is a normal node
        else if (currLineElements.Count > 1)
        {
            string englishSpelling = null;
            string[] nonEnglishSpellings = new string[languages.Count - 1];

            for (int columnIndex = 0; columnIndex < currLineElements.Count; columnIndex++)
            {
                string currentTerm = currLineElements[columnIndex];
                if (columnIndex == 0)
                {
                    Assert.IsFalse(Manager.instance.translator.termData.termTranslations.ContainsKey(currentTerm), "Saw this term twice: " + currentTerm);
                    englishSpelling = currentTerm;
                }
                else
                {
                    nonEnglishSpellings[columnIndex - 1] = currentTerm;
                }
            }
            Manager.instance.translator.termData.termTranslations[englishSpelling] = nonEnglishSpellings;
            //print( "englishSpelling: >" + englishSpelling + "<" );
        }
        else
        {
            Debug.LogError("Database line did not fall into one of the expected categories.");
        }*/
    }
}
