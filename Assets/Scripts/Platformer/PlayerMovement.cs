using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 10.0f;
    public GameObject player;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance_per_frame = speed * Time.deltaTime;
        float horizontal_input = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontal_input * distance_per_frame); //��,�� ����Ű�� �̵�

        //���� ��ȯ
        if(Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        
        //�ȱ� �ִϸ��̼�
        if (rigid.velocity.normalized.x == 0)
            anim.SetBool("isWalkingRight", false);
        else
            anim.SetBool("isWalkingRight", true);
    }
}
