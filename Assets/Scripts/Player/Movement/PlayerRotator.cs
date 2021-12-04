using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    Vector3 pos;
   public Camera main;
    public Transform myTransform;


    void Update()
    {
        pos = main.WorldToScreenPoint(transform.position);
        WatchToPointer();
       
    }

    private void WatchToPointer()
    {
       
        if (Input.mousePosition.x < pos.x)
        {
            myTransform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.mousePosition.x > pos.x)
        {
            myTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
