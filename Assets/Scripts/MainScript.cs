using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour //Panel Ȱ��, ��Ȱ��
{
    private GameObject NPCDialog;
    private Text NPCText;

    // Start is called before the first frame update
    void Start()
    {
        NPCDialog = GameObject.Find("NPCDialog");
        NPCText = GameObject.Find("NPCText").GetComponent<Text>();
        NPCDialog.SetActive(false);
    }

    public void NPCChatEnter(string text)   //Panel Ȱ��
    {
        NPCText.text = text;
        NPCDialog.SetActive(true);
    }

    public void NPCChatExit()   //Panel ��Ȱ��
    {
        NPCText.text = "";
        NPCDialog.SetActive(false);
    }    
    // Update is called once per frame
    void Update()
    {
        
    }
}
