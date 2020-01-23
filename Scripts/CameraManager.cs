using UnityEngine;
using System.Collections;


public class CameraManager : MonoBehaviour
{
    private float zoomSpeed = 100.0f;
    private float moveSpeed = 100.0f;

    private int MIN_X = -1700;
    private int MAX_X = 1700;

    private int MIN_Y = 20;
    private int MAX_Y = 860;

    private int MIN_Z = -1700;
    private int MAX_Z = 1700;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;//moves camera backwards
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;//moves camera forwards
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;//moves camera right
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;//moves camera left
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MIN_X, MAX_X), transform.position.y, Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));//limits movement

        //Testing to see if I can use the middle mouse button to move the camera
        /*if (Input.GetKey(KeyCode.Mouse2))
        {
            Debug.Log("Middle mouse button being clicked");//tester
        }*/

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, - (scroll * zoomSpeed), 0, Space.World);//zoom in and out
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y), transform.position.z);//limits the zoom

    }
}
