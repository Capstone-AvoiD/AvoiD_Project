using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class MainScript : MonoBehaviour //Panel 활성, 비활성
{
    private GameObject NPCDialog;
    private GameObject NextText;
    private TextMeshProUGUI NPCText;
    private TextMeshProUGUI NPCName;
    private int currentIndex;   //현재 대화문의 번호
    string[] m_text;    //대사

    private string[] playerName = new string[] { "Dohun", "Seongtae", "Sohyun", "narration" };
    private int setPlayerImage;  // 도훈: 0, 성태: 1, 소현: 2 나레이션: 3
    private int[] currentPlayer;    //현재 말하는 캐릭터
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
        NPCDialog.SetActive(false); //Panel 비활성
        NextText.SetActive(false); //Panel 비활성
        currentIndex = 0;
    }

    public void NPCChatEnter(string text)   //Panel 활성
    {
        NPCText.text = text;
        Dialog(0);
        NPCDialog.SetActive(true);
        StartCoroutine(TypingText());   //텍스트 타이핑 효과 코루틴 시작
    }
    
    public void NPCChatExit()   //Panel 비활성
    {
        StopAllCoroutines();    //코루틴 종료
        //StopCoroutine(TypingText());
        NPCDialog.SetActive(false);
        NPCText.text = "";
        NPCName.text = "";
        currentIndex = 0;
        
    }

    IEnumerator TypingText()    //텍스트 타이핑 효과 코루틴
    {
        while (currentIndex < m_text.Length)    //모든 지정 텍스트 출력
        {
            string sentence = Dialog(currentIndex);
            NextText.SetActive(false);

            //yield return new WaitForSeconds(0.5f);  //타이핑 시작 대기
            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.05f); //타이핑 간격
            }
            NextText.SetActive(true);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.G));
            currentIndex++;

            if (currentIndex >= m_text.Length)
                break;
        }
        NPCChatExit();  
    }

    public void DialogImage()   //캐릭터 이미지 초기설정
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
            {   //도훈: 0, 성태: 1, 소현: 2, 나레이션: 3      {현재 번호, 말하는사람}
                "최근학교내에서마약을복용하는학생들이늘어나고있다. \n마약을복용하는학생들이늘어나면서점차이상증세를보이기시작하는데..", //{0, 3}
                "도훈아 도훈아 , 내가 진짜 좋은 거 가져왔어!", //{1, 1}
                "뭐길래 그렇게 호들갑이야? 그래 한번 보자",  //{2, 0}
                "(작은 목소리로) 요즘 학교에서 그 소문 있잖아? 그거 가져왔어 마약.",   //{3, 1}
                "(놀란 목소리로) 뭐? 너 정말 미쳤어? 어떻게 그런 걸 가져와 난 못 본 거로 할게. 이건 아니야." //{4, 0}
            };
        currentPlayer = new int[] 
        {
            3, 1, 0, 1, 0, 
        };
        setPlayerImage = currentPlayer[currentIndex];

        switch (setPlayerImage)   //말하는 캐릭터의 이미지
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
