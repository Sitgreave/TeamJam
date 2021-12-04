using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementOnRope : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Tow _tow; 
    [SerializeField] private float _climbSpeed;

    
    private void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_inputHandler.Horizontal * 5, 0));

        if (Input.GetAxis("Vertical") > 0 && _tow.RopeJoint.distance > 1.5f)
        {
            MoveUp();
        }

        if (Input.GetAxis("Vertical") < 0 && _tow.RopeJoint.distance < _tow.RopeMaxCastDistance)
        {
            MoveDown();
        }
    }

    private void MoveDown()
    {
       _tow.RopeJoint.distance += Time.deltaTime * _climbSpeed;
    }

    private void MoveUp()
    {
        _tow.RopeJoint.distance -= Time.deltaTime * _climbSpeed;
    }
}
