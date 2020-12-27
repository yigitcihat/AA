using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] GamePlay.BallController ballController;

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !ballController.isThrow)
            {
                if (ballController.throwDirection == Direction.Left)
                    ballController.throwDirection = Direction.Right;
                else
                    ballController.throwDirection = Direction.Left;
                ballController.isThrow = true;
            }
        }
    }

}
