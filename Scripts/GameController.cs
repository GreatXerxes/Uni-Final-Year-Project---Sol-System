using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int timeCon;

    public GUISkin mySkin;

    private Texture2D picture;

    public Texture2D empire;
    public Texture2D republic;
    public Texture2D federation;
    public Texture2D undefined;

    public static Time gameTime; 

    // Use this for initialization
    void Start ()
    {
        timeCon = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))//Controls game speed
        {
            switch(timeCon)
            {
                case 0:
                    timeCon = 1;
                    break;
                case 1:
                    timeCon = 3;
                    break;
                case 3:
                    timeCon = 5;
                    break;
                case 5:
                    timeCon = 0;
                    break;
                default:
                    break;

            }
        }

        
    }

    void OnGUI()
    {
        GameBar();
        int sizeBase = ObjectList.celestialBodies.Count;
        GUI.Window(90, new Rect(40, 150, 150, 50 + (50 * sizeBase)), DoMyWindow, "");
    }

    //gui code
    void DoMyWindow(int windowID)
    {
        int size = ObjectList.celestialBodies.Count;
        for (int i = 0; i < size; i++)
        {
            GUI.Label(new Rect(10, 50 + (10 * i), 150, 50), ObjectList.celestialBodies[i].nameCele);
        }
    }

    //Creates the main bar across the screen
    void GameBar()
    {
        GUI.skin = mySkin;
        
        GUI.BeginGroup(new Rect(0, 0, 900, 50));

        GUI.Box(new Rect(0, 0, 900, 50), "");

        

        picture = getGovIcon();

        GUI.Button(new Rect(0, 0, 50, 50), picture);

        GUI.EndGroup();
    }

    GameObject getEmpire()
    {
        return GameObject.Find("Player");
    }

    string getGovImage()
    {
        EmpireController.govType govern;
        if (getEmpire() == null)
        {

            govern = EmpireController.govType.UNDEFINED;
            return "Assets/Textures/icons/empire_icon_5_size_50.png";
            //return Resources.Load("Assets/Textures/icons/empire_icon_5_size_50") as Texture2D;
        }
        else
        {
            govern = GameObject.Find("Player").GetComponent<EmpireController>().Gov;
            if (govern == EmpireController.govType.EMPIRE)
            {
                return "Textures/icons/empire_icon_1";

            }
            else if (govern == EmpireController.govType.FEDERATION)
            {
                return "Textures/icons/empire_icon_6";

            }
            else
            {
                return "Textures/icons/empire_icon_14";

            }
        }
        
    }
    //Get Govement type icon and apply it to the gamebar
    Texture2D getGovIcon()
    {
        EmpireController.govType govern;
        if (getEmpire() == null)
        {
            govern = EmpireController.govType.UNDEFINED;
            return undefined;
        }
        else
        {
            govern = GameObject.Find("Player").GetComponent<EmpireController>().Gov;
            if (govern == EmpireController.govType.EMPIRE)
            {
                return empire;

            }
            else if (govern == EmpireController.govType.FEDERATION)
            {
                return federation;

            }
            else
            {
                return republic;

            }
        }
    }

    
}
