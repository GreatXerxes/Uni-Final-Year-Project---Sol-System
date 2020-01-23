using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EmpireController : MonoBehaviour
{
    private string empireName;
    private int wealth;
    private Races spec = null;

    private govType gov;

    private GameObject homeWorld = null;

    private List<CelestialBody> ownedBodies = new List<CelestialBody>();//list of owned planets

	// Use this for initialization
	 protected virtual void Start()
    {
        wealth = 10000;
	}

    // Update is called once per frame
    protected virtual void Update()
    {
	    if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
        {
            if (homeWorld == null)
            {
                //Make the controller look for habitable planet
                GameObject tempHome = GameObject.Find("Earth");
                homeWorld = tempHome;
                tempHome.GetComponent<CelestialBody>().Owner = this;
            }
        }
	}

    public enum govType
    {
        UNDEFINED,
        EMPIRE,
        FEDERATION,
        REPUBLIC
    }
    //Getters and Setters

    public string EmpireName
    {
        get { return empireName; }
        set { empireName = value; }
    }

    public int Wealth
    {
        get { return wealth; }
        set { wealth = value; }
    }

    public Races Race
    {
        get { return spec; }
        set { spec = value; }
    }

    public govType Gov
    {
        get { return gov; }
        set { gov = value; }
    }


    public string toString()
    {
        string s = empireName + "/n";
        s = s + "has " + wealth + "credits/n";
        return s;
    }
}
