using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private const int MAX_LEVEL = 3;
    private int currentLevel;
    private string[] levelObjectNames;
    private GameObject currentLevelBlocks;

    private void Start()
    {
        this.initializeLevels();
        this.setLevel(0);
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
        this.spawnLevelBlocks();
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

    public void startNextLevel()
    {
        Destroy(this.currentLevelBlocks);
        this.setLevel(this.currentLevel++);
        GameObject.Find("Info Text").GetComponent<InfoTextBehavior>().IncreaseLevel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
