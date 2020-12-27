using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _target;
    [SerializeField]private Vector3 _expectedDistance;
    private Vector3 _currentDistance;
    #endregion
    
    
    void FixedUpdate()
    {
        var desiredPos = _target.transform.position - _expectedDistance;
        desiredPos.y = transform.position.y;
        var pos= Vector3.Lerp(transform.position, desiredPos,0.1f);
        transform.position = pos;
    }

    public void ChangeTarget(GameObject target)
    {
        _target = target;
    }
}
