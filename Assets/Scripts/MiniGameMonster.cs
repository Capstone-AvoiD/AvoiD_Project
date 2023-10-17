using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class MiniGameMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Rigidbody2D monster_rigid;

    private float monster_speed = 1.5f;

    private SpriteRenderer monster_sprite;

    private void Awake()
    {
        monster_rigid = gameObject.GetComponent<Rigidbody2D>();
        monster_sprite = gameObject.GetComponent<SpriteRenderer>();

        InvokeRepeating("FlipImage", 0.0f, 0.2f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 player_pos = player.transform.position - transform.position;

        monster_rigid.MovePosition(monster_rigid.position + player_pos.normalized * monster_speed * Time.deltaTime);
    }

    private void FlipImage()
    {
        if(gameObject.transform.position.x < player.transform.position.x) monster_sprite.flipX = false;
        else if(gameObject.transform.position.x > player.transform.position.x) monster_sprite.flipX = true;
    }
}
