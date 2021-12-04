using UnityEngine;

public class WeaponRotator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform myTransform;
    void Update()
    {
        Vector3 diference = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        myTransform.rotation = Quaternion.Euler(0, 0, rotateZ);

        Vector3 localScale = Vector3.one;
       // transform.LookAt(crosshair.Position)

        if(rotateZ > 90 || rotateZ < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }
        myTransform.localScale = localScale;
    }
}
