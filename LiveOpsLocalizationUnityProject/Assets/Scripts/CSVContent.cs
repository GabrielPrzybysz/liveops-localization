using System.Collections;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using UnityEngine;

public class CSVContent
{
    [Index(0)] public string KEY { get; set; }
    [Index(1)] public string en { get; set; }
    [Index(2)] public string pt { get; set; }
    [Index(3)] public string es { get; set; }
}
