using System.Collections;
using System.Collections.Generic;
using GamePlay;
using Managers;
using UnityEngine;

public class GameStateScript : MonoBehaviour
{

    [SerializeField] private MonoBehaviour[] GameScripts;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private Animator Player1Anim;
    [SerializeField] private Animator Player2Anim;

    private void OnEnable()
    {
        GamePanel.SetActive(true);
        PlayersController.GetInstance().isGameState = true;
        Player1Anim.SetBool("isRunning", true);
        Player2Anim.SetBool("isRunning", true);
        foreach (var script in GameScripts)
        {
            script.enabled = true;
        }
    }

    private void OnDisable()
    {
        GamePanel.SetActive(false);
        PlayersController.GetInstance().isGameState = false;
        foreach (var script in GameScripts)
        {
            script.enabled = false;
        }
        GameManager.GetInstance().ChangeState(StateType.ShootState);
        
    }
}
