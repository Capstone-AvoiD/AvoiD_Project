using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniGameMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Transform player_transform;
    private float monster_speed = 2.0f;
    private Rigidbody2D monster_rigid;

    [SerializeField]
    private NavMeshAgent agent;

    private void Awake()
    {
        player_transform = player.GetComponent<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        monster_rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void Move()
    {
        agent.speed = monster_speed * Time.deltaTime;
        agent.destination = player_transform.transform.position;
    }
}
