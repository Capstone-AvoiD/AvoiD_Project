using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [Header("Title UI Objects")]
    [SerializeField]
    private List<GameObject> title_ui;

    enum MenuState{idle, exit, credit, gameplay};

    private bool isExit = false;
    private bool isCredit = false;
    private MenuState menu_state = MenuState.idle;

    private void Awake()
    {
        foreach(GameObject ui_object in title_ui) ui_object.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu_state == MenuState.credit) OpenCreditMenu();
            else if(menu_state == MenuState.gameplay) OpenGamePlayMenu();
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
            menu_state = MenuState.idle;
        }
        else
        {
            title_ui[0].SetActive(true);
            isExit = true;
            menu_state = MenuState.exit;
        }
    }

    public void OpenCreditMenu()
    {
        // title_ui[1] = CreditLayer
        if(isCredit)
        {
            title_ui[1].SetActive(false);
            isCredit = false;
            menu_state = MenuState.idle;
        }
        else
        {
            title_ui[1].SetActive(true);
            isCredit = true;
            menu_state = MenuState.credit;
        }
    }

    public void OpenGamePlayMenu()
    {
        
    }
}
