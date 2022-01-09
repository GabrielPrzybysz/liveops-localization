using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using UnityEngine;

public class LocalizationController
{
    public static Languages CurrentLanguage = Languages.EN;

    private static LocalizationController _instance;

    public static LocalizationController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LocalizationController();
            }

            return _instance;
        }
    }

    private readonly Dictionary<string, LocalizationItem> _localizedItems = new Dictionary<string, LocalizationItem>();


    public void Initialize()
    {
        LoadLocalizationFromCSV();
    }

    private void LoadLocalizationFromCSV()
    {
        CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ","
        };

        using (var csvParser =
            new CsvParser(new StringReader(LocalizationDownloader.RawLocalization), csvConfiguration))
        {
            using (var csvReader = new CsvReader(csvParser))
            {
                try
                {
                    var localizationSheet = csvReader.GetRecords<CSVContent>().ToList();

                    foreach (var rawItem in localizationSheet)
                    {
                        _localizedItems.Add(rawItem.KEY, new LocalizationItem(rawItem.en, rawItem.es, rawItem.pt));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }

    public string Localize(string key)
    {
        switch (CurrentLanguage)
        {
            case Languages.EN:
                return _localizedItems[key].En;
            case Languages.ES:
                return _localizedItems[key].Es;
            case Languages.PT:
                return _localizedItems[key].Pt;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum Languages
{
    EN,
    ES,
    PT
}