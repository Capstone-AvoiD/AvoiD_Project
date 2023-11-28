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
        TextTrigger.SetActive(false);   //��ȣ�ۿ� �ؽ�Ʈ ��Ȯ��
        typing = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)  //player�� npc�� �浹 ���� ���
    {
        if(collision.gameObject.name == "player")
        {
            TextTrigger.SetActive(true);            

            if (Input.GetKey(KeyCode.G)) //GŰ ���� ��ȣ�ۿ�
            {
                //if (typing == 0)
                {
                    Main.GetComponent<MainScript>().NPCChatEnter(ChatText);
                    typing = 1;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //player�� npc �浹�� ���� ���
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
