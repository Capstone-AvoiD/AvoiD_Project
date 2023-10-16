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

    private void OnTriggerStay2D(Collider2D collision)  //player�� npc�� �浹 ���� ���
    {
        if(collision.gameObject.name == "player")
        {
            if(Input.GetKey(KeyCode.G)) //GŰ ���� ��ȣ�ۿ�
            {
                Main.GetComponent<MainScript>().NPCChatEnter(ChatText);
                //Debug.Log("�浹��!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //player�� npc �浹�� ���� ���
    {
        if(collision.gameObject.name == "player")
        {
            Main.GetComponent<MainScript>().NPCChatExit();
            //Debug.Log("�浹��");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
