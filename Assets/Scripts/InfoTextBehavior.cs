﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextBehavior : MonoBehaviour {

    private int score = 0;
    private int level = 1;
    private int lifes = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int value)
    {
        this.score += value;
        this.updateText();
    }

    public void IncreaseLevel()
    {
        this.level++;
        this.updateText();
    }

    public void ResetStats()
    {
        this.score = 0;
        this.level = 1;
        this.lifes = 3;
        this.updateText();
    }

    public void SetLifes(int lifes)
    {
        this.lifes = lifes;
        this.updateText();
    }

    private void updateText()
    {
        string text = "Score: " + score + "\n" + "Lifes: " + lifes + "\nLevel: " + level;
        Text textField = GetComponent<Text>();
        textField.text = text;
    }
}
