using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryTimer : MonoBehaviour
{
    static float storyTimer;
    public Text visibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Contains("Level 1"))
            storyTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        storyTimer += Time.deltaTime;
        visibleTimer.text = storyTimer.ToString("f2");
    }
}
