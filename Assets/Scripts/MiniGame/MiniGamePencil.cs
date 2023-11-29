using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePencil : MonoBehaviour
{
    private Vector2 pencilDir;
    private float pencilSpeed = 10.0f;

    private GameObject monsterObj;

    private void Awake()
    {
        monsterObj = GameObject.Find("Monster(Clone)");

        if(monsterObj != null)
        {
            pencilDir = (monsterObj.transform.position - transform.position).normalized;
        }
        else pencilDir = Random.insideUnitCircle;
        Destroy(gameObject, 5.0f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(pencilDir * pencilSpeed * Time.deltaTime);
    }
}
