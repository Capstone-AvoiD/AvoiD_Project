using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class MainScript : MonoBehaviour //Panel Ȱ��, ��Ȱ��
{
    private GameObject NPCDialog;
    private TextMeshProUGUI NPCText ;
    string m_text = "�ȳ� �ݰ���! ���� �� �Ծ���?";
    StringBuilder strb = new StringBuilder();

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
        StartCoroutine(TypingText());   //�ؽ�Ʈ Ÿ���� ȿ�� �ڷ�ƾ ����
    }
    
    public void NPCChatExit()   //Panel ��Ȱ��
    {
        
        StopAllCoroutines();    //�ڷ�ƾ ����
        StopCoroutine(TypingText());
        NPCText.text = "";
        NPCDialog.SetActive(false);
        
    }    

    IEnumerator TypingText()    //�ؽ�Ʈ Ÿ���� ȿ�� �ڷ�ƾ
    {
        yield return new WaitForSeconds(0.5f);  //Ÿ���� ���� ���
        for (int i = 0; i <= m_text.Length; i++)
        {
            NPCText.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.15f); //Ÿ���� ����
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
