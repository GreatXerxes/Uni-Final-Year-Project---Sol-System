using UnityEngine;
using System.Collections;

//Initial attempt to try to store all celestial bodies on the screen - need to expand so that each moon is put under their orbiting planet
public class MenuGUI : MonoBehaviour
{
    bool isOpen;
    GameObject openBody;

    public void open(GameObject body)
    {
        // If we are already open we do nothing.
        if (isOpen)
            return;

        isOpen = true;
        openBody = body;
    }

    public bool isItOpen()
    {
        return isOpen;
    }

    void OnGUI()
    {
        if (isItOpen())
        {
            //GUI.DrawTexture(...);
            GUI.Label(new Rect(10, 10, 100, 20), openBody.name); // or whatever
            GUI.Label(new Rect(10, 20, 100, 20), "Number of planet: " + openBody.GetComponent<CelestialBody>().planetNum);
          if (GUI.Button(new Rect(10, 10, 50, 50), "Close"))
            {
                isOpen = false;
            }
        }
    }
}
