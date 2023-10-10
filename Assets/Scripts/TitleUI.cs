using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [Header("Title UI Objects")]
    [SerializeField]
    private List<GameObject> title_ui;

    private bool isExit = false;

    private void Awake()
    {
        if(title_ui[0].name == "ExitLayer") title_ui[0].SetActive(false);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) OpenExitMenu();
    }

    public void OpenExitMenu()
    {
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
}
