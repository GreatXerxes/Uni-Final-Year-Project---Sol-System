using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    public GUISkin mainSkin;//set UI look
    public AudioClip clickSound;//click sound
    public float clickVolume = 1.0f;//click volume

    public AudioElement audioElement;

    string text = "";
    Races selectedRace;//selected player race
    bool pressed = true;
    string description;//government description

    GUIContent[] comboBoxList;
    private ComboBox comboBoxControl;// = new ComboBox();
    private GUIStyle listStyle = new GUIStyle();

    Dropdown dropdown;

    private string gameName = "";
    private EmpireController.govType gov = EmpireController.govType.UNDEFINED;

    GameObject playerInstance;


    // Use this for initialization
    void Start ()
    {
        ObjectList.Start();


        if (clickVolume < 0.0f) clickVolume = 0.0f;
        if (clickVolume > 1.0f) clickVolume = 1.0f;
        List<AudioClip> sounds = new List<AudioClip>();
        List<float> volumes = new List<float>();
        sounds.Add(clickSound);
        volumes.Add(clickVolume);
        audioElement = new AudioElement(sounds, volumes, "NewGame", null);

        comboBoxList = new GUIContent[ObjectList.racesList.Count];
        for (int i = 0; i < ObjectList.racesList.Count; i++)
        {
            comboBoxList[i] = new GUIContent(ObjectList.racesList[i].nameSpec);
        }

        listStyle.normal.textColor = Color.white;
        listStyle.onHover.background =
        listStyle.hover.background = new Texture2D(2, 2);

        playerInstance = new GameObject();
        playerInstance.AddComponent<EmpireController>();

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) CancelNewGame();
    }
    void LateUpdate()
    {
        description = getDestription();
    }

    void OnGUI()
    {
        /*if (SelectionList.MouseDoubleClick())
        {
            PlayClick();
            StartLoad();
        }*/

        GUI.skin = mainSkin;
        float menuHeight = GetMenuHeight();
        float groupLeft = Screen.width / 2 - ResourceManager.MenuWidth / 2;
        float groupTop = Screen.height / 2 - menuHeight / 2;
        Rect groupRect = new Rect(groupLeft, groupTop, ResourceManager.MenuWidth, menuHeight);
        GUI.BeginGroup(groupRect);
        //background box
        GUI.Box(new Rect(0, 0, ResourceManager.MenuWidth, menuHeight), "");
        //menu buttons
        float leftPos = ResourceManager.Padding;
        float topPos = menuHeight - ResourceManager.Padding - ResourceManager.ButtonHeight;
        if (GUI.Button(new Rect(leftPos, topPos, ResourceManager.ButtonWidth, ResourceManager.ButtonHeight), "Create New Game"))
        {
            PlayClick();
            if (text != "" && selectedRace != null && gov == EmpireController.govType.EMPIRE || gov == EmpireController.govType.REPUBLIC || gov == EmpireController.govType.FEDERATION)
            {
                StartNewGame(text, selectedRace, gov);
            }
            
        }
        leftPos += ResourceManager.ButtonWidth + ResourceManager.Padding;
        if (GUI.Button(new Rect(leftPos, topPos, ResourceManager.ButtonWidth, ResourceManager.ButtonHeight), "Cancel"))
        {
            PlayClick();
            CancelNewGame();
        }

        GUI.Label(new Rect(ResourceManager.Padding, 5, 120, 40), "Set Name of game government: ");
        text = GUI.TextField(new Rect(ResourceManager.Padding + 125, 5, 135, 40), text);//Empire name


        GUI.Label(new Rect(ResourceManager.Padding, 55, 120, 40), "Set Main Race: ");
        //comboBoxControl = new ComboBox(new Rect(ResourceManager.Padding + 125, 65, 100, 20), comboBoxList[0], comboBoxList, "button", "box", listStyle);
        //int selectedItemIndex = comboBoxControl.Show();
        //selectedRace = ObjectList.racesList[selectedItemIndex];//empire race
        if (GUI.Button(new Rect(ResourceManager.Padding + 125, 65, 100, 20), "Human"))
        {
            selectedRace = ObjectList.human;
        }

        GUI.Label(new Rect(ResourceManager.Padding, 110, 120, 40), "Set Govement Type: ");//set kind of government
        if (GUI.Button(new Rect(ResourceManager.Padding + 125, 100, 100, 20), "Empire"))
        {
            gov = EmpireController.govType.EMPIRE;
        }
        if (GUI.Button(new Rect(ResourceManager.Padding + 125, 125, 100, 20), "Republic"))
        {
            gov = EmpireController.govType.REPUBLIC;
        }
        if (GUI.Button(new Rect(ResourceManager.Padding + 125, 150, 100, 20), "Federation"))
        {
            gov = EmpireController.govType.FEDERATION;
        }

        GUI.Label(new Rect(ResourceManager.Padding, 85, 250, 250), description);//update description

        GUI.EndGroup();

        //selection list, needs to be called outside of the group for the menu
        float selectionLeft = groupRect.x + ResourceManager.Padding;
        float selectionTop = groupRect.y + ResourceManager.Padding;
        float selectionWidth = groupRect.width - 2 * ResourceManager.Padding;
        float selectionHeight = groupRect.height - GetMenuItemsHeight() - ResourceManager.Padding;
        //SelectionList.Draw(selectionLeft, selectionTop, selectionWidth, selectionHeight, selectionSkin);
    }

    private void PlayClick()
    {
        if (audioElement != null) audioElement.Play(clickSound);
    }

    private float GetMenuHeight()
    {
        return 250 + GetMenuItemsHeight();
    }

    private float GetMenuItemsHeight()
    {
        return ResourceManager.ButtonHeight + 2 * ResourceManager.Padding;
    }

    /*public void Activate()
    {
        SelectionList.LoadEntries(PlayerManager.GetSavedGames());
    }*/

    private void StartNewGame(string name, Races race, EmpireController.govType gov)//Attempt to start a new game
    {
        //string newLevel = SelectionList.GetCurrentEntry();
        /*if (newLevel != "")
        {
            ResourceManager.LevelName = newLevel;
            if (Application.loadedLevelName != "BlankMap1") Application.LoadLevel("BlankMap1");
            else if (Application.loadedLevelName != "BlankMap2") Application.LoadLevel("BlankMap2");
            //makes sure that the loaded level runs at normal speed
            Time.timeScale = 1.0f;
        }*/
        playerInstance.GetComponent<EmpireController>().name = "Player";
        playerInstance.GetComponent<EmpireController>().EmpireName = name;
        playerInstance.GetComponent<EmpireController>().Race = race;
        playerInstance.GetComponent<EmpireController>().Gov = gov;


        DontDestroyOnLoad(playerInstance);//prevent this player object from disappearing when scene changes
        SceneManager.LoadScene("SolarSystemTest");
        
        //playerInstance.

    }

    private void CancelNewGame()
    {
        GetComponent<NewGame>().enabled = false;
        MainMenu main = GetComponent<MainMenu>();
        if (main) main.enabled = true;
        
    }

    string getDestription()
    {
        string s = "";
        if (selectedRace == null)
        {
            s = s + "No race has been chosen\n\n";
        }
        if (gov.Equals(EmpireController.govType.UNDEFINED))
        {
            s = s + "government type is undefined";
        }

        return s;
    }
}
