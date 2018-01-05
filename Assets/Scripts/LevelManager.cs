using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private int currentLevel;
    private string[] levelObjectNames;

    private void Start()
    {
        this.initializeLevels();
        this.setLevel(1);
    }

    private void initializeLevels()
    {
        this.levelObjectNames = new string[3];
        this.levelObjectNames[0] = "Level1Blocks";
        this.levelObjectNames[1] = "Level2Blocks";
        this.levelObjectNames[2] = "Level3Blocks";
    }

    private void setLevel(int level)
    {
        this.currentLevel = level;
        this.spawnLevelBlocks();
    }

    private void spawnLevelBlocks()
    {
        GameObject levelBlocks = Instantiate(Resources.Load(this.levelObjectNames[this.currentLevel - 1])) as GameObject;
        levelBlocks.transform.SetPositionAndRotation(new Vector3(0, 0, 0), levelBlocks.transform.rotation);
        Instantiate(Resources.Load("Ball"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
