using UnityEngine;
using System.Collections;

public class Races//create the basics of a race
{
    public string nameSpec { get; set; }
    public double minTemp { get; set; }
    public double maxTemp { get; set; }

    public Races(string nameSpecies, double minTemper, double maxTemper)
    {
        nameSpec = nameSpecies;
        minTemp = minTemper;
        maxTemp = maxTemper;
    }

    
}
