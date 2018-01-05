using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextBehavior : MonoBehaviour {

    private int score = 0;

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

    private void updateText()
    {
        string text = "Score: " + score + "\n" + "Lifes: 3\nLevel: 1";
        Text textField = GetComponent<Text>();
        textField.text = text;
    }
}
