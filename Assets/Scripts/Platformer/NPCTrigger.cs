using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string ChatText = "";
    private GameObject Main;
    private GameObject TextTrigger;
    int typing;

    void Start()
    {
        Main = GameObject.Find("Main");
        TextTrigger = GameObject.Find("TextTrigger");
        TextTrigger.SetActive(false);   //상호작용 텍스트 비확성
        typing = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)  //player와 npc가 충돌 중일 경우
    {
        if(collision.gameObject.name == "player")
        {
            TextTrigger.SetActive(true);            

            if (Input.GetKey(KeyCode.G)) //G키 눌러 상호작용
            {
                //if (typing == 0)
                {
                    Main.GetComponent<MainScript>().NPCChatEnter(ChatText);
                    typing = 1;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //player와 npc 충돌이 끝날 경우
    {
        if(collision.gameObject.name == "player")
        {
            Main.GetComponent<MainScript>().NPCChatExit();
            TextTrigger.SetActive(false);
            typing = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(typing);   
    }
}
