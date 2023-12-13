using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPlayerMove : MonoBehaviour
{
    [Header("GameObj")]
    [SerializeField] private GameObject player;

    [Header("WayPoint")]
    [SerializeField] private Transform[] bezierGToP;

    private float moveSpeed = 0.3f;
    private float rotSpeed = 10.0f;
    private Vector3 bezierPos;
    private Vector3 prePos;
    private Vector3 gizmosPos;

    private void Awake()
    {
        prePos = player.transform.position;
        StartCoroutine(BezierMove(bezierGToP));
    }

    private IEnumerator BezierMove(Transform[] transformList)
    {
        yield return new WaitForSeconds(1.0f);
        
        for(int i = 0; i < transformList.Length / 4; i++)
        {
            for(float t = 0.0f; t < 1.0f; t+= Time.deltaTime * moveSpeed * (i + 1))
            {
                bezierPos = Mathf.Pow(1 - t, 3) * transformList[i * 4 + 0].position
                            + 3 * t * Mathf.Pow(1 - t, 2) * transformList[i * 4 + 1].position
                            + 3 * t * (1 - t) * transformList[i * 4 + 2].position
                            + Mathf.Pow(t, 3) * transformList[i * 4 + 3].position;

                player.transform.position = bezierPos;

                float angle = prePos.z - transform.position.z;
                prePos = player.transform.position;

                transform.rotation = Quaternion.Euler(0.0f ,0.0f, 180.0f - angle);

                yield return new WaitForEndOfFrame();
            }
        }

        bool isRot = true;
        while(isRot)
        {
            var rotValue = player.transform.rotation;
            transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.identity, Time.deltaTime * rotSpeed);

            if(rotValue == transform.rotation) isRot = false;

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnDrawGizmos() 
    {
        Transform[] gizmosList = bezierGToP;

        for(int i = 0; i < bezierGToP.Length / 4; i++)
        {
            for(float t = 0.0f; t < 1.0f; t += 0.05f)
            {
                gizmosPos = Mathf.Pow(1 - t, 3) * gizmosList[i * 4 + 0].position
                            + 3 * t * Mathf.Pow(1 - t, 2) * gizmosList[i * 4 + 1].position
                            + 3 * t * (1 - t) * gizmosList[i * 4 + 2].position
                            + Mathf.Pow(t, 3) * gizmosList[i * 4 + 3].position;

                Gizmos.DrawSphere(gizmosPos, 0.1f);
                Gizmos.DrawLine(gizmosList[i * 4 + 0].position, gizmosList[i * 4 + 1].position);
                Gizmos.DrawLine(gizmosList[i * 4 + 2].position, gizmosList[i * 4 + 3].position);
            }
        }
    }
}
