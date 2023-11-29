using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{

    private float player_speed = 3.0f;                          // 플레이어 속성 생성
    private Vector2 player_direction;
    private Rigidbody2D player_rigid;
<<<<<<< HEAD

    Animator anim;//*****************************
=======
    private BoxCollider2D playerCollider;
    private float attackTime = 1.5f;
    private float penaltyAlpha = 0.0f;
    private GameObject penaltyObj;

    private int hp = 3;
    private int Hp
    {
        get{ return hp; }
        set
        {
            hp = value;
            penaltyAlpha += 85.0f;

            if(hp == 0) isFailure = true;
            else StartCoroutine(ActivePenaltyObj());
        }
    }
>>>>>>> feature/공격시스템_수정

    private Vector2 prePos;

    [HideInInspector]
    public bool isFailure = false;

    private SpriteRenderer playerSprite;

    [Tooltip("Right, Back, Left, Front Sprites")]
    [SerializeField]
    private List<Sprite> spriteList = new();

    private void Awake()
    {
        player_rigid = gameObject.GetComponent<Rigidbody2D>(); 
        player_direction = transform.position;
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
<<<<<<< HEAD
        
        anim = GetComponent<Animator>();
=======
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        penaltyObj = gameObject.transform.GetChild(0).gameObject;
>>>>>>> feature/공격시스템_수정

        prePos = transform.localPosition;
    }

    void Update()                                               // 방향 입력은 프레임으로 받도록 유도
    {
        Input_Direction();
        Debug.Log(player_rigid.velocity.x);



    }

    private void FixedUpdate()                                  // 물리적인 움직임은 고정적인 프레임으로 이동하도록 유도
    {
        MovePlayer();
        ChangeSprite();
    }

    private Vector2 Input_Direction()                           // Axis에 따라 상하좌우를 이동할 수 있도록 방향을 결정 받음
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        player_direction = new Vector2(h, v);

        return player_direction;
    }

    private void MovePlayer()                                         // MovePosition으로 오브젝트를 고정적으로 이동하게 설정
    {
        player_rigid.MovePosition(player_rigid.position + player_direction * player_speed * Time.deltaTime);
    }

    private void ChangeSprite()
    {

        if(prePos.x > transform.localPosition.x) playerSprite.sprite = spriteList[2];
        else if(prePos.x < transform.localPosition.x) playerSprite.sprite = spriteList[0];

        if(prePos.y > transform.localPosition.y) playerSprite.sprite = spriteList[3];
        else if(prePos.y < transform.localPosition.y) playerSprite.sprite = spriteList[1];

        prePos = transform.localPosition;
    }

    private IEnumerator ActivePenaltyObj()
    {
        penaltyObj.GetComponent<SpriteRenderer>().color = new(1.0f, 1.0f, 1.0f, penaltyAlpha / 255.0f);

        playerCollider.isTrigger = true;
        penaltyObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        penaltyObj.SetActive(false);
        playerCollider.isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Monster"))
        {
<<<<<<< HEAD
            isFailure = true;                   // GameManager에서 게임 상태 관리하도록 동작
=======
            GameObject.Find("HP_" + Hp).gameObject.SetActive(false);
            Hp -= 1;
>>>>>>> feature/공격시스템_수정
        }
    }

    private void MiniGame_Animator()    //*****************************
    {
        

        //if (Mathf.Abs(player_rigid.velocity.x) < 0.5)
        //anim.SetBool("isWalking_Horizontal", false);
        //else
        //anim.SetBool("isWalking_Horizontal", true);

        //anim.SetBool("isWalking_Horizontal", false);
        //anim.SetBool("isWalking_Up", false);
        //anim.SetBool("isWalking_Down", false);
    }
}
