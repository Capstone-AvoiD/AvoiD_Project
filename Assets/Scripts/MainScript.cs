using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScript : MonoBehaviour //Panel Ȱ��, ��Ȱ��
{
    private GameObject NPCDialog;
    private TextMeshProUGUI NPCText ;

    // Start is called before the first frame update
    void Start()
    {
        NPCDialog = GameObject.Find("NPCDialog");
        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel ��Ȱ��
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
