using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _crosshairPosition;
    public Vector2 Position => _crosshairPosition.position;
    public SpriteRenderer CrosshairSprite;
    private Vector3 _aimDirection;
    public Vector3 AimDirection => _aimDirection;

    private void Update()
    {
         
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(
            x: Input.mousePosition.x,
            y: Input.mousePosition.y,
            z: 0
            ));
        Vector3 facingDirection = worldMousePosition - _playerPosition.position;
        
        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }
       
        _aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
        SetCrosshairPosition(aimAngle);

     
    }

    private void SetCrosshairPosition(float aimAngle)
    {
        if (!CrosshairSprite.enabled)
        {
            CrosshairSprite.enabled = true;
        }
        float x = _playerPosition.position.x + 2f * Mathf.Cos(aimAngle);
        float y = _playerPosition.position.y + 2f * Mathf.Sin(aimAngle);

        Vector2 crossHairPosition = new Vector2(x, y);
        _crosshairPosition.position = crossHairPosition;
    }


}