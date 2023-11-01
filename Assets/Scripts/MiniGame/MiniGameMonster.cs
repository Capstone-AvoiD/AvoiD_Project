using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class MiniGameMonster : MonoBehaviour
{
    private GameObject player;                      // 플레이어 오브젝트 설정
    private Rigidbody2D monster_rigid;              // 몬스터가 갖게 될 속성 생성

    private float monster_speed = 1.8f;

    private SpriteRenderer monster_sprite;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        monster_rigid = gameObject.GetComponent<Rigidbody2D>();
        monster_sprite = gameObject.GetComponent<SpriteRenderer>();

        InvokeRepeating("FlipImage", 0.0f, 0.2f);                       // 반복적인 이미지 반전을 막기 위해 딜레이 조절
    }

    private void FixedUpdate()                                          // 물리적인 이동은 고정된 프레임에서 동작
    {
        Move();
    }

    private void Move()                                             // 플레이어 방향을 구하고 정규화하여 플레이어 추적
    {
        Vector2 player_pos = player.transform.position - transform.position;

        monster_rigid.MovePosition(monster_rigid.position + player_pos.normalized * monster_speed * Time.deltaTime);
    }

    private void FlipImage()                                        // 플레이어와 몬스터 위치 기준으로 반전되게 설정
    {
        if(gameObject.transform.position.x < player.transform.position.x) monster_sprite.flipX = false;
        else if(gameObject.transform.position.x > player.transform.position.x) monster_sprite.flipX = true;
    }
}
