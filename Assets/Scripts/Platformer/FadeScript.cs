using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image Panel;
    float time = 0.0f;  //���ӽð�
    float F_time = 1.0f;    //�� ���ӽð�

    public void Fade()
    {
        StartCoroutine(FadeFlow()); //�ڷ�ƾ ����
    }
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);   //�̹��� Ȱ��ȭ
        time = 0;
        Color alpha = Panel.color;  //Color ����
        
        while(alpha.a < 1.0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);   //�ε巴�� ��ȯ
            Panel.color = alpha;    //�� ������ �̹����� alpha ����
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);

        while (alpha.a > 0.0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);   //�ε巴�� ��ȯ
            Panel.color = alpha;    //�� ������ �̹����� alpha����
            yield return null;
        }
        Panel.gameObject.SetActive(false);
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
