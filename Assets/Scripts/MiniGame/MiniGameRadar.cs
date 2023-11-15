using System.Collections.Generic;
using UnityEngine;

public class MiniGameRadar : MonoBehaviour
{
    private GameObject player;

    private List<GameObject> monsterList = new();

    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    public Vector2 SetMonsterDir()
    {

        Vector2 monsterDir = Vector2.right;
        bool check = false;

        if(monsterList.Count != 0) check = NullCheck();
        else return monsterDir;

        if(check) monsterList.RemoveAll(obj => obj == null);

        float distance = 99.0f;

        distance = Vector2.Distance(player.transform.position, monsterList[0].transform.position);
        
        foreach(GameObject mObj in monsterList)
        {
            float closedDis = Vector2.Distance(player.transform.position, mObj.transform.position);

            if(closedDis < distance)
            {
                distance = closedDis;
                monsterDir = player.transform.position - mObj.transform.position;
            }
        }

        return monsterDir;
    }

    private bool NullCheck()
    {
        foreach(GameObject mObj in monsterList)
        {
            if(mObj == null) return true;
            
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        switch(collider2D.gameObject.tag)
        {
            case "Monster":
                Debug.Log("Radar : Monster target");
                monsterList.Add(collider2D.gameObject);
                break;
            default:
                break;
        }
    }
}
