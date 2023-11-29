using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class MainScript : MonoBehaviour //Panel Ȱ��, ��Ȱ��
{
    private GameObject NPCDialog;
    private GameObject NextDialog;
    private TextMeshProUGUI NPCText;
    private TextMeshProUGUI NPCName;
    private int currentIndex;   //���� ��ȭ���� ��ȣ
    string[] m_text;    //���

    private string[] playerName = new string[] { "����", "����", "����", " " };
    private int setPlayerImage;  // ����: 0, ����: 1, ����: 2 �����̼�: 3
    private int[] currentPlayer;    //���� ���ϴ� ĳ����
    private GameObject NPC_Dohun;
    private GameObject NPC_Seongtae;
    private GameObject NPC_Sohyun;

    StringBuilder strb = new StringBuilder();

    // Start is called before the first frame update
        
    void Start()
    {
        DialogImage();

        NPCDialog = GameObject.Find("NPCDialog");
        NextDialog = GameObject.Find("NextText");
        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCName = GameObject.Find("NPCName").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel ��Ȱ��
        NextDialog.SetActive(false); //Panel ��Ȱ��
        currentIndex = 0;
    }

    public void NPCChatEnter(string text)   //Panel Ȱ��
    {
        NPCText.text = text;
        Dialog(0);
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
            string sentence = Dialog(currentIndex);
            NextDialog.SetActive(false);

            //yield return new WaitForSeconds(0.5f);  //Ÿ���� ���� ���
            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.01f); //Ÿ���� ����
            }
            NextDialog.SetActive(true);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.G));
            currentIndex++;

            if (currentIndex >= m_text.Length)
            {
                break;
            }
        }
        NPCChatExit();  
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

    public string Dialog(int Index)
    {
        currentIndex = Index;
        m_text = new string[] 
            {   //����: 0, ����: 1, ����: 2, �����̼�: 3      {���� ��ȣ, ���ϴ»��}
                "�ֱ� �б� ������ ������ �����ϴ� �л����̴þ���ִ�. \n������ �����ϴ� �л����� �þ�鼭 ���� �̻������� ���̱� �����ϴµ���.", //{0, 3}
                "���ƾ� ���ƾ� , ���� ��¥ ���� �� �����Ծ�!", //{1, 1}
                "���淡 �׷��� ȣ�鰩�̾�? �׷� �ѹ� ����",  //{2, 0}
                "(���� ��Ҹ���) ���� �б����� �� �ҹ� ���ݾ�? �װ� �����Ծ� ����.",   //{3, 1}
                "(��� ��Ҹ���) ��? �� ���� ���ƾ�? ��� �׷� �� ������ �� �� �� �ŷ� �Ұ�. �̰� �ƴϾ�.", //{4, 0}
                "������ ���¸� �ڷ� �ϰ� ���Ƿ� ����.", //{5, 3}
                "�׷��� ���´�. �̰���? �׷� �˰ھ�. (���𰡸� ������� �ִ´�)",    //{6, 1}
                "���ƾ� �̾�, ���� �峭�� ������? �̰� ���ð� ȭ Ǯ�� \n(���ƿ��� ������� �ǳٴ�)",    //{7, 1}
                "�׷�, �峭�̾ �׷� �ŷδ� ���� ��",    //{8, 0}
                "������ �ǳ��� ������� ���Ŵ�.  ����� ���� �����ؼ� �׷���? ����� �� �̻��ϴ�.",  //{9, 3}
                "������ �������� ����, �������� ����ġ�� �л����� �ǽ� ������ ����� �ٶ󺸸鼭 ȥ�㸻�� �Ѵ�.", //{10, 3}
                "ǳ��,ǳ�� ���� �پ���", //{11, 3}
                "���� ���� ũ��, ���� �̻ڴ�..", //{12, 3}
                "�� ����� ���� �߾�Ÿ��� ����? ���� �������߰ڴ�",  //{13, 0}
                "�л����� ����ġ�� ģ�� ������ ����ģ��. ",  //{14, 3}
                "������! ���� �ٸ� �ֵ� ���°� �̻���..", //{15, 2}
                "�ٸ� ���� �׷�? ���⼭��..", //{16, 0}
                "��ȭ�� �ϴ� �� �ڿ��� �پ���� �Ҹ��� �鸰��. ",  //{17, 3}
                "���� , �츮 , ���� ������?",    //{18, 3}
                "���� ����, �ʸ� ? ���� ����!"    //{19, 3}
            };
        currentPlayer = new int[] 
        {
            3, 1, 0, 1, 0,
            3, 1, 1, 0, 3,
            3, 3, 3, 0, 3,
            2 ,0, 3, 3, 3
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

    }
}
