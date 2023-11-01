using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameInstantiation : MonoBehaviour
{
    //Set spawn line : x -> abs(19), y -> abs(11)

    [SerializeField]
    private GameObject monsterPrefab;

    private List<GameObject> monsterList = new();

    void Start()
    {
        InvokeRepeating("InstantiateMonster", 0.0f, 0.8f);          // 함수를 0.8초씩 반복 실행하도록 설정
    }

    private void InstantiateMonster()                               // 무작위로 몬스터 생성
    {
        bool randomBool = Random.value > 0.5f;
        Vector3 spawnPoint = randomBool ? RandomHorizontalPos() : RandomVerticalPos();

        GameObject instance = Instantiate(monsterPrefab, spawnPoint, Quaternion.identity);
        
        monsterList.Add(instance);

        Destroy(instance, 20.0f);
    }

    private Vector3 RandomHorizontalPos()                           // 몬스터의 생성 위치 결정 (Horizontal)
    {
        bool randomDir = Random.value > 0.5f;
        float xPos = Random.Range(-19.0f, 19.0f);
        float yPos = randomDir ? 11.0f : -11.0f;
        
        Vector3 randomPos = new(xPos, yPos, -1.0f);

        return randomPos;
    }

    private Vector3 RandomVerticalPos()                             // 몬스터의 생성 위치 결정 (Vertical)
    {
        bool randomDir = Random.value > 0.5f;
        float xPos = randomDir ? 19.0f : -19.0f;
        float yPos = Random.Range(-11.0f, 11.0f);

        Vector3 randomPos = new(xPos, yPos, -1.0f);

        return randomPos;
    }
}
