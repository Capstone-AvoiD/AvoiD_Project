using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class MainScript : MonoBehaviour //Panel 활성, 비활성
{
    private GameObject NPCDialog;
    private GameObject NextDialog;
    private TextMeshProUGUI NPCText;
    private TextMeshProUGUI NPCName;
    private int currentIndex;   //현재 대화문의 번호
    string[] m_text;    //대사

    private string[] playerName = new string[] { "도훈", "성태", "소현", " " };
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
        NextDialog = GameObject.Find("NextText");
        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCName = GameObject.Find("NPCName").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel 비활성
        NextDialog.SetActive(false); //Panel 비활성
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
            NextDialog.SetActive(false);

            //yield return new WaitForSeconds(0.5f);  //타이핑 시작 대기
            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.01f); //타이핑 간격
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
                "최근 학교 내에서 마약을 복용하는 학생들이늘어나고있다. \n마약을 복용하는 학생들이 늘어나면서 점차 이상증세를 보이기 시작하는데….", //{0, 3}
                "도훈아 도훈아 , 내가 진짜 좋은 거 가져왔어!", //{1, 1}
                "뭐길래 그렇게 호들갑이야? 그래 한번 보자",  //{2, 0}
                "(작은 목소리로) 요즘 학교에서 그 소문 있잖아? 그거 가져왔어 마약.",   //{3, 1}
                "(놀란 목소리로) 뭐? 너 정말 미쳤어? 어떻게 그런 걸 가져와 난 못 본 거로 할게. 이건 아니야.", //{4, 0}
                "도훈은 성태를 뒤로 하고 교실로 들어간다.", //{5, 3}
                "그렇게 나온다. 이거지? 그래 알겠어. (무언가를 음료수에 넣는다)",    //{6, 1}
                "도훈아 미안, 내가 장난이 심했지? 이거 마시고 화 풀어 \n(도훈에게 음료수를 건넨다)",    //{7, 1}
                "그래, 장난이어도 그런 거로는 하지 마",    //{8, 0}
                "도훈은 건네준 음료수를 마신다.  음료수 맛이 상쾌해서 그런가? 기분이 좀 이상하다.",  //{9, 3}
                "복도를 지나가는 도훈, 복도에서 마주치는 학생들은 실실 웃으며 허공을 바라보면서 혼잣말을 한다.", //{10, 3}
                "풍선,풍선 색깔 다양해", //{11, 3}
                "나비 날개 크다, 나비 이쁘다..", //{12, 3}
                "왜 허공을 보고 중얼거리는 거지? 빨리 지나가야겠다",  //{13, 0}
                "학생들을 지나치자 친구 소현을 마주친다. ",  //{14, 3}
                "도현아! 지금 다른 애들 상태가 이상해..", //{15, 2}
                "다른 곳도 그래? 저기서도..", //{16, 0}
                "대화를 하던 중 뒤에서 뛰어오는 소리가 들린다. ",  //{17, 3}
                "저곳 , 우리 , 같이 좋은거?",    //{18, 3}
                "좋은 냄새, 너만 ? 나도 나도!"    //{19, 3}
            };
        currentPlayer = new int[] 
        {
            3, 1, 0, 1, 0,
            3, 1, 1, 0, 3,
            3, 3, 3, 0, 3,
            2 ,0, 3, 3, 3
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
