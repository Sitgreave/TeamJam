using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Transform _footsPosition;
    [SerializeField] private float _radius;
    private bool _isGround = false;
    public bool IsGround => _isGround;
    private void Update()
    {
        Checking();
    }
    public void Checking()
    {
        _isGround = Physics2D.OverlapCircle(_footsPosition.position, _radius, _groundLayerMask);
    }
}
