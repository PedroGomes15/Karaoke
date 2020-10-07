using System;
using System.Globalization;
using UnityEngine;

public static class ConfigUtils
{

    public static string YearToDecade(int year)
    {
        return ((year / 10) * 10).ToString().Substring(2);
    }

    public static int DecadeToYear(string decade)
    {
        return (int.Parse(decade)>40)?int.Parse( "19" + decade):int.Parse("20"+decade);
    }

    public static GenreType GetGenre(string genre)
    {
        return (GenreType)System.Enum.Parse(typeof(GenreType), genre.ToUpper());
    }

    public static CategoryType GetCategory(string category)
    {
        return (CategoryType)System.Enum.Parse(typeof(CategoryType), category.ToUpper());
    }

    public static string GenreFormat(string genre)
    {
        string retGenre = genre;
        retGenre = retGenre.Replace('_', ' ');
        retGenre = retGenre.Replace("AND", "&");

        return retGenre;
    }

    public static float ConvertTime(string time)
    {
        var convertTime = DateTime.ParseExact(time, "m:ss", CultureInfo.InvariantCulture);
        return (float)convertTime.TimeOfDay.TotalSeconds;
    }
}
