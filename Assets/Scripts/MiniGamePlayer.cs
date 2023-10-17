using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{

    private float player_speed = 3.0f;
    private Vector2 player_direction;
    private Rigidbody2D player_rigid;

    private void Awake()
    {
        player_rigid = gameObject.GetComponent<Rigidbody2D>();
        player_direction = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Input_Direction();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private Vector2 Input_Direction()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        player_direction = new Vector2(h, v);

        return player_direction;
    }

    private void Move()
    {
        player_rigid.MovePosition(player_rigid.position + player_direction * player_speed * Time.deltaTime);
        // transform.Translate(player_direction * Time.deltaTime * player_speed);
    }

    private void OnCollisionStay2D(Collision2D other) 
    {

    }
}
