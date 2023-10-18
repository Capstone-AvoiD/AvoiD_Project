using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string ChatText = "";
    private GameObject Main;
    private GameObject TextTrigger;

    void Start()
    {
        Main = GameObject.Find("Main");

        TextTrigger = GameObject.Find("TextTrigger");
        TextTrigger.SetActive(false);   //��ȣ�ۿ� �ؽ�Ʈ ��Ȯ��
    }

    private void OnTriggerStay2D(Collider2D collision)  //player�� npc�� �浹 ���� ���
    {
        if(collision.gameObject.name == "player")
        {
            TextTrigger.SetActive(true);            

            if (Input.GetKey(KeyCode.G)) //GŰ ���� ��ȣ�ۿ�
            {
                Main.GetComponent<MainScript>().NPCChatEnter(ChatText);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //player�� npc �浹�� ���� ���
    {
        if(collision.gameObject.name == "player")
        {
            Main.GetComponent<MainScript>().NPCChatExit();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
