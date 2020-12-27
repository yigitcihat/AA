using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
using Managers;
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] GamePlay.BallController ballController;
    Animator animator;

    [SerializeField] private MonoBehaviour[] GameScripts;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject ShootState;
    [SerializeField] private GameObject FinalState;



    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        if (GamePanel.activeSelf)
        {
            Debug.Log("koşma");

            animator.SetBool("isRunning", true);
        }
        else if (StartPanel.activeSelf)
        {
            Debug.Log("durağan");

            animator.SetBool("isRunning", false);

        }
        else if (ShootState.activeSelf)
        {
            if (ballController.throwDirection == Direction.Right)
            {
                //Player 1 gol atma animasyon
                //Player 2 tezaürat animasyon
            }
            else
            {

                //Player 2 gol atma animasyon
                //Player 1 tezaürat animasyon
            }
        }

    }

    
}
