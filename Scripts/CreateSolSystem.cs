using UnityEngine;
using System.Collections;

public class CreateSolSystem : MonoBehaviour
{
    //Sun
    public float solSize = 109f;
    public CelestialBody prefabSun;
    //Mercury
    public float mercurySize = 0.333333f;
    public int mercuryMoons = 0;
    public float mercuryDisSun = 5.761f;
    public float mercuryRotationSpeed = 10.982f;
    public float mercuryOrbitSpeed = 56.6f;
    public CelestialBody prefabMercury;

    //Venus
    public float venusSize = 0.9496154f;
    public int venusMoons = 0;
    public float venusDisSun = 10.82f;
    public float venusRotationSpeed = 6.5f;
    public float venusOrbitSpeed = 35.02139f;
    public CelestialBody prefabVenus;

    //Earth
    public float earthSize = 1.0f;
    public int earthMoons = 1;
    public float earthDisSun = 14.96f;
    public float earthRotationSpeed = 1673.71776f;
    public float earthOrbitSpeed = 30f;
    public CelestialBody prefabEarth;

    //Mars
    public float marsSize = 0.5330403f;
    public int marsMoons = 2;
    public float marsDisSun = 22.79f;
    public float marsRotationSpeed = 868.22f;
    public float marsOrbitSpeed = 24f;
    public CelestialBody prefabMars;

    //Jupiter
    public float jupiterSize = 10.9733166f;
    public int jupiterMoons = 67;
    public float jupiterDisSun = 77.82f;
    public float jupiterRotationSpeed = 45061.632f;
    public float jupiterOrbitSpeed = 13.069722f;
    public CelestialBody prefabJupiter;

    //Saturn
    public float saturnSize = 9.1401664f;
    public int saturnMoons = 53;
    public float saturnDisSun = 143.3f;
    public float saturnRotationSpeed = 36000f;
    public float saturnOrbitSpeed = 9.6725f;
    public CelestialBody prefabSaturn;

    //Uranus
    public float uranusSize = 3.9808507f;
    public int uranusMoons = 27;
    public float uranusDisSun = 287.7f;
    public float uranusRotationSpeed = 2983.752f;
    public float uranusOrbitSpeed = 6.8353f;
    public CelestialBody prefabUranus;

    //Neptune
    public float neptuneSize = 3.8646994f;
    public int neptuneMoons = 14;
    public float neptuneDisSun = 449.8f;
    public float neptuneRotationSpeed = 2896.0704f;
    public float neptuneOrbitSpeed = 5.4778f;
    public CelestialBody prefabNeptune;

    //Pluto
    public float plutoSize = 0.1823889f;
    public int plutoMoons = 5;
    public float plutoDisSun = 590.6f;
    public float plutoRotationSpeed = 15.4728f;
    public float plutoOrbitSpeed = 4.74889f;
    public CelestialBody prefabPluto;


    //Moons
    public float moonSize = 0.2726417f;
    public float minMoonSize = 0.01f;
    public float maxMoonSize = 0.1f;
    public float minMoonDistance = 1.0f;
    public float maxMoonDistance = 1.0f;
    public float minMoonRotationSpeed = 1.0f;//-10
    public float maxMoonRotationSpeed = 1000.0f;
    public float minMoonOrbitSpeed = 50.0f;//-10
    public float maxMoonOrbitSpeed = 150.0f;
    public CelestialBody prefabMoon;

    public int numOfPlanets = 9;

    //Draw Obit
    int Segments = 100;
    Texture2D DisplayTexture;//Broken for some reason
    int DisplayTiling = 50;
    public Material orbitMaterial;


