using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private float _horizontal;
    public float Horizontal => _horizontal;
    private bool _jumpInputed;
    public bool JumpInputed => _jumpInputed;
    private bool _inputedMouseButton0;
    public bool InputedMouseButton0 => _inputedMouseButton0;

    private bool _inputedMouseButton1;
    public bool InputedMouseButton1 => _inputedMouseButton1;

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        CheckJumpInput();
    }

    private void CheckJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jumpInputed = true;
        }
        else _jumpInputed = false;
    }

    private void MouseInput()
    {
         

    }
}
