using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CelestialBody : MonoBehaviour
{
    public float speed = 0.1F;
    public static int timeControl;

    //Planetery Data
    public string nameCele = "";
    public float planetDisFromSun;
    public float planetSize = 0.0f;
    public float planetRotationSpeed = 0.0f;
    public float planetOrbitSpeed = 0.0f;
    public int planetNum;
    public double temperature;
    public Races species = null;
    public int population;
    public TYPE planetType;

    private EmpireController owner = null;
    private bool isCapital = false;

    //buildings

    //Army/Unit
    public static int totalInfantry;
    public int infantry;

    public static int totalSettler;
    public int settler;
    Queue<GameUnit> unitQueue = new Queue<GameUnit>();

    bool displayClickMe;
    MenuGUI menuGui;
    bool clicked = false;

    bool infoTab = false;
    bool buildingTab = false;
    bool armyTab = false;

    //Make-shift close all Gui
    static bool GLOBAL_CLICKED = false;


    //Orbit Renderer
    public LineRenderer LR;
    public Transform ThisOrbit;

    // Update is called once per frame
    void Update()
    {
        timeControl = GameController.timeCon;//Time Control

        //transform.Rotate(new Vector3(0.0f, 360.0f/speed * Time.deltaTime, 0.0f));
        //transform.Rotate(new Vector3(0.0f, 360.0f * speed * Time.deltaTime, 0.0f));
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))//Checks if it is the main menu
        {
            transform.Rotate(new Vector3(0.0f, (((speed / 360.0f) * 250) * 3) * Time.deltaTime, 0.0f));//Sets the planet speed to a default value
        }
        else
        {
            transform.Rotate(new Vector3(0.0f, (((speed / 360.0f) * 250) * timeControl) * Time.deltaTime, 0.0f));//Sets planet speed multiplier to the time control times the planet speed
        }

        while (unitQueue.Count > 0)
        {
            StartCoroutine(creationQueueUnit(unitQueue.Peek()));//Unit creation queue
        }
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        //Destroy(this.gameObject);
        //CelestialBody body = gameObject as CelestialBody;
        //Debug.Log(gameObject);
        //Debug.Log(gameObject.GetComponent<CelestialBody>().speed);
        //CelestialBody body = Instantiate(gameObject.g) as CelestialBody;
        if (!GLOBAL_CLICKED)//UI Code
        {
            GLOBAL_CLICKED = true;
            clicked = true;
            infoTab = true;
        }
        //menuGui.open(this.gameObject);



    }

    void OnMouseOver()
    {
        displayClickMe = true;
    }

    void OnMouseExit()
    {
        displayClickMe = false;
    }


    public Rect windowRect = new Rect(20, 20, 800, 800);
    void OnGUI()
    {
        /*if (displayClickMe && !menuGui.isItOpen())
        {
            // Draw the small 'ClickMe' GUI.
            //GUI.DrawTexture.yourTexture;
        }*/
        if (clicked)
        {

            windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");//Draws UI Window

            /*GUI.Label(new Rect(10, 20, 250, 50), "Number of planet: " + gameObject.GetComponent<CelestialBody>().nameCele);
            GUI.Label(new Rect(10, 50, 250, 50), "Number of planet: " + gameObject.GetComponent<CelestialBody>().planetNum);
            GUI.Label(new Rect(10, 80, 250, 50), "Distance from Orbiting: " + gameObject.GetComponent<CelestialBody>().planetDisFromSun);
            GUI.Label(new Rect(10, 110, 250, 50), "Size: " + gameObject.GetComponent<CelestialBody>().planetSize);
            GUI.Label(new Rect(10, 140, 250, 50), "Rotation Speed: " + gameObject.GetComponent<CelestialBody>().planetNum);
            GUI.Label(new Rect(10, 170, 250, 50), "Orbiting Speed: " + gameObject.GetComponent<CelestialBody>().planetNum);
            //GUI.Label(new Rect(10, 20, 250, 50), "Number of planet: " + gameObject.GetComponent<CelestialBody>().planetNum);


            if (GUI.Button(new Rect(10, 190, 50, 50), "Close"))
            {
                clicked = false;
            }*/
        }
    }


    //TODO - Smooth out the method and make it look cleaner
    void DoMyWindow(int windowID)//Different tabs on the UI
    {
        if (GUI.Button(new Rect(5, 20, 100, 20), "Planet Info"))
        {
            print(nameCele);
            infoTab = true;
            buildingTab = false;
            armyTab = false;
        }
        if (owner != null )
        {
            if (GUI.Button(new Rect(105, 20, 100, 20), "Buildings"))
            {
                infoTab = false;
                buildingTab = true;
                armyTab = false;
            }
            if (GUI.Button(new Rect(205, 20, 100, 20), "Military"))
            {
                infoTab = false;
                buildingTab = false;
                armyTab = true;
            }
        }   

        if (GUI.Button(new Rect(305, 20, 100, 20), "Close"))
            {
                GLOBAL_CLICKED = false;
                clicked = false;
            }
       if (infoTab)
        {
            GUI.Label(new Rect(5, 55, 250, 50), "Name of planet: " + gameObject.GetComponent<CelestialBody>().nameCele);
            GUI.Label(new Rect(5, 85, 250, 50), "Number of planet: " + gameObject.GetComponent<CelestialBody>().planetNum);
            GUI.Label(new Rect(5, 115, 250, 50), "Distance from Orbiting: " + gameObject.GetComponent<CelestialBody>().planetDisFromSun);
            GUI.Label(new Rect(5, 145, 250, 50), "Size: " + gameObject.GetComponent<CelestialBody>().planetSize);
            GUI.Label(new Rect(5, 175, 250, 50), "Rotation Speed: " + gameObject.GetComponent<CelestialBody>().planetNum);
            GUI.Label(new Rect(5, 205, 250, 50), "Orbiting Speed: " + gameObject.GetComponent<CelestialBody>().planetNum);
            GUI.Label(new Rect(5, 235, 250, 50), "Owner: " + gameObject.GetComponent<CelestialBody>().owner.name);
            GUI.Label(new Rect(5, 265, 250, 50), "Species: " + gameObject.GetComponent<CelestialBody>().species.nameSpec);
            GUI.Label(new Rect(5, 295, 250, 50), "Population: " + gameObject.GetComponent<CelestialBody>().population);



        }
        if (armyTab)
        {
            GUI.Label(new Rect(5, 55, 250, 50), "Number of Intantry: " + gameObject.GetComponent<CelestialBody>().infantry);


            if (GUI.Button(new Rect(255, 55, 100, 20), "Create Infantry"))
            {
                
            }
            GUI.Label(new Rect(5, 105, 250, 50), "Number of settlers: " + gameObject.GetComponent<CelestialBody>().settler);


            if (GUI.Button(new Rect(255, 105, 100, 20), "Create Settler"))
            {
                if (population >= 2000)
                {
                    population = population - 1000;
                    unitQueue.Enqueue(new Settler());
                }
            }
        }

        //GUI.DragWindow();

    }

    public IEnumerator creationQueueUnit(GameUnit unit)//Unit creation
    {
        yield return new WaitForSeconds(unit.Cost);
        unitQueue.Dequeue();
        if (unit.Type.Equals(GameUnit.UTYPE.INFANTRY))
        {
            infantry += 1;
        }
        else if (unit.Type.Equals(GameUnit.UTYPE.SETTLER))
        {
            settler += 1;
        }
    }

    public enum TYPE
    {
        TERRESTRIAL,
        GAS_GIANT,
        ICE_GIANT,
        DWARF,
        MOON,
        LUSH,
        OCEAN,
        LAVA,
        TROPICIAL,
        TUNDRA
    }

    public EmpireController Owner
    {
        get { return owner; }
        set { owner = value; }
    }
}
