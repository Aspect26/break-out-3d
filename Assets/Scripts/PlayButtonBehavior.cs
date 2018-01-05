using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonBehavior : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        this.GetComponentInChildren<Text>().text = "Play";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
    }
}
