using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FullGameDoorScript : MonoBehaviour
{
    private bool touchingDoor = false;

    // Update is called once per frame
    void Update()
    {
        if (touchingDoor)
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadSceneAsync("Story Level 1");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            touchingDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            touchingDoor = false;
        }
    }
}
