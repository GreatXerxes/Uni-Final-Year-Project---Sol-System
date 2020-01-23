using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    public GUISkin mySkin;//cusom ui skin
    public Texture2D header;//title
    public AudioClip clickSound;//click sound
    public float clickVolume = 1.0f;//click volume

    protected string[] buttons;

    private AudioElement audioElement;

	// Use this for initialization
	protected virtual void Start ()
    {
        SetButtons();//set buttons up
        if (clickVolume < 0.0f) clickVolume = 0.0f;
        if (clickVolume > 1.0f) clickVolume = 1.0f;
        List<AudioClip> sounds = new List<AudioClip>();
        List<float> volumes = new List<float>();
        sounds.Add(clickSound);
        volumes.Add(clickVolume);
        audioElement = new AudioElement(sounds, volumes, "Menu", null);//add the audio element
    }

    protected virtual void OnGUI()//main gui method
    {
        DrawMenu();
    }

    protected virtual void DrawMenu()//d
    {
        //default implementation for a menu consisting of a vertical list of buttons
        GUI.skin = mySkin;
        float menuHeight = GetMenuHeight();

        float groupLeft = Screen.width / 2 - ResourceManager.MenuWidth / 2;
        float groupTop = Screen.height / 2 - menuHeight / 2;
        GUI.BeginGroup(new Rect(groupLeft, groupTop, ResourceManager.MenuWidth, menuHeight));

        //background box
        GUI.Box(new Rect(0, 0, ResourceManager.MenuWidth, menuHeight), "");
        //header image
        GUI.DrawTexture(new Rect(ResourceManager.Padding, ResourceManager.Padding, ResourceManager.HeaderWidth, ResourceManager.HeaderHeight), header);
        float leftPos = ResourceManager.Padding;
        float topPos = 2 * ResourceManager.Padding + header.height;


        //menu buttons
        if (buttons != null)
        {
            leftPos = ResourceManager.MenuWidth / 2 - ResourceManager.ButtonWidth / 2;
            topPos += ResourceManager.TextHeight + ResourceManager.Padding;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i > 0) topPos += ResourceManager.ButtonHeight + ResourceManager.Padding;
                if (GUI.Button(new Rect(leftPos, topPos, ResourceManager.ButtonWidth, ResourceManager.ButtonHeight), buttons[i]))
                {
                    HandleButton(buttons[i]);
                }
            }
        }

        GUI.EndGroup();
    }

    protected virtual void SetButtons()
    {
        
    }

    protected virtual void HandleButton(string text)
    {
        if (audioElement != null) audioElement.Play(clickSound);
        
    }

    protected virtual float GetMenuHeight()
    {
        float buttonHeight = 0;
        if (buttons != null) buttonHeight = buttons.Length * ResourceManager.ButtonHeight;
        float paddingHeight = 2 * ResourceManager.Padding;
        if (buttons != null) paddingHeight += buttons.Length * ResourceManager.Padding;
        float messageHeight = ResourceManager.TextHeight + ResourceManager.Padding;
        return ResourceManager.HeaderHeight + buttonHeight + paddingHeight + messageHeight;
    }

    protected void NewGame()
    {
        HideCurrentMenu();
        NewGame newGame = GetComponent<NewGame>();
        if (newGame)
        {
            newGame.enabled = true;
        }
    }

    protected void LoadGame()
    {
        HideCurrentMenu();
        /*LoadMenu loadMenu = GetComponent<LoadMenu>();//currently disabled
        if (loadMenu)
        {
            loadMenu.enabled = true;
            loadMenu.Activate();
        }*/
    }

    protected virtual void HideCurrentMenu()
    {
        //a child class needs to set this to hide itself when appropriate
    }

    protected void ExitGame()
    {
        Application.Quit();
    }

}
