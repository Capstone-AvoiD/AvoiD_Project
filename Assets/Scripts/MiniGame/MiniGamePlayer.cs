using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{

    [Tooltip("Right, Back, Left, Front Sprites")]
    [SerializeField] private List<Sprite> spriteList = new();
    [SerializeField] private GameObject pencilPrefab;

    private float player_speed = 3.0f;                          // 플레이어 속성 생성
    private Vector2 player_direction;
    private Rigidbody2D player_rigid;
    private float attackTime = 1.5f;

    private Vector2 prePos;

    [HideInInspector]
    public bool isFailure = false;

    private SpriteRenderer playerSprite;

    private void Awake()
    {
        player_rigid = gameObject.GetComponent<Rigidbody2D>();
        player_direction = transform.position;
        playerSprite = gameObject.GetComponent<SpriteRenderer>();

        prePos = transform.localPosition;

        StartCoroutine(Attack());
    }

    void Update()                                               // 방향 입력은 프레임으로 받도록 유도
    {
        Input_Direction();
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

    private IEnumerator Attack()
    {
        while(true)
        {
            Instantiate(pencilPrefab, transform.localPosition, new Quaternion());

            yield return new WaitForSeconds(attackTime);
        }
    }

    private void ChangeSprite()
    {

        if(prePos.x > transform.localPosition.x) playerSprite.sprite = spriteList[2];
        else if(prePos.x < transform.localPosition.x) playerSprite.sprite = spriteList[0];

        if(prePos.y > transform.localPosition.y) playerSprite.sprite = spriteList[3];
        else if(prePos.y < transform.localPosition.y) playerSprite.sprite = spriteList[1];

        prePos = transform.localPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Monster"))
        {
            isFailure = true;            
        }
    }
}
