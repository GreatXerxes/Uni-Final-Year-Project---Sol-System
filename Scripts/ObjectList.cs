using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectList//A storage point for all the races and celestial bodies in the game
{
    public static List<Races> racesList = new List<Races>();
    public static List<CelestialBody> celestialBodies = new List<CelestialBody>();


    public static Races human;
    public static Races plutonians;

    // Use this for initialization
   public static void Start ()
    {
        human = new Races("Humans", -60, 42.2);
        addRacesToList(human);
        plutonians = new Races("Plutonians", -290, -240);
        addRacesToList(plutonians);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    static void addRacesToList(Races spec)
    {
        racesList.Add(spec);
    }
}
