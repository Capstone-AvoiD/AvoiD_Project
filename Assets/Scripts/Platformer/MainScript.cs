using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class MainScript : MonoBehaviour //Panel 활성, 비활성
{
    private GameObject NPCDialog;
    private TextMeshProUGUI NPCText ;
    string m_text = "안녕 반가워! 밥은 잘 먹었어?";
    StringBuilder strb = new StringBuilder();

    // Start is called before the first frame update
        
    void Start()
    {
        NPCDialog = GameObject.Find("NPCDialog");
        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel 비활성
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
        StopCoroutine(TypingText());
        NPCText.text = "";
        NPCDialog.SetActive(false);
        
    }    

    IEnumerator TypingText()    //텍스트 타이핑 효과 코루틴
    {
        yield return new WaitForSeconds(0.5f);  //타이핑 시작 대기
        for (int i = 0; i <= m_text.Length; i++)
        {
            NPCText.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.15f); //타이핑 간격
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
