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
    public string[] m_text;
    private int currentIndex;
    StringBuilder strb = new StringBuilder();

    // Start is called before the first frame update
        
    void Start()
    {
        NPCDialog = GameObject.Find("NPCDialog");
        NPCText = GameObject.Find("NPCText").GetComponent<TextMeshProUGUI>();
        NPCDialog.SetActive(false); //Panel 비활성
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
        //StopAllCoroutines();    //코루틴 종료
        StopCoroutine(TypingText());
        NPCText.text = "";
        NPCDialog.SetActive(false);
        currentIndex = 0;
    }
    IEnumerator TypingText()
    {
            string sentence = m_text[currentIndex];

            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i <= sentence.Length; i++)
            {
                NPCText.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(0.15f);
            }

            Debug.Log(currentIndex);
            currentIndex++;
            // 마지막 문장이 아닌 경우에만 대기 시간 추가
            if (currentIndex < m_text.Length)
                yield return new WaitForSeconds(1.5f); // 수정된 부분
        
    }

    /*IEnumerator TypingText()    //텍스트 타이핑 효과 코루틴
    {
        if(currentIndex >= m_text.Length)
        {
            NPCDialog.SetActive(false);
            currentIndex = 0;
            yield break;
        }

        string sentence = m_text[currentIndex];

        yield return new WaitForSeconds(0.5f);  //타이핑 시작 대기
        for (int i = 0; i <= sentence.Length; i++)
        {
            NPCText.text = sentence.Substring(0, i);
            yield return new WaitForSeconds(0.15f); //타이핑 간격
        }
        currentIndex++;
    }*/
    // Update is called once per frame
    void Update()
    {

    }
}
