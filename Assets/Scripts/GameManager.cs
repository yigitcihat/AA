using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
    
        private static GameManager _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    
        public static GameManager GetInstance()
        {
            return _instance;
        }
    
        #endregion
        public StateType currentState;
        [SerializeField] private GameObject [] StateScripts;
        private Vector3 startDistance;
        private Vector3 currentDistance;
        [SerializeField] private GameObject _basket;
        [SerializeField] private Slider _slider;
        public bool isFailed;
        private void Start()
        {
            startDistance = (_basket.transform.position-PlayersController.GetInstance().gameObject.transform.position);
            _slider.maxValue = startDistance.magnitude;
            ChangeState(StateType.StartState);
        }

        private void Update()
        {
           SliderWrite();
        }


        public void ChangeState(StateType type)
        {
            currentState = type;
            switch (currentState)
            {
                case StateType.StartState:
                    StateScripts[0].SetActive(true);
                    StateScripts[1].SetActive(false);
                    StateScripts[2].SetActive(false);
                    StateScripts[3].SetActive(false);
                    break;
                case StateType.GameState:
                    StateScripts[0].SetActive(false);
                    StateScripts[1].SetActive(true);
                    StateScripts[2].SetActive(false);
                    StateScripts[3].SetActive(false);
                    break;
                case StateType.ShootState:
                    StateScripts[0].SetActive(false);
                    StateScripts[1].SetActive(false);
                    StateScripts[2].SetActive(true);
                    StateScripts[3].SetActive(false);
                    break;
                case StateType.FinalState:
                    StateScripts[0].SetActive(false);
                    StateScripts[1].SetActive(false);
                    StateScripts[2].SetActive(false);
                    StateScripts[3].SetActive(true);
                    break;
            }
        }


        void SliderWrite()
        {
            currentDistance = (_basket.transform.position -
                               PlayersController.GetInstance().gameObject.transform.position);
            _slider.value = startDistance.magnitude - currentDistance.magnitude;
        }
        
    }
}

