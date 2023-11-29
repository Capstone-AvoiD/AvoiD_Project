using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class MainScript : MonoBehaviour //Panel Ȱ��, ��Ȱ��
{
    private GameObject NPCDialog;
    private GameObject NextText;
    private TextMeshProUGUI NPCText;
    private TextMeshProUGUI NPCName;
    public string[] m_text;
    private int currentIndex;

    private string[] playerName = new string[] { "Dohun", "Seongtae", "Sohyun" };
    private int currentPlayer;  // ����: 0, ����: 1, ����: 2
    private GameObject NPC_Dohun;
    private GameObject NPC_Seongtae;
    private GameObject NPC_Sohyun;

    StringBuilder strb = new StringBuilder();

    // Start is called before the first frame update
        
    void Start()
    {
        DialogImage();

        NPCDialog = GameObject.Find("NPCDialog");
        NextText = GameObject.Find("NextText");
        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCName = GameObject.Find("NPCName").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel ��Ȱ��
        NextText.SetActive(false); //Panel ��Ȱ��
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
        NPCDialog.SetActive(false);
        NPCText.text = "";
        NPCName.text = "";
        currentIndex = 0;
        
    }

    IEnumerator TypingText()    //�ؽ�Ʈ Ÿ���� ȿ�� �ڷ�ƾ
    {
        while (currentIndex < m_text.Length)    //��� ���� �ؽ�Ʈ ���
        {
            switch (currentPlayer)   //���ϴ� ĳ���� �̹���
            {
                case 0:
                    NPC_Dohun.SetActive(true);
                    NPC_Seongtae.SetActive(false);
                    NPC_Sohyun.SetActive(false);
                    break;
                case 1:
                    NPC_Dohun.SetActive(false);
                    NPC_Seongtae.SetActive(true);
                    NPC_Sohyun.SetActive(false);
                    break;
                case 2:
                    NPC_Dohun.SetActive(false);
                    NPC_Seongtae.SetActive(false);
                    NPC_Sohyun.SetActive(true);
                    break;
            }

            switch (currentIndex)   //���ϴ� ĳ���� �̹���
            {
                case 0:
                case 3:
                    currentPlayer = 0;  //����
                    break;
                case 1:
                case 5:
                    currentPlayer = 1;  //����
                    break;
                case 2:
                    currentPlayer = 2; // ����
                    break;
            }

            string sentence = m_text[currentIndex];
            NPCName.text = playerName[0];
            NextText.SetActive(false);

            //yield return new WaitForSeconds(0.5f);  //Ÿ���� ���� ���
            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.15f); //Ÿ���� ����
            }
            NextText.SetActive(true);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.G));
            currentIndex++;
        }
        currentIndex = 0;   //��ȭ ����� �ʱ�ȭ
    }

    public void DialogImage()
    {
        currentPlayer = 0;

        NPC_Dohun = GameObject.Find("NPCImage_Dohun");
        NPC_Seongtae = GameObject.Find("NPCImage_Seongtae");
        NPC_Sohyun = GameObject.Find("NPCImage_Sohyun");

        NPC_Dohun.SetActive(false);
        NPC_Seongtae.SetActive(false);
        NPC_Sohyun.SetActive(false);

    }

    void Update()
    {

    }
}
