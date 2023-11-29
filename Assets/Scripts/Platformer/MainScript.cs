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
    public string[] m_text;
    private int currentIndex;
    StringBuilder strb = new StringBuilder();

    // Start is called before the first frame update
        
    void Start()
    {
        NPCDialog = GameObject.Find("NPCDialog");
        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel ��Ȱ��
        currentIndex = 0;
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
        //StopCoroutine(TypingText());
        NPCText.text = "";
        NPCDialog.SetActive(false);
        currentIndex = 0;
    }

    IEnumerator TypingText()    //�ؽ�Ʈ Ÿ���� ȿ�� �ڷ�ƾ
    {
        while (currentIndex < m_text.Length)    //��� ���� �ؽ�Ʈ ���
        {
            string sentence = m_text[currentIndex];

            yield return new WaitForSeconds(0.5f);  //Ÿ���� ���� ���
            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.15f); //Ÿ���� ����
            }
            currentIndex++;
        }
        currentIndex = 0;
    }

    void Update()
    {

    }
}
