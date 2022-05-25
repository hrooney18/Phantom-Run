using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextLevel;
    public Text timerText;
    public Text levelCompleteTimeText;
    public Text levelCompleteBestText;
    public static float timer;
    public static bool canMove = true;

    private float timeToUse;

    public static float storyBest = 0;
    public static float tutorialBest = 0;
    public static float level1Best = 0;
    public static float level2Best = 0;
    public static float level3Best = 0;
    public static float level4Best = 0;
    public static float level5Best = 0;
    public static float level6Best = 0;
    public static float level7Best = 0;
    public static float level1BestSplit = 0;
    public static float level2BestSplit = 0;
    public static float level3BestSplit = 0;
    public static float level4BestSplit = 0;
    public static float level5BestSplit = 0;
    public static float level6BestSplit = 0;
    public static float level7BestSplit = 0;

    public GameObject timesMenu;
    public Text tutorialBestText;
    public Text storyBestText;
    public Text level1BestText;
    public Text level2BestText;
    public Text level3BestText;
    public Text level4BestText;
    public Text level5BestText;
    public Text level6BestText;
    public Text level7BestText;

    private GameObject levelCompleteMenu;
    private Scene scene;
    private bool timesMenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        timesMenuOpen = false;
        levelCompleteMenu = GameObject.FindWithTag("LevelCompleteMenu");
        timeToUse = 0;
        canMove = true;
        scene = SceneManager.GetActiveScene();

        if (scene.name.Contains("Practice") || scene.name.Contains("Tutorial") || scene.name == "Story Level 1")
            timer = 0;

        levelCompleteMenu.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("f2");

        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.C))
                FindObjectOfType<PlayerControllerScript>().RespawnPlayer();
            if (Input.GetKeyDown(KeyCode.R))
                RestartLevel();
            if (Input.GetKeyDown(KeyCode.H))
                if (!timesMenuOpen)
                    ExitLevel();
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (timesMenuOpen)
                    timesMenuOpen = false;
                else
                {
                    SetTimesMenuTexts();
                    timesMenuOpen = true;
                }
            }
        }

        timesMenu.SetActive(timesMenuOpen);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Starting Hub");
    }

    public void FinishLevel()
    {
        canMove = false;
        Time.timeScale = 0;
        DetermineTimeToUse();
        SetLevelTimeTexts();
        levelCompleteMenu.SetActive(true);
    }

    void SetLevelTimeTexts()
    {
        if (scene.name.Contains("Tutorial") || scene.name.Contains("Practice"))
        {
            levelCompleteTimeText.text = "Level Time: " + TimeSpan.FromSeconds((double) timer).ToString(@"mm\:ss\.ff");
            levelCompleteBestText.text = "Best Time: " + TimeSpan.FromSeconds((double) timeToUse).ToString(@"mm\:ss\.ff");
        }
        if (scene.name.Contains("Story"))
        {
            levelCompleteTimeText.text = "Level Split: " + TimeSpan.FromSeconds((double) timer).ToString(@"mm\:ss\.ff");
            levelCompleteBestText.text = "Best Split: " + TimeSpan.FromSeconds((double) timeToUse).ToString(@"mm\:ss\.ff");
        }
    }

    void SetTimesMenuTexts()
    {
        tutorialBestText.text = "Tutorial - " + TimeSpan.FromSeconds((double) tutorialBest).ToString(@"mm\:ss\.ff");
        storyBestText.text = "Full Game - " + TimeSpan.FromSeconds((double) storyBest).ToString(@"mm\:ss\.ff");
        level1BestText.text = "Level 1 - " + TimeSpan.FromSeconds((double) level1Best).ToString(@"mm\:ss\.ff");
        level2BestText.text = "Level 2 - " + TimeSpan.FromSeconds((double) level2Best).ToString(@"mm\:ss\.ff");
        level3BestText.text = "Level 3 - " + TimeSpan.FromSeconds((double) level3Best).ToString(@"mm\:ss\.ff");
        level4BestText.text = "Level 4 - " + TimeSpan.FromSeconds((double) level4Best).ToString(@"mm\:ss\.ff");
        level5BestText.text = "Level 5 - " + TimeSpan.FromSeconds((double) level5Best).ToString(@"mm\:ss\.ff");
        level6BestText.text = "Level 6 - " + TimeSpan.FromSeconds((double) level6Best).ToString(@"mm\:ss\.ff");
        level7BestText.text = "Level 7 - " + TimeSpan.FromSeconds((double) level7Best).ToString(@"mm\:ss\.ff");
    }

    void DetermineTimeToUse()
    {
        if (scene.name.Contains("Tutorial"))
            timeToUse = tutorialBest;

        if (scene.name.Contains("Practice"))
            switch (scene.name)
            {
                case "Level 1 Practice":
                    timeToUse = level1Best;
                    break;
                case "Level 2 Practice":
                    timeToUse = level2Best;
                    break;
                case "Level 3 Practice":
                    timeToUse = level3Best;
                    break;
                case "Level 4 Practice":
                    timeToUse = level4Best;
                    break;
                case "Level 5 Practice":
                    timeToUse = level5Best;
                    break;
                case "Level 6 Practice":
                    timeToUse = level6Best;
                    break;
                case "Level 7 Practice":
                    timeToUse = level7Best;
                    break;
            }
        if (scene.name.Contains("Story"))
            switch (scene.name)
            {
                case "Story Level 1":
                    timeToUse = level1BestSplit;
                    break;
                case "Story Level 2":
                    timeToUse = level2BestSplit;
                    break;
                case "Story Level 3":
                    timeToUse = level3BestSplit;
                    break;
                case "Story level 4":
                    timeToUse = level4BestSplit;
                    break;
                case "Story Level 5":
                    timeToUse = level5BestSplit;
                    break;
                case "Story Level 6":
                    timeToUse = level6BestSplit;
                    break;
                case "Story Level 7":
                    timeToUse = level7BestSplit;
                    break;
            }
    }
}
