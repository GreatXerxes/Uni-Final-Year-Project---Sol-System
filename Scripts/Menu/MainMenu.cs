using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{

    protected override void SetButtons()
    {
        buttons = new string[] { "New Game", "Load Game", "Quit Game" };//buttons used
    }

    protected override void HandleButton(string text)//handle what the buttons do
    {
        base.HandleButton(text);
        switch (text)
        {
            case "New Game": NewGame(); break;
            //case "Load Game": LoadGame(); break;
            case "Quit Game": ExitGame(); break;
            //case "Change Player": ChangePlayer(); break;
            default: break;
        }
    }

    protected override void HideCurrentMenu()
    {
        GetComponent<MainMenu>().enabled = false;
    }

}
