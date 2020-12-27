using Managers;
using UnityEngine;

namespace GamePlay
{
    public class BallController : MonoBehaviour
    {
        #region Variables
        [SerializeField]private Rigidbody _ballRigid;
        [SerializeField] private GameObject _player1HoldPoint;
        [SerializeField] private GameObject _player2HoldPoint;
        [SerializeField] [Range(0, 1000)] private float _magnitude;
        [SerializeField] private GameObject _goalPoint;

        [HideInInspector] public bool isThrow;
        [HideInInspector] public Direction throwDirection;
        #endregion

        void Start()
        {
            throwDirection = Direction.Left;
        }

        void Update()
        {
            if ((GameManager.GetInstance().currentState == StateType.GameState) && isThrow)
            {
                if (throwDirection == Direction.Right)
                {
                    ThrowBall(CalculateTrajectory(_player2HoldPoint));
                    isThrow = false;
                }
                else if (throwDirection == Direction.Left)
                {
                    ThrowBall(CalculateTrajectory(_player1HoldPoint));
                    isThrow = false;
                }
            }
        }

        private void ThrowBall(Vector3 Trajectory)
        {
            _ballRigid.AddForce(Trajectory * _magnitude); //This will change by players speed. (Only Z axis)
        }

        private Vector3 CalculateTrajectory(GameObject gameObject)
        {
            var x = (gameObject.transform.position - transform.position).normalized;
            return x;
        }


        private void OnTriggerEnter(Collider other)
        {
            switch (other.gameObject.tag)
            {
                case "Player 1":
                    _ballRigid.velocity = Vector3.zero;
                    transform.position = _player1HoldPoint.transform.position;
                    break;
                case "Player 2":
                    _ballRigid.velocity = Vector3.zero;
                    transform.position = _player2HoldPoint.transform.position;
                    break;
                case "BasketPoint":
                    _ballRigid.velocity = Vector3.down * 5;
                    transform.position = _goalPoint.transform.position;
                    _ballRigid.gameObject.GetComponent<SphereCollider>().isTrigger = false;
                    _ballRigid.useGravity = true;
                    break;
            }

        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("WinCheck"))
            {
                GameManager.GetInstance().ChangeState(StateType.FinalState);
            }
        }
    }

}

public enum Direction 
{
    Left = -1,
    Right = 1
}
