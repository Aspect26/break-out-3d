using UnityEngine;

public class PaddleBehavior : MonoBehaviour {

    private const float CUBE_WIDTH = 0.744f * 2f + 0.125f;
    private const float CUBE_HEIGHT = 1.0f - 0.0625f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.mousePosition.x;
        float newZ = mouseX / (Screen.width / CUBE_WIDTH) - (CUBE_WIDTH / 2);

        float mouseY = Input.mousePosition.y;
        float newY = mouseY / (Screen.height / CUBE_HEIGHT);

        this.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, newY, newZ), this.transform.rotation);
	}
}
