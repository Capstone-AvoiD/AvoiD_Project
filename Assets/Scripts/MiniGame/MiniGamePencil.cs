using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePencil : MonoBehaviour
{
    private MiniGameRadar playerRadar;

    private Vector2 pencilDir;
    private float pencilSpeed = 20.0f;

    private void Awake()
    {
        
        playerRadar = GameObject.FindWithTag("Radar").gameObject.GetComponent<MiniGameRadar>();
        pencilDir = Random.insideUnitCircle;
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
