using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{

    private float player_speed = 3.0f;                          // 플레이어 속성 생성
    private Vector2 player_direction;
    private Rigidbody2D player_rigid;

    private void Awake()
    {
        player_rigid = gameObject.GetComponent<Rigidbody2D>();
        player_direction = transform.position;
    }


    // Update is called once per frame
    void Update()                                               // 방향 입력은 프레임으로 받도록 유도
    {
        Input_Direction();
    }

    private void FixedUpdate()                                  // 물리적인 움직임은 고정적인 프레임으로 이동하도록 유도
    {
        Move();
    }

    private Vector2 Input_Direction()                           // Axis에 따라 상하좌우를 이동할 수 있도록 방향을 결정 받음
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        player_direction = new Vector2(h, v);

        return player_direction;
    }

    private void Move()                                         // MovePosition으로 오브젝트를 고정적으로 이동하게 설정
    {
        player_rigid.MovePosition(player_rigid.position + player_direction * player_speed * Time.deltaTime);
        // transform.Translate(player_direction * Time.deltaTime * player_speed);
    }
}
