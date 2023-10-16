using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 10.0f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance_per_frame = speed * Time.deltaTime;
        float horizontal_input = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontal_input * distance_per_frame); //좌,우 방향키로 이동
    }
}
