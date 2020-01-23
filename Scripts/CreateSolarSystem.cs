using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CreateSolarSystem : MonoBehaviour
{
    public float minSunSize = 100.0f;
    public float maxSunSize = 500.0f;

    public int minPlanets = 3;
    public int maxPlanets = 15;
    public float minPlanetSize = 0.5f;
    public float maxPlanetSize = 50.0f;
    public float minPlanetDistance = 100.0f;
    public float maxPlanetDistance = 500.0f;
    public float minPlanetRotationSpeed = 10.0f;//-30   Cause the rotation to be the opposite direction
    public float maxPlanetRotationSpeed = 30.0f;
    public float minPlanetOrbitSpeed = 10.0f;//-30
    public float maxPlanetOrbitSpeed = 30.0f;

    public int minMoonsPerPlanet = 0;
    public int maxMoonsPerPlanet = 5;
    public float minMoonSize = 0.01f;
    public float maxMoonSize = 0.1f;
    public float minMoonDistance = 1.0f;
    public float maxMoonDistance = 1.0f;
    public float minMoonRotationSpeed = 1.0f;//-10
    public float maxMoonRotationSpeed = 10.0f;
    public float minMoonOrbitSpeed = 1.0f;//-10
    public float maxMoonOrbitSpeed = 10.0f;

    public CelestialBody sunPrefab;
    public CelestialBody planetPrefab;
    public CelestialBody moonPrefab;


    private List<CelestialBody> planets = new List<CelestialBody>();

    //Draw Obit
    int Segments = 100;
    Texture2D DisplayTexture;
    int DisplayTiling = 50;

    // Use this for initialization
    void Start ()
    {
        //Set up Sun and SunChildren
        CelestialBody sunInstance = Instantiate(sunPrefab, transform.position, transform.rotation) as CelestialBody;
        sunInstance.transform.localScale = Vector3.one * Random.Range(minSunSize, maxSunSize);

        //Determine number of planets and set up planets
        int numPlanets = RandomStuff.Randomiser(minPlanets, maxPlanets + 1);//Randomising planet num

        float planetDistance = sunInstance.transform.localScale.magnitude / 2.0f;

        for(int i = 0; i < numPlanets; i++)
        {

            //Variables
            planetDistance += RandomStuff.Randomiser(minPlanetDistance, maxPlanetDistance);//Randomising planet dis
            float planetSize = RandomStuff.Randomiser(minPlanetSize, maxPlanetSize);//Randomising planet size
            float planetRotationSpeed = RandomStuff.Randomiser(minPlanetRotationSpeed, maxPlanetRotationSpeed);//Randomising planet speed
            float planetOrbitSpeed = RandomStuff.Randomiser(minPlanetOrbitSpeed, maxPlanetOrbitSpeed);//Randomising planet orbit speed

            CelestialBody planet = SetupCelestialBody(planetPrefab, sunInstance, planetDistance, planetSize, planetRotationSpeed, planetOrbitSpeed);

            int numMoons = RandomStuff.Randomiser(minMoonsPerPlanet, maxMoonsPerPlanet);//Randomising num of moons

            float moonDistance = planet.transform.localScale.magnitude / 2.0f;

            for (int j = 0; j < numMoons; j++)
            {
                //Variables
                moonDistance += RandomStuff.Randomiser(minMoonDistance, maxMoonDistance);//Randomising moon dis
                float moonSize = RandomStuff.Randomiser(minMoonSize, maxMoonSize);//Randomising moon size
                float moonRotationSpeed = RandomStuff.Randomiser(minMoonRotationSpeed, maxMoonRotationSpeed);//Randomising moon speed
                float moonOrbitSpeed = RandomStuff.Randomiser(minMoonOrbitSpeed, maxMoonOrbitSpeed);//Randomising moon orbit speed

                CelestialBody moon = SetupCelestialBody(moonPrefab, planet, moonDistance, moonSize, moonRotationSpeed, moonOrbitSpeed);
            }

        }
    }

    CelestialBody SetupCelestialBody(CelestialBody prefab, CelestialBody parent, float distance, float size, float rotationSpeed, float orbitSpeed)// planet create
    {
        CelestialBody planetInstance = Instantiate(prefab, parent.transform.position + Vector3.forward * distance, transform.rotation) as CelestialBody;//creates the object
        planetInstance.transform.localScale = Vector3.one * size;//sets values
        planetInstance.speed = rotationSpeed;

        GameObject planetStrut = new GameObject("PlanetStrut");//create another object tied to the planet
        planetStrut.transform.position = parent.transform.position;
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

        planetInstance.GetComponent<Renderer>().material.color = planetColour;
        /********************************************************************/

        //create orbit lines
        SetUpOrbit(parent, planetInstance, planetColour, distance);


        return planetInstance;
    }

    void SetUpOrbit(CelestialBody body, CelestialBody newBody, Color color, float distance)//create orbit path
    {
        GameObject Orbit = new GameObject("Orbit_Path");

        Orbit.transform.parent = body.transform;//may need to change it from parent to the new planet
        Orbit.transform.position = body.transform.position;
        Orbit.AddComponent<LineRenderer>();
        newBody.LR = Orbit.GetComponent<LineRenderer>();

        float displaySize = newBody.transform.lossyScale.magnitude / 2.0f;

        newBody.LR.SetWidth(displaySize, displaySize);//set the width to be the same as the celestial body
        newBody.LR.material.shader = Shader.Find("Particles/Additive");
        newBody.LR.material.SetColor("_TintColor", color);
        newBody.LR.useWorldSpace = false;
        newBody.LR.SetVertexCount(Segments + 1);

        if (DisplayTexture != null)
        {
            newBody.LR.material.mainTexture = DisplayTexture;
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
