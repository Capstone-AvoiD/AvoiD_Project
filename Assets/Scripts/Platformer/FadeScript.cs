using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image FadePanel;
    float time = 0.0f;  //지속시간
    float F_time = 1.0f;    //총 지속시간

    float f = 1.0f;
    float F
    {
        get { return f; }
        set
        {
            f = value;

            // Sene 씬로드 
        }
    }

    public void Fade()
    {
        StartCoroutine(FadeFlow()); //코루틴 시작
    }
    IEnumerator FadeFlow()
    {
        FadePanel.gameObject.SetActive(true);   //이미지 활성화
        time = 0;
        Color alpha = FadePanel.color;  //Color 변수
        
        while(alpha.a < 1.0f)   //Fade Out
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);   //부드럽게 전환
            FadePanel.color = alpha;    //매 프레임 이미지에 alpha 대입
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);

        while (alpha.a > 0.0f)  //Fade In
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);   //부드럽게 전환
            FadePanel.color = alpha;    //매 프레임 이미지에 alpha대입
            yield return null;
        }
        FadePanel.gameObject.SetActive(false);
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
