using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameFade : MonoBehaviour
{
    [SerializeField] private GameObject fadeObj;
    private Image fadeImg;

    private float fadeSpeed = 0.7f;

    private void Awake()
    {
        fadeImg = fadeObj.GetComponent<Image>();
    }
    
    public IEnumerator FadeIn(string sceneName)
    {
        fadeObj.SetActive(true);

        while(fadeImg.color.a < 1.0f)
        {
            fadeImg.color = new(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, fadeImg.color.a + fadeSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator FadeOut()
    {
        while(fadeImg.color.a > 0.0f)
        {
            fadeImg.color = new(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, fadeImg.color.a - fadeSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        fadeObj.gameObject.SetActive(false);
    }
}
