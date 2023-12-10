using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class LastMainScript : MonoBehaviour //Panel Ȱ��, ��Ȱ��
{
    private GameObject NPCDialog;
    private GameObject NextDialog;
    private GameObject SkipDialog;
    private GameObject SelectionDialog;
    private TextMeshProUGUI NPCText;
    private TextMeshProUGUI NPCName;

    public Button button1; // ù ��° ��ư�� Inspector â���� �Ҵ�
    public Button button2; // �� ��° ��ư�� Inspector â���� �Ҵ�

    private int selectNum = 0;
    string[] m_text;    //���
    string[] hospitalText;
    string[] schoolText;
    private int currentIndex;   //���� ��ȭ���� ��ȣ

    private string[] playerName =  
        new string[] { "����", "����", "����", " " };
    private int setPlayerImage;  // ����: 0, ����: 1, ����: 2 �����̼�: 3
    private int[] currentPlayer;    //���� ���ϴ� ĳ����
    private int[] hospitalPlayer;
    private int[] schoolPlayer;
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
        SelectionDialog = GameObject.Find("SelectionDialog");

        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCName = GameObject.Find("NPCName").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel ��Ȱ��
        NextDialog.SetActive(false); //Panel ��Ȱ��
        SkipDialog.SetActive(false); //Panel ��Ȱ��
        SelectionDialog.SetActive(false);

        /*button1.onClick.AddListener(() => OnButtonClick(button1));
        button2.onClick.AddListener(() => OnButtonClick(button2));*/

        currentIndex = 0;

        Invoke("PlayerSelect", 2.0f);
        //Invoke("NPCChatEnter", 2.0f);
    }

    public void PlayerSelect()
    {
        SelectionDialog.SetActive(true);
    }

    public void OnHospitalButtonClick()
    {
        selectNum = 1;
        SelectionDialog.SetActive(false);
        NPCChatEnter();
    }

    public void OnSchoolButtonClick()
    {
        selectNum = 2;
        SelectionDialog.SetActive(false);
        NPCChatEnter();
    }

    public void NPCChatEnter()   //Panel Ȱ��
    {
        NPCText.text = "";
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
        hospitalText = new string[10]
            {   //����: 0, ����: 1, ����: 2, �����̼�: 3      {���� ��ȣ, ���ϴ»��}
                "������ �������� ������ �����ߴ�.",
                "������ ���� ������ �ǻ� �����Կ��� �̾߱��ϸ� ���޽ǿ��� ���� �ص� ġ�Ḧ �ް� �Ǿ���.",
                "�ǻ� �����Կ��� ���ݸ� �� �ʾ����� ġ�� �ñ⸦ ������ ���̶�� ������ �� �Դٸ� �����ָ� ������ ���輺�� ���� ������ ���̴ּ�.",
                "�츮�� ������ �� �̻����� ������ ��û���� ������ ������ �����ϸ�\n�ߵ����� ����� ����� ������ ķ���� ������ �����ϼ̴�.",
                "�ǻ� �������� �����ð� �������� ����.",
                "TV�� Ű��, �츮 �б��� ���Դ�.",
                "10�� �������� �˰�.",
                "�� �տ� ���·� ���̴� �л��� �츮���� �޷���� �л����� �������� ü���Ǿ� �������� ���.",
                "�׷��� ���ϸ� ���� �б��� �������� ���������.",
                "����Ŭ����."
            };
        hospitalPlayer = new int[10]   //�� ��� ������ �´� �÷��̾� 
        {
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        };

        schoolText = new string[10]
            {   //����: 0, ����: 1, ����: 2, �����̼�: 3      {���ϴ»��}
                "�б� ���Ƿ� �ٽ� ���ư��� ����.",   //3
                "���Ǿȿ��� ���°� �ݱ��.",   //3
                "��..���¾� �Ʊ� �� �����. ����� �� �־�?",   //0
                "�װź��� �� ������ �ٰ� ��.", //1
                "���´� ó���� ������ �� ������ ������ �ǳ��ش�.",  //3
                "�� ��������� �� �����ž�. �ξ� �� ������?",    //1
                "������ ���� ������ ���ÿ� �ǳ��� ���� ��Ų��.",   //0
                "ȯ�������� �� ��������.",    //0
                "����ؼ� ���°� �ǳ��� ������� ������ �������١�",  //0
                "���� ����."    //0
            };
        schoolPlayer = new int[10]   //�� ��� ������ �´� �÷��̾� 
        {
            3, 3, 0, 1, 3,
            1, 0, 0, 0, 0
        };
        if (selectNum == 1)
        {
            m_text = hospitalText;
            currentPlayer = hospitalPlayer;
        }
        else if (selectNum == 2)
        {
            m_text = schoolText;
            currentPlayer = schoolPlayer;
        }
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
