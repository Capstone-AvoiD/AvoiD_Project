using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string ChatText = "";
    private GameObject Main;
    void Start()
    {
        Main = GameObject.Find("Main");
    }

    private void OnTriggerStay2D(Collider2D collision)  //player와 npc가 충돌 중일 경우
    {
        if(collision.gameObject.name == "player")
        {
            if(Input.GetKey(KeyCode.G)) //G키 눌러 상호작용
            {
                Main.GetComponent<MainScript>().NPCChatEnter(ChatText);
                //Debug.Log("충돌중!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //player와 npc 충돌이 끝날 경우
    {
        if(collision.gameObject.name == "player")
        {
            Main.GetComponent<MainScript>().NPCChatExit();
            //Debug.Log("충돌끝");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
