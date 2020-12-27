using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace GamePlay
{
    public class PlayersController : MonoBehaviour
    {
        #region Singleton

        private static PlayersController _instance;

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

        public static PlayersController GetInstance()
        {
            return _instance;
        }

        #endregion

        public bool isGameState;
        public float speed;

        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "ShootStateCollider")
            {
                GameManager.GetInstance().ChangeState(StateType.ShootState);
            }
        }
    }
}

