using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagScript : MonoBehaviour
{
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SetBestTimes();

            LevelManager manager = FindObjectOfType<LevelManager>();
            manager.FinishLevel();
        }
    }

    void SetBestTimes()
    {
        if (scene.name.Contains("Tutorial"))
            if (LevelManager.tutorialBest == 0 || LevelManager.timer < LevelManager.tutorialBest)
                LevelManager.tutorialBest = LevelManager.timer;

        if (scene.name.Contains("Practice"))
            switch (scene.name)
            {
                case "Level 1 Practice":
                    if (LevelManager.level1Best == 0 || LevelManager.timer < LevelManager.level1Best)
                        LevelManager.level1Best = LevelManager.timer;
                    break;
                case "Level 2 Practice":
                    if (LevelManager.level2Best == 0 || LevelManager.timer < LevelManager.level2Best)
                        LevelManager.level2Best = LevelManager.timer;
                    break;
                case "Level 3 Practice":
                    if (LevelManager.level3Best == 0 || LevelManager.timer < LevelManager.level3Best)
                        LevelManager.level3Best = LevelManager.timer;
                    break;
                case "Level 4 Practice":
                    if (LevelManager.level4Best == 0 || LevelManager.timer < LevelManager.level4Best)
                        LevelManager.level4Best = LevelManager.timer;
                    break;
                case "Level 5 Practice":
                    if (LevelManager.level5Best == 0 || LevelManager.timer < LevelManager.level5Best)
                        LevelManager.level5Best = LevelManager.timer;
                    break;
                case "Level 6 Practice":
                    if (LevelManager.level6Best == 0 || LevelManager.timer < LevelManager.level6Best)
                        LevelManager.level6Best = LevelManager.timer;
                    break;
                case "Level 7 Practice":
                    if (LevelManager.level7Best == 0 || LevelManager.timer < LevelManager.level7Best)
                        LevelManager.level7Best = LevelManager.timer;
                    break;
            }
        if (scene.name.Contains("Story"))
            switch (scene.name)
            {
                case "Story Level 1":
                    if (LevelManager.level1BestSplit == 0 || LevelManager.timer < LevelManager.level1BestSplit)
                        LevelManager.level1BestSplit = LevelManager.timer;
                    break;
                case "Story Level 2":
                    if (LevelManager.level2BestSplit == 0 || LevelManager.timer < LevelManager.level2BestSplit)
                        LevelManager.level2BestSplit = LevelManager.timer;
                    break;
                case "Story Level 3":
                    if (LevelManager.level3BestSplit == 0 || LevelManager.timer < LevelManager.level3BestSplit)
                        LevelManager.level3BestSplit = LevelManager.timer;
                    break;
                case "Story Level 4":
                    if (LevelManager.level4BestSplit == 0 || LevelManager.timer < LevelManager.level4BestSplit)
                        LevelManager.level4BestSplit = LevelManager.timer;
                    break;
                case "Story Level 5":
                    if (LevelManager.level5BestSplit == 0 || LevelManager.timer < LevelManager.level5BestSplit)
                        LevelManager.level5BestSplit = LevelManager.timer;
                    break;
                case "Story Level 6":
                    if (LevelManager.level6BestSplit == 0 || LevelManager.timer < LevelManager.level6BestSplit)
                        LevelManager.level6BestSplit = LevelManager.timer;
                    break;
                case "Story Level 7":
                    if (LevelManager.storyBest == 0 || LevelManager.timer < LevelManager.storyBest)
                        LevelManager.storyBest = LevelManager.timer;
                    break;
            }
    }
}