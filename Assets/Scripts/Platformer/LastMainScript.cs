using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class LastMainScript : MonoBehaviour //Panel 활성, 비활성
{
    private GameObject NPCDialog;
    private GameObject NextDialog;
    private GameObject SkipDialog;
    private GameObject SelectionDialog;
    private TextMeshProUGUI NPCText;
    private TextMeshProUGUI NPCName;

    public Button button1; // 첫 번째 버튼을 Inspector 창에서 할당
    public Button button2; // 두 번째 버튼을 Inspector 창에서 할당

    private int selectNum = 0;
    string[] m_text;    //대사
    string[] hospitalText;
    string[] schoolText;
    private int currentIndex;   //현재 대화문의 번호

    private string[] playerName =  
        new string[] { "도훈", "성태", "소현", " " };
    private int setPlayerImage;  // 도훈: 0, 성태: 1, 소현: 2 나레이션: 3
    private int[] currentPlayer;    //현재 말하는 캐릭터
    private int[] hospitalPlayer;
    private int[] schoolPlayer;
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
        SelectionDialog = GameObject.Find("SelectionDialog");

        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCName = GameObject.Find("NPCName").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel 비활성
        NextDialog.SetActive(false); //Panel 비활성
        SkipDialog.SetActive(false); //Panel 비활성
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

    public void NPCChatEnter()   //Panel 활성
    {
        NPCText.text = "";
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
        hospitalText = new string[10]
            {   //도훈: 0, 성태: 1, 소현: 2, 나레이션: 3      {현재 번호, 말하는사람}
                "무사히 빠져나와 병원에 도착했다.",
                "무사히 현재 증상을 의사 선생님에게 이야기하며 응급실에서 마약 해독 치료를 받게 되었다.",
                "의사 선생님에게 조금만 더 늦었으면 치료 시기를 놓쳤을 것이라며 무사히 잘 왔다며 말해주며 마약의 위험성에 관해 설명을 해주셨다.",
                "우리가 생각한 것 이상으로 마약은 엄청나게 위험한 증상을 유발하며\n중독에서 벗어나기 힘드니 꾸준한 캠페인 참여를 권유하셨다.",
                "의사 선생님이 나가시고 조용해진 병실.",
                "TV를 키자, 우리 학교가 나왔다.",
                "10대 마약사범들 검거.",
                "맨 앞에 성태로 보이는 학생과 우리에게 달려들던 학생들이 경찰에게 체포되어 끌려가는 장면.",
                "그렇게 백일몽 같던 학교의 마약사건이 사라져갔다.",
                "게임클리어."
            };
        hospitalPlayer = new int[10]   //각 대사 순서에 맞는 플레이어 
        {
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        };

        schoolText = new string[10]
            {   //도훈: 0, 성태: 1, 소현: 2, 나레이션: 3      {말하는사람}
                "학교 교실로 다시 돌아가는 도훈.",   //3
                "교실안에는 성태가 반긴다.",   //3
                "성..성태야 아까 그 음료수. 음료수 또 있어?",   //0
                "그거보다 더 좋은거 줄게 자.", //1
                "성태는 처음에 보여준 그 마약을 꺼내서 건네준다.",  //3
                "그 음료수보다 더 좋은거야. 훨씬 더 좋을걸?",    //1
                "성태의 말이 끝남과 동시에 건네준 약을 삼킨다.",   //0
                "환각증상이 더 심해진다.",    //0
                "계속해서 성태가 건네준 음료수와 마약이 생각난다…",  //0
                "게임 오버."    //0
            };
        schoolPlayer = new int[10]   //각 대사 순서에 맞는 플레이어 
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
