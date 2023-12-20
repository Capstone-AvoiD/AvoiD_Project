using UnityEngine;

public class WorldMapManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private WorldMapPlayerMove playerMove;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if(gameManager != null) CheckStage();
    }
    
    private void CheckStage()
    {
        switch(gameManager.CheckState())
        {
            case GameManager.GameClearState.None:
                StartCoroutine(playerMove.StandMove(playerMove.bezierSToS));
                break;
            case GameManager.GameClearState.School:
                StartCoroutine(playerMove.LinearMove(playerMove.bezierSToG));
                break;
            case GameManager.GameClearState.Ground:
                StartCoroutine(playerMove.BezierMove(playerMove.bezierGToP));
                break;
            case GameManager.GameClearState.Park:
                break;
        }
    }
}
