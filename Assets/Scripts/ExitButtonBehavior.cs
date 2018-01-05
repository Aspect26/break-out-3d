using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitButtonBehavior : MonoBehaviour {

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        this.GetComponentInChildren<Text>().text = "Exit";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        Application.Quit();
    }

}
