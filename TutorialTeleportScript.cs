using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTeleportScript : MonoBehaviour
{
    public Transform checkpoint1;
    public Transform checkpoint2;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case "Door 1":
                    collider.transform.position = checkpoint1.position;
                    break;
                case "Door 2":
                    collider.transform.position = checkpoint2.position;
                    break;
            }
        }
    }
}
