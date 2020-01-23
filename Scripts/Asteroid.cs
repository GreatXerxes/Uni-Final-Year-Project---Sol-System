using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Wanted to add asteroids and collision 
public class Asteroid : MonoBehaviour
{
    public float speed = 0.1F;
    public static int timeControl;

    // Use this for initialization
    void Start () {
	
	}

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

    }
}
