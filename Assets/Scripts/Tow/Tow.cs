using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Tow : MonoBehaviour
{
    [SerializeField] public Rigidbody2D ropeHingeAnchorRb;
    [SerializeField] private SpriteRenderer ropeHingeAnchorSprite;
    [SerializeField] private MoveEvents _moveEvents;

    [SerializeField] private LineRenderer ropeRenderer;
    [SerializeField]  private float ropeMaxCastDistance = 5f;
    public float RopeMaxCastDistance => ropeMaxCastDistance;

    private List<Vector2> ropePositions = new List<Vector2>();
    [SerializeField] public DistanceJoint2D ropeJoint;
    public DistanceJoint2D RopeJoint => ropeJoint;


    private void Start()
    {
        ropeJoint.enabled = false;
       // ResetRope();
    }

   
  

    public void Towing(Vector2 towPosition)
    {
        ropeHingeAnchorRb.position = towPosition;
        ropeJoint.distance = Vector2.Distance(transform.position, towPosition);
        ropeJoint.enabled = true;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, towPosition);
        _moveEvents._onRopeHolded.Invoke();
    } 
    public void ResetRope()
    {
        ropeJoint.enabled = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;
        ropeJoint.enabled = false;
        _moveEvents._onRopeDroped.Invoke();
        
    }

    private void UpdateRopePositions()
    {
       
    }



}
