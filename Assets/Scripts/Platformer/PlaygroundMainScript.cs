using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class PlaygroundMainScript : MonoBehaviour //Panel 활성, 비활성
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
                "학교 건물 밖을 피해 운동장으로 무사히 도망쳐 나온 도훈과 소현.\n거친 호흡을 내뱉으며 대화한다.",    //3
                "무슨 일 이지? 애들이 왜 전부 달려드는 걸까",    //0
                "다들 상태가 이상해 보여.. 엄청 공격적이고 무언가에 미쳐 있는 사람들처럼",    //2
                "???-으어어...",    //3
                "[깜짝 놀라 소리가 난 곳을 쳐다보는 둘]",    //3
                "위험해 보이는 학생A -약...약...약이 더..필요해..!",    //3
                "위험해 보이는 학생B -쟤쟤쟤쟤쟤쟤네 치치치치침침 안 안 안 안흘흘흘려!",    //3
                "위험해 보이는 학생들 -우 우 우 우 우리한테 내내 내 내놔!!",    //3
                "소리 지르며 달려드는 학생들",    //3
                "일단 학교 밖으로 빠져나가자!",    //2
                "[달려오는 학생들을 피하고자 달리는 도훈과 소현]",    //3
                "윽.. 머리가 지끈거려.. 아까 마셨던 음료수가 자꾸 생각나.. 음료수..음료수...계속 마시고 싶어..'"    //0
            };
        currentPlayer = new int[]   //각 대사 순서에 맞는 플레이어 
        {
            3, 0, 2, 3, 3,
            3, 3, 3, 3, 2,
            3, 0
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
