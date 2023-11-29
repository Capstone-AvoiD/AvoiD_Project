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
    public string[] m_text;
    private int currentIndex;

    private string[] playerName = new string[] { "Dohun", "Seongtae", "Sohyun" };
    private int currentPlayer;  // 도훈: 0, 성태: 1, 소현: 2
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
            switch (currentPlayer)   //말하는 캐릭터 이미지
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

            switch (currentIndex)   //말하는 캐릭터 이미지
            {
                case 0:
                case 3:
                    currentPlayer = 0;  //도훈
                    break;
                case 1:
                case 5:
                    currentPlayer = 1;  //성태
                    break;
                case 2:
                    currentPlayer = 2; // 소현
                    break;
            }

            string sentence = m_text[currentIndex];
            NPCName.text = playerName[0];
            NextText.SetActive(false);

            //yield return new WaitForSeconds(0.5f);  //타이핑 시작 대기
            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.15f); //타이핑 간격
            }
            NextText.SetActive(true);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.G));
            currentIndex++;
        }
        currentIndex = 0;   //대화 종료시 초기화
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
