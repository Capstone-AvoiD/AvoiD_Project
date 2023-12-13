using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapManager : MonoBehaviour
{
    [HideInInspector]
    public enum StageState {School, Ground, Park};
    [HideInInspector]
    public static StageState stageState = StageState.School;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckStage();
    }

    private void CheckStage()
    {
        switch(stageState)
        {
            case StageState.School:
                ReadyGame();
                break;
            case StageState.Ground:
                ReadyGame();
                break;
            case StageState.Park:
                ReadyGame();
                break;
        }
    }

    private void ReadyGame()
    {

    }
}
