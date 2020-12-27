using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "Player 1") || (other.gameObject.tag == "Player 2"))
        {
            //Failed
            GameManager.GetInstance().isFailed = true;
            GameManager.GetInstance().ChangeState(StateType.FinalState);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameManager.GetInstance().isFailed = true;
            GameManager.GetInstance().ChangeState(StateType.FinalState);

            //Failed
        }
    }
}
