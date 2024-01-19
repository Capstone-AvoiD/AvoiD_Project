using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ParkMainScript : MonoBehaviour //Panel 활성, 비활성
{
    private GameObject NPCDialog;
    private GameObject NextDialog;
    private GameObject SkipDialog;
    private TextMeshProUGUI NPCText;
    private TextMeshProUGUI NPCName;

    string[] m_text;    //대사
    private int currentIndex;   //현재 대화문의 번호

    private string[] playerName =  
        new string[] { "도훈", "성태", "소현", " " };
    private int setPlayerImage;  // 도훈: 0, 성태: 1, 소현: 2 나레이션: 3
    private int[] currentPlayer;    //현재 말하는 캐릭터
    private GameObject NPC_Dohun;//캐릭터 이미지
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
        NPCDialog.SetActive(false); //Panel 비활성
        NextDialog.SetActive(false); //Panel 비활성
        SkipDialog.SetActive(false); //Panel 비활성

        currentIndex = 0;
    }

    public void NPCChatEnter(string text)   //Panel 활성
    {
        NPCText.text = text;
        Dialog(0);  //처음 대사 출력
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
        currentIndex = 0;   //대사 번호 초기화
    }

    IEnumerator TypingText()    //텍스트 타이핑 효과 코루틴
    {
        while (currentIndex < m_text.Length)    //모든 지정 텍스트 출력
        {
            //currentIndex = 현재 대사 번호, Dialog = 대사가 들어있는 함수
            string sentence = Dialog(currentIndex); //순서에 맞는 대사 출력

            NextDialog.SetActive(false);    //대사 출력 후 나타나도록
            SkipDialog.SetActive(false);

            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.01f); //타이핑 간격
            }

            NextDialog.SetActive(true);
            SkipDialog.SetActive(true);

            //G키 누를 때까지 대기
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.G));  

            currentIndex++; //다음 대사가 출력 되도록

            if (currentIndex >= m_text.Length)  //정해진 대사 모두 출력시 종료
            {
                break;
            }
        }
        NPCChatExit();  //Dialog 종료
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

    public string Dialog(int Index) //대사 목록
    {
        currentIndex = Index;
        m_text = new string[]
            {   //도훈: 0, 성태: 1, 소현: 2, 나레이션: 3      {말하는사람}
                "학생들을 피해 학교 밖으로 나온 도훈과 소현", //3
                "음료수..음료수..성태가 건네준 음료수가 자꾸 머릿속에 맴돌아.. 소현아 다시 학교로 돌아가야 할 거 같아.", //0
                "불안한 듯 자꾸 학교 쪽으로 시선을 바라보는 도훈. 손톱을 자꾸만 깨물면서 불안한 듯 온몸을 떤다.",  //3
                "지금 저기로 돌아간다고? 도훈아 정신 차려! 너 저 애들처럼 상태가 이상해 보여 무슨 일이야?", //2
                "성태가 건네준 음료수가 자꾸만 생각나 머릿속이 어지럽고 그걸 안마시면 불안해 미칠 거 같아.",  //0
                "아까 운동장에서 애들이 약을 달라고 외치던데.. 소문대로 학교내에 마약이 정말이 퍼진 건가 봐", //2
                "그러고 보니 성태가 처음에는 나한테 마약을 권했어.. 그 음료수에 마약이 들어가 있었나 봐.",  //0
                "지금 도훈, 너 마약 중독 초기 증상이야 계속해서 복용했다간 저 애들처럼 위험해질 거야 빠르게 치료를 위해서라도 당장 병원으로 가자!",   //2
                "[달려오는 소리]",    //3
                "학생들 -쟤 쟤네 분명 마약! 마약! 단어 들었어 쟤네한테 있어! 있어!", //3
                "학생들 -더 필요해 더 필요해 더 필요해! 우리꺼 내?내놔! 가 같이!"   //3
            };
        currentPlayer = new int[]   //각 대사 순서에 맞는 플레이어 
        {
            3, 0, 3, 2, 0,
            2, 0, 2, 3, 3,
            3
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
        if (Input.GetKeyDown(KeyCode.P))    //P키 눌러 스킵
            NPCChatExit();
    }
}
