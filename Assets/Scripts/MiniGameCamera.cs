using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [Tooltip("xMax, xMin, yMax, yMin")]
    private List<float> cameraPosList = new() {83.2f, -82.2f, 91.1f, -90.0f};

    // Update is called once per frame
    private void Update()
    {
        SetCameraPos();
    }
    
    private void SetCameraPos()
    {
        float xPos = player.transform.position.x;
        float yPos = player.transform.position.y;
        
        float clampXPos = Mathf.Clamp(xPos, cameraPosList[1], cameraPosList[0]);
        float clampYPos = Mathf.Clamp(yPos, cameraPosList[3], cameraPosList[2]);



        transform.position = new(clampXPos, clampYPos, transform.position.z);
    }
}
