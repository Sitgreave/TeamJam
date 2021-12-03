using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Tow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ropeHingeAnchorRb;
    [SerializeField] private SpriteRenderer ropeHingeAnchorSprite;
    [SerializeField] private Crosshair _crosshair;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private MoveEvents _moveEvents;

    [SerializeField] private LineRenderer ropeRenderer;
    [SerializeField] private LayerMask ropeLayerMask;
    [SerializeField]  private float ropeMaxCastDistance = 5f;
    public float RopeMaxCastDistance => ropeMaxCastDistance;

    private List<Vector2> ropePositions = new List<Vector2>();
    [SerializeField] private GameObject ropeHingeAnchor;
    [SerializeField] private DistanceJoint2D ropeJoint;
    public DistanceJoint2D RopeJoint => ropeJoint;
    private bool ropeAttached = false;
    private bool distanceSet;




    private void Start()
    {
        ropeJoint.enabled = false;
        ResetRope();
    }

    void Update()
    {
        if (ropeAttached)
        {
            _crosshair.CrosshairSprite.enabled = false;

        }
        else if (Input.GetMouseButton(0))
        {
            ThrowTow(_crosshair.AimDirection);
        }
        if (Input.GetMouseButton(1))
        {
            ResetRope();
        }
        UpdateRopePositions();
    }

    private void ThrowTow(Vector2 aimDirection)
    {
        ropeRenderer.enabled = true;
        var hit = Physics2D.Raycast(playerPosition.position, aimDirection, ropeMaxCastDistance, ropeLayerMask);
        if (!ropeAttached)
        {
            if (hit.collider != null)
            {
                ropeAttached = true;

                if (!ropePositions.Contains(hit.point))
                {
                    transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
                    ropePositions.Add(hit.point);
                    ropeJoint.distance = Vector2.Distance(playerPosition.position, hit.point);
                    ropeJoint.enabled = true;
                    ropeHingeAnchorSprite.enabled = true;
                }
                _moveEvents._onRopeHolded.Invoke();
            }
            else
            {
                ropeRenderer.enabled = false;
                ropeAttached = false;
                ropeJoint.enabled = false;
            }
        }
    } 
    private void ResetRope()
    {
        ropeJoint.enabled = false;
        ropeAttached = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;

        _moveEvents._onRopeDroped.Invoke();
    }

    private void UpdateRopePositions()
    {
        if (!ropeAttached)
        {
            return;
        }

        ropeRenderer.positionCount = ropePositions.Count + 1;

        for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
        {
            if (i != ropeRenderer.positionCount - 1) 
            {
                ropeRenderer.SetPosition(i, ropePositions[i]);
                if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                {
                    var ropePosition = ropePositions[ropePositions.Count - 1];
                        ropeHingeAnchorRb.transform.position = ropePosition;
                       
                }

                else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                {
                    var ropePosition = ropePositions.Last();
                    ropeHingeAnchorRb.transform.position = ropePosition;

                    if (!distanceSet)
                    {
                        ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                        distanceSet = true;
                    }
                }
            }
            else
            {
                ropeRenderer.SetPosition(i, transform.position);
            }
        }
    }

    private void SetRopePosition(Vector2 ropePosition)
    {
        while (true)
        {
            break;
            //if(ropeHingeAnchor.)
            ropeHingeAnchorRb.transform.position = Vector3.Lerp(ropeHingeAnchorRb.transform.position, ropePosition, 3 * Time.deltaTime);
            
        }
    }

}
