using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class StartStateScript : MonoBehaviour
{
    private bool _isWaiting;
    [SerializeField] private Text _touchText;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private Animator Player1Anim;
    [SerializeField] private Animator Player2Anim;


    private void OnEnable()
    {
        StartPanel.SetActive(true);
        _isWaiting = true;
        StartCoroutine(TextAnimation());

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.GetInstance().ChangeState(StateType.GameState);


        }
    }


    private void OnDisable()
    {
        StartPanel.SetActive(false);
        GameManager.GetInstance().ChangeState(StateType.GameState);

    }

    private IEnumerator TextAnimation()
    {
        float t = 0;
        while (_isWaiting)
        {
            float val =  Mathf.PingPong(t, 0.7f) + 0.1f;
            _touchText.color = new Color(0,0,0,val);
            yield return null;
            t += Time.deltaTime; 
        }
        
    }
}
