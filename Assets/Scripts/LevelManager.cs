using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private const int MAX_LEVEL = 3;
    private int currentLevel;
    private int lifes;
    private string[] levelObjectNames;
    private GameObject currentLevelBlocks;

    private void Start()
    {
        SceneManager.UnloadSceneAsync("Menu");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
        this.initializeLevels();
        this.ResetGame();
    }

    public void ResetGame()
    {
        this.setLevel(0);
        this.lifes = 3;
        GameObject.Find("Info Text").GetComponent<InfoTextBehavior>().ResetStats();
    }

    private void initializeLevels()
    {
        this.levelObjectNames = new string[MAX_LEVEL];
        this.levelObjectNames[0] = "Level1Blocks";
        this.levelObjectNames[1] = "Level2Blocks";
        this.levelObjectNames[2] = "Level3Blocks";
    }

    private void setLevel(int level)
    {
        this.currentLevel = level % MAX_LEVEL;
        this.destroyAllBalls();
        this.spawnLevelBlocks();
    }

    private void destroyAllBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }

    private void spawnLevelBlocks()
    {
        currentLevelBlocks = Instantiate(Resources.Load(this.levelObjectNames[this.currentLevel])) as GameObject;
        currentLevelBlocks.transform.SetPositionAndRotation(new Vector3(0, 0, 0), currentLevelBlocks.transform.rotation);
        Instantiate(Resources.Load("Ball"));
    }

    public void OnBlockDestroyed(BlockBehavior block)
    {
        GameObject.Find("Info Text").GetComponent<InfoTextBehavior>().AddScore(block.value);
        if (currentLevelBlocks.transform.Find("Blocks").transform.childCount == 1)
        {
            this.startNextLevel();
        }
    }

    public void OnBallLost()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        if (balls.Length == 1)
        {
            this.lifes--;
            GameObject.Find("Info Text").GetComponent<InfoTextBehavior>().SetLifes(this.lifes);
            if (this.lifes == 0)
            {
                SceneManager.UnloadSceneAsync("Main");
                SceneManager.LoadScene("Menu");
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
            }
            else
            {
                Instantiate(Resources.Load("Ball"));
            }
        }
    }

    public void startNextLevel()
    {
        Destroy(this.currentLevelBlocks);
        this.setLevel(this.currentLevel + 1);
        GameObject.Find("Info Text").GetComponent<InfoTextBehavior>().IncreaseLevel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
