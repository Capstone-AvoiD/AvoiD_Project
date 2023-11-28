using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image FadePanel;
    float time = 0.0f;  //���ӽð�
    float F_time = 1.0f;    //�� ���ӽð�
    float f = 1.0f;
    float F
    {
        get { return f; }
        set
        {
            f = value;
            // Sene ���ε� 
        }
    }

    public void Fade()
    {
        StartCoroutine(FadeFlow()); //�ڷ�ƾ ����
    }
    IEnumerator FadeFlow()
    {
        FadePanel.gameObject.SetActive(true);   //�̹��� Ȱ��ȭ
        time = 0;
        Color alpha = FadePanel.color;  //Color alpha����
        
        while(alpha.a < 1.0f)   //Fade Out
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);   //�ε巴�� ��ȯ
            FadePanel.color = alpha;    //�� ������ �̹����� alpha ����
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);  //1�� ������

        while (alpha.a > 0.0f)  //Fade In
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);   //�ε巴�� ��ȯ
            FadePanel.color = alpha;    //�� ������ �̹����� alpha����
            yield return null;
        }
        FadePanel.gameObject.SetActive(false);  //�̹��� ��Ȱ��ȭ
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
