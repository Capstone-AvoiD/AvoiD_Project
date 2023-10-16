using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour //Panel 활성, 비활성
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

    public void NPCChatEnter(string text)   //Panel 활성
    {
        NPCText.text = text;
        NPCDialog.SetActive(true);
    }

    public void NPCChatExit()   //Panel 비활성
    {
        NPCText.text = "";
        NPCDialog.SetActive(false);
    }    
    // Update is called once per frame
    void Update()
    {
        
    }
}
