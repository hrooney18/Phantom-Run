using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingLevelManager : MonoBehaviour
{

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    public void GoToStartingHub()
    {
        SceneManager.LoadScene("Starting Hub");
    }
}
