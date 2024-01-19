using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [Header("Title UI Objects")]
    [SerializeField]
    private List<GameObject> title_ui;

    enum MenuState{idle, exit, credit, gameplay};                               // UI 열려 있는 상태 조절하기 위한 enum 객체

    private bool isExit = false;
    private bool isCredit = false;
    private MenuState menu_state;

    private void Awake()
    {
        foreach(GameObject ui_object in title_ui) ui_object.SetActive(false);   // 초기 불필요한 화면 비활성화
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))                                // esc키를 이용해서 UI 화면 비활성화
        {
            if(menu_state == MenuState.credit) OpenCreditMenu();
            else OpenExitMenu();

        }
    }

    public void OpenExitMenu()                                            // 나가기 UI 활성 및 비활성화
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

    public void OpenCreditMenu()                                        // Credit UI 활성 및 비활성화
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

    public void StartGamePlay()                      // 게임 선택 UI 활성 및 비활성화
    {
        SceneManager.LoadScene("WorldMapScene");
    }

    public void MiniGameScene()                        // 게임 선택 시 미니 게임 씬 전환
    {
        SceneManager.LoadScene("MiniGameScene");
    }

    public void PlatformerScene()                      // 게임 선택 시 플랫포머 씬 전환
    {
        SceneManager.LoadScene("Platformer_School");
    }
}