    // Use this for initialization
    void Start ()
    {
        ObjectList.Start();

        //Set up Sun and SunChildren
        CelestialBody sunInstance = Instantiate(prefabSun, transform.position, transform.rotation) as CelestialBody;//creates Sol
        sunInstance.transform.localScale = Vector3.one * solSize;
        //sunInstance.speed = 4400;//removed as it causes the solar system to speed up

        //Determine number of planets and set up planets
        int numPlanets = numOfPlanets + 1;

        float planetDistance = sunInstance.transform.localScale.magnitude / 2.0f;

        for (int i = 1; i < numPlanets; i++)//For loop to go through num of planets to add them to the game
        {

            switch (i)
            {
                case 1:
                    planetDistance += mercuryDisSun;

                    CelestialBody mercury = SetupCelestialBody(prefabMercury, sunInstance, planetDistance, mercurySize, mercuryRotationSpeed, mercuryOrbitSpeed, "Mercury", i, null, 0);
                    continue;
                case 2:
                    planetDistance += venusDisSun;

                    CelestialBody venus = SetupCelestialBody(prefabVenus, sunInstance, planetDistance, venusSize, venusRotationSpeed, venusOrbitSpeed, "Venus", i, null, 0);
                    continue;

                case 3:
                    planetDistance += earthDisSun;

                    CelestialBody earth = SetupCelestialBody(prefabEarth, sunInstance, planetDistance, earthSize, earthRotationSpeed, earthOrbitSpeed, "Earth", i, ObjectList.human, 50000);

                    float lunaDistance = earth.transform.localScale.magnitude / 2.0f;

                    for (int j = 0; j < earthMoons; j++)
                    {
                        //Variables
                        lunaDistance += 3.844f;
                        float lunaSize = 0.27f;
                        float lunaRotationSpeed = Random.Range(minMoonRotationSpeed, maxMoonRotationSpeed);
                        float lunaOrbitSpeed = 102.2f;

                        CelestialBody moon = SetupCelestialBody(prefabMoon, earth, lunaDistance, lunaSize, lunaRotationSpeed, lunaOrbitSpeed, "Luna", j+1, null, 0);

                    }

                    continue;

                case 4:
                    planetDistance += marsDisSun;

                    CelestialBody mars = SetupCelestialBody(prefabMars, sunInstance, planetDistance, marsSize, marsRotationSpeed, marsOrbitSpeed, "Mars", i, null, 0);

                    float marsMoonDistance = mars.transform.localScale.magnitude / 2.0f;

                    for (int j = 0; j < marsMoons; j++)
                    {
                        //Variables
                        marsMoonDistance += Random.Range(minMoonDistance, maxMoonDistance); 
                        float moonSize = Random.Range(minMoonSize, maxMoonSize);
                        float moonRotationSpeed = Random.Range(minMoonRotationSpeed, maxMoonRotationSpeed);
                        float moonOrbitSpeed = Random.Range(minMoonOrbitSpeed, maxMoonOrbitSpeed);

                        CelestialBody moon = SetupCelestialBody(prefabMoon, mars, marsMoonDistance, moonSize, moonRotationSpeed, moonOrbitSpeed, "Moon", j+1, null, 0);
                    }

                    continue;


                case 5:
                    planetDistance += jupiterDisSun;

                    CelestialBody jupiter = SetupCelestialBody(prefabJupiter, sunInstance, planetDistance, jupiterSize, jupiterRotationSpeed, jupiterOrbitSpeed, "Jupiter", i, null, 0);

                    float jupiterMoonDistance = jupiter.transform.localScale.magnitude / 2.0f;

                    for (int j = 0; j < jupiterMoons; j++)
                    {
                        //Variables
                        jupiterMoonDistance += Random.Range(minMoonDistance, maxMoonDistance);
                        float moonSize = Random.Range(minMoonSize, maxMoonSize);
                        float moonRotationSpeed = Random.Range(minMoonRotationSpeed, maxMoonRotationSpeed);
                        float moonOrbitSpeed = Random.Range(minMoonOrbitSpeed, maxMoonOrbitSpeed);

                        CelestialBody moon = SetupCelestialBody(prefabMoon, jupiter, jupiterMoonDistance, moonSize, moonRotationSpeed, moonOrbitSpeed, "Moon", j + 1, null, 0);
                    }

                    continue;


                case 6:
                    planetDistance += saturnDisSun;

                    CelestialBody saturn = SetupCelestialBody(prefabSaturn, sunInstance, planetDistance, saturnSize, saturnRotationSpeed, saturnOrbitSpeed, "Saturn", i, null, 0);

                    float saturnMoonDistance = saturn.transform.localScale.magnitude / 2.0f;

                    for (int j = 0; j < saturnMoons; j++)
                    {
                        //Variables
                        saturnMoonDistance += Random.Range(minMoonDistance, maxMoonDistance);
                        float moonSize = Random.Range(minMoonSize, maxMoonSize);
                        float moonRotationSpeed = Random.Range(minMoonRotationSpeed, maxMoonRotationSpeed);
                        float moonOrbitSpeed = Random.Range(minMoonOrbitSpeed, maxMoonOrbitSpeed);

                        CelestialBody moon = SetupCelestialBody(prefabMoon, saturn, saturnMoonDistance, moonSize, moonRotationSpeed, moonOrbitSpeed, "Moon", j + 1, null, 0);
                    }

                    continue;


                case 7:
                    planetDistance += uranusDisSun;

                    CelestialBody uranus = SetupCelestialBody(prefabUranus, sunInstance, planetDistance, uranusSize, uranusRotationSpeed, uranusOrbitSpeed, "Uranus", i, null, 0);

                    float uranusMoonDistance = uranus.transform.localScale.magnitude / 2.0f;

                    for (int j = 0; j < uranusMoons; j++)
                    {
                        //Variables
                        uranusMoonDistance += Random.Range(minMoonDistance, maxMoonDistance);
                        float moonSize = Random.Range(minMoonSize, maxMoonSize);
                        float moonRotationSpeed = Random.Range(minMoonRotationSpeed, maxMoonRotationSpeed);
                        float moonOrbitSpeed = Random.Range(minMoonOrbitSpeed, maxMoonOrbitSpeed);

                        CelestialBody moon = SetupCelestialBody(prefabMoon, uranus, uranusMoonDistance, moonSize, moonRotationSpeed, moonOrbitSpeed, "Moon", j + 1, null, 0);
                    }

                    continue;

                case 8:
                    planetDistance += neptuneDisSun;

                    CelestialBody neptune = SetupCelestialBody(prefabNeptune, sunInstance, planetDistance, neptuneSize, neptuneRotationSpeed, neptuneOrbitSpeed, "Neptune", i, null, 0);

                    float neptuneMoonDistance = neptune.transform.localScale.magnitude / 2.0f;

                    for (int j = 0; j < neptuneMoons; j++)
                    {
                        //Variables
                        neptuneMoonDistance += Random.Range(minMoonDistance, maxMoonDistance);
                        float moonSize = Random.Range(minMoonSize, maxMoonSize);
                        float moonRotationSpeed = Random.Range(minMoonRotationSpeed, maxMoonRotationSpeed);
                        float moonOrbitSpeed = Random.Range(minMoonOrbitSpeed, maxMoonOrbitSpeed);

                        CelestialBody moon = SetupCelestialBody(prefabMoon, neptune, neptuneMoonDistance, moonSize, moonRotationSpeed, moonOrbitSpeed, "Moon", j + 1, null, 0);
                    }

                    continue;

                case 9:
                    planetDistance += plutoDisSun;

                    CelestialBody pluto = SetupCelestialBody(prefabPluto, sunInstance, planetDistance, plutoSize, plutoRotationSpeed, plutoOrbitSpeed, "Pluto", i, null, 0);

                    float plutoMoonDistance = pluto.transform.localScale.magnitude / 2.0f;

                    for (int j = 0; j < plutoMoons; j++)
                    {
                        //Variables
                        plutoMoonDistance += Random.Range(minMoonDistance, maxMoonDistance);
                        float moonSize = Random.Range(minMoonSize, maxMoonSize);
                        float moonRotationSpeed = Random.Range(minMoonRotationSpeed, maxMoonRotationSpeed);
                        float moonOrbitSpeed = Random.Range(minMoonOrbitSpeed, maxMoonOrbitSpeed);

                        CelestialBody moon = SetupCelestialBody(prefabMoon, pluto, plutoMoonDistance, moonSize, moonRotationSpeed, moonOrbitSpeed, "Moon", j + 1, null, 0);
                    }

                    //Gateway gate = (Gateway)SetupCelestialBody(prefabMoon, pluto, plutoMoonDistance, 5, 10, 3, "GateWay", plutoMoons, null, 0);

                    continue;

                default:
                    break;
            }

        }

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    CelestialBody SetupCelestialBody(CelestialBody prefab, CelestialBody parent, float distance, float size, float rotationSpeed, float orbitSpeed, string name, int planetNum, Races spec, int pop)//creates the planet
    {
        CelestialBody planetInstance = Instantiate(prefab, parent.transform.position + Vector3.forward * distance, transform.rotation) as CelestialBody;//creates the object
        planetInstance.transform.localScale = Vector3.one * size;//sets values
        planetInstance.speed = rotationSpeed;

        //Setting Variables in Celestial Body **PROB WON'T NEED LATER ON**
        planetInstance.planetDisFromSun = distance;
        planetInstance.planetRotationSpeed = rotationSpeed;
        planetInstance.planetSize = size;
        planetInstance.planetNum = planetNum;
        planetInstance.nameCele = name;
        planetInstance.species = spec;
        planetInstance.name = name;

        GameObject planetStrut = new GameObject("PlanetStrut");//create another object tied to the planet
        planetStrut.transform.position = parent.transform.position;//sets information to it
        CelestialBody planetStrutCeletialBody = planetStrut.AddComponent<CelestialBody>();
        planetStrutCeletialBody.speed = orbitSpeed;
        planetInstance.transform.parent = planetStrut.transform;
        planetStrut.transform.parent = parent.transform;

        //*****Creates a trail for the planets......not needed anymore as orbit lines have been drawn
        Color planetColour = new Color(Random.value, Random.value, Random.value);

        TrailRenderer trail = planetInstance.GetComponentInChildren<TrailRenderer>();

        if (trail != null)
        {
            trail.material.color = planetColour;
            trail.startWidth = planetInstance.transform.lossyScale.magnitude / 2.0f;
            trail.endWidth = 0.0f;
        }
        /********************************************************************/
        //create orbit lines
        SetUpOrbit(parent, planetInstance, planetColour, distance);
        //Adds the celesial bodies to a list
        ObjectList.celestialBodies.Add(planetInstance);

        return planetInstance;
    }

    void SetUpOrbit(CelestialBody body, CelestialBody newBody, Color color, float distance)//creates Orbit path
    {
        GameObject Orbit = new GameObject("Orbit_Path");

        Orbit.transform.parent = body.transform;//may need to change it from parent to the new planet
        Orbit.transform.position = body.transform.position;
        Orbit.AddComponent<LineRenderer>();
        newBody.LR = Orbit.GetComponent<LineRenderer>();

        float displaySize = newBody.transform.lossyScale.magnitude / 2.0f;

        //newBody.LR.SetWidth(displaySize, displaySize);//set the width to be the same as the celestial body
        newBody.LR.startWidth = displaySize;
        newBody.LR.endWidth = displaySize;
        
        newBody.LR.material.shader = Shader.Find("Particles/Additive");
        newBody.LR.material.SetColor("_TintColor", color);
        newBody.LR.useWorldSpace = false;
        //newBody.LR.SetVertexCount(Segments + 1);
        newBody.LR.positionCount = Segments + 1;

        /*if (DisplayTexture != null)//No longer working?
        {
            newBody.LR.material.mainTexture = DisplayTexture;
            newBody.LR.material.mainTextureScale = newBody.LR.material.mainTextureScale + new Vector2(DisplayTiling, 0);
        }

        if (DisplayTexture == null)
        {
            Debug.Log("Something fucked up bro");
        }*/

        if (orbitMaterial != null)
        {
            newBody.LR.material = orbitMaterial;
            newBody.LR.material.mainTextureScale = newBody.LR.material.mainTextureScale + new Vector2(DisplayTiling, 0);
        }


        newBody.ThisOrbit = Orbit.transform;

        float Angle = 0;
        for (int i = 0; i < (Segments + 1); i++)
        {
            Vector2 NewRadius = new Vector2(Mathf.Sin(Mathf.Deg2Rad * Angle) * distance, Mathf.Cos(Mathf.Deg2Rad * Angle) * distance);

            newBody.LR.SetPosition(i, new Vector3(NewRadius.y, 0, NewRadius.x));
            Angle += (360f / Segments);
        }
    }
}
