using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [Header("Title UI Objects")]
    [SerializeField]
    private List<GameObject> title_ui;

    private bool isExit = false;
    private bool isCredit = false;

    private void Awake()
    {
        foreach(GameObject ui_object in title_ui) ui_object.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isCredit) OpenCreditMenu();
            else OpenExitMenu();
        }
    }

    public void OpenExitMenu()
    {
        // title_ui[0] = ExitLayer
        if(isExit)
        {
            title_ui[0].SetActive(false);
            isExit = false;
        }
        else
        {
            title_ui[0].SetActive(true);
            isExit = true;
        }
    }

    public void OpenCreditMenu()
    {
        // title_ui[1] = CreditLayer
        if(isCredit)
        {
            title_ui[1].SetActive(false);
            isCredit = false;
        }
        else
        {
            title_ui[1].SetActive(true);
            isCredit = true;
        }
    }

    public void OpenGamePlayMenu()
    {
        
    }
}
