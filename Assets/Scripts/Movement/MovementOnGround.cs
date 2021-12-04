using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementOnGround : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _runSpeed;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private InputHandler _inputHandler;

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(
            x: _inputHandler.Horizontal * _runSpeed,
            y: _rb.velocity.y
            );
        if (Input.GetButton("Jump") && _groundChecker.IsGround)
        {
            _rb.AddForce(new Vector2(0, _jumpForce));
            Invoke(nameof(FastGrounded), 1f);
        }
    }

    private void FastGrounded()
    {
        _rb.AddForce(new Vector2(0, -_jumpForce / 1.5f));
    }
}
