using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Vector2 center;
    public Vector2 size;

    float height;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos() //카메라 제한범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center,size);   
    }
    void LateUpdate()
    {
        //transform.position = new Vector3(target.position.x, target.position.y + 3, -10f);   //�÷��̾� ��ġ ����
        //transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);   //Z�� ����

        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed); //부드럽게 추적

        //카메라 위치
        float Ix = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -Ix + center.x, Ix + center.x);

        float Iy = size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y, -Iy + center.y, Ix + center.y);

        transform.position = new Vector3(clampX, clampY, -10.0f);
    }
}

