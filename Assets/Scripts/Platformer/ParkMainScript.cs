using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ParkMainScript : MonoBehaviour //Panel Ȱ��, ��Ȱ��
{
    private GameObject NPCDialog;
    private GameObject NextDialog;
    private GameObject SkipDialog;
    private TextMeshProUGUI NPCText;
    private TextMeshProUGUI NPCName;

    string[] m_text;    //���
    private int currentIndex;   //���� ��ȭ���� ��ȣ

    private string[] playerName =  
        new string[] { "����", "����", "����", " " };
    private int setPlayerImage;  // ����: 0, ����: 1, ����: 2 �����̼�: 3
    private int[] currentPlayer;    //���� ���ϴ� ĳ����
    private GameObject NPC_Dohun;//ĳ���� �̹���
    private GameObject NPC_Seongtae;
    private GameObject NPC_Sohyun;

    StringBuilder strb = new StringBuilder();

    // Start is called before the first frame update

    void Start()
    {
        DialogImage();

        NPCDialog = GameObject.Find("NPCDialog");
        NextDialog = GameObject.Find("NextText");
        SkipDialog = GameObject.Find("SkipText");

        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCName = GameObject.Find("NPCName").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel ��Ȱ��
        NextDialog.SetActive(false); //Panel ��Ȱ��
        SkipDialog.SetActive(false); //Panel ��Ȱ��

        currentIndex = 0;
    }

    public void NPCChatEnter(string text)   //Panel Ȱ��
    {
        NPCText.text = text;
        Dialog(0);  //ó�� ��� ���
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
        currentIndex = 0;   //��� ��ȣ �ʱ�ȭ
    }

    IEnumerator TypingText()    //�ؽ�Ʈ Ÿ���� ȿ�� �ڷ�ƾ
    {
        while (currentIndex < m_text.Length)    //��� ���� �ؽ�Ʈ ���
        {
            //currentIndex = ���� ��� ��ȣ, Dialog = ��簡 ����ִ� �Լ�
            string sentence = Dialog(currentIndex); //������ �´� ��� ���

            NextDialog.SetActive(false);    //��� ��� �� ��Ÿ������
            SkipDialog.SetActive(false);

            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.01f); //Ÿ���� ����
            }

            NextDialog.SetActive(true);
            SkipDialog.SetActive(true);

            //GŰ ���� ������ ���
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.G));  

            currentIndex++; //���� ��簡 ��� �ǵ���

            if (currentIndex >= m_text.Length)  //������ ��� ��� ��½� ����
            {
                break;
            }
        }
        NPCChatExit();  //Dialog ����
    }

    public void DialogImage()   //ĳ���� �̹��� �ʱ⼳��
    {
        setPlayerImage = 0;

        NPC_Dohun = GameObject.Find("NPCImage_Dohun");
        NPC_Seongtae = GameObject.Find("NPCImage_Seongtae");
        NPC_Sohyun = GameObject.Find("NPCImage_Sohyun");

        NPC_Dohun.SetActive(false);
        NPC_Seongtae.SetActive(false);  
        NPC_Sohyun.SetActive(false);

    }

    public string Dialog(int Index) //��� ���
    {
        currentIndex = Index;
        m_text = new string[]
            {   //����: 0, ����: 1, ����: 2, �����̼�: 3      {���ϴ»��}
                "�л����� ���� �б� ������ ���� ���ư� ����", //3
                "�����..�����..���°� �ǳ��� ������� �ڲ� �Ӹ��ӿ� �ɵ���.. ������ �ٽ� �б��� ���ư��� �� �� ����.", //0
                "�Ҿ��� �� �ڲ� �б� ������ �ü��� �ٶ󺸴� ����. ������ �ڲٸ� �����鼭 �Ҿ��� �� �¸��� ����.",  //3
                "���� ����� ���ư��ٰ�? ���ƾ� ���� ����! �� �� �ֵ�ó�� ���°� �̻��� ���� ���� ���̾�?", //2
                "���°� �ǳ��� ������� �ڲٸ� ������ �Ӹ����� �������� �װ� �ȸ��ø� �Ҿ��� ��ĥ �� ����.",  //0
                "�Ʊ� ��忡�� �ֵ��� ���� �޶�� ��ġ����.. �ҹ���� �б����� ������ ������ ���� �ǰ� ��", //2
                "�׷��� ���� ���°� ó������ ������ ������ ���߾�.. �� ������� ������ �� �־��� ��.",  //0
                "���� ����, �� ���� �ߵ� �ʱ� �����̾� ����ؼ� �����ߴٰ� �� �ֵ�ó�� �������� �ž� ������ ġ�Ḧ ���ؼ��� ���� �������� ����!",   //2
                "[�޷����� �Ҹ�]",    //3
                "�л��� -�� ���� �и� ����! ����! �ܾ� ����� �������� �־�! �־�!", //3
                "�л��� -�� �ʿ��� �� �ʿ��� �� �ʿ���! �츮�� ��?����! �� ����!"   //3
            };
        currentPlayer = new int[]   //�� ��� ������ �´� �÷��̾� 
        {
            3, 0, 3, 2, 0,
            2, 0, 2, 3, 3,
            3
        };
        setPlayerImage = currentPlayer[currentIndex];   

        switch (setPlayerImage)   //���ϴ� ĳ������ �̹���
        {
            case 0:
                NPCName.text = playerName[0];
                NPC_Dohun.SetActive(true);
                NPC_Seongtae.SetActive(false);
                NPC_Sohyun.SetActive(false);
                break;
            case 1:
                NPCName.text = playerName[1];
                NPC_Dohun.SetActive(false);
                NPC_Seongtae.SetActive(true);
                NPC_Sohyun.SetActive(false);
                break;
            case 2:
                NPCName.text = playerName[2];
                NPC_Dohun.SetActive(false);
                NPC_Seongtae.SetActive(false);
                NPC_Sohyun.SetActive(true);
                break;
            case 3:
                NPCName.text = playerName[3];
                NPC_Dohun.SetActive(false);
                NPC_Seongtae.SetActive(false);
                NPC_Sohyun.SetActive(false);
                break;
        }
        return m_text[currentIndex];
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))    //PŰ ���� ��ŵ
            NPCChatExit();
    }
}