using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStateScript : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _ball;
    [SerializeField] private float speed;
    [SerializeField] private CameraScript _cam;
    [SerializeField] private Animator Player1Anim;
    [SerializeField] private Animator Player2Anim;
    [SerializeField] GamePlay.BallController ballController;

    private void OnEnable()
    {

        Debug.Log("ShootState girildi");
        _cam.ChangeTarget(_ball);
        Time.timeScale = 0.3f;
        
    }

    private void OnDisable()
    {
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (ballController.throwDirection == Direction.Right)
            {
                Player1Anim.SetTrigger("isGoal");
                Player2Anim.SetBool("isSupport", true);
            }
            else
            {
                Player2Anim.SetTrigger("isGoal");
                Player1Anim.SetBool("isSupport", true);
            }
            StartCoroutine(CalculateTrajectory());
            
        }
    }



    private IEnumerator  CalculateTrajectory()
    {
        Time.timeScale = 1;
        Vector3 targetDir = (_target.transform.position - _ball.transform.position).normalized;
        yield return new WaitForSeconds(0.5f);
        _ball.GetComponent<Rigidbody>().AddForce(targetDir*speed);
    }
}
