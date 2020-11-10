using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BouncingLaser : MonoBehaviour
{
    [SerializeField]
    private int BounceCount = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        ShootRayCast(this.transform.position, this.transform.forward, this.BounceCount);
    }
#endif

    void ShootRayCast(Vector3 start, Vector3 direction, int count)
    {
        if (Physics.Raycast(start, direction, out RaycastHit obj) && count != 0)
        {
   

            var pt = obj.point;
            var normal = obj.normal;
            var projectionOnNormal = start - Vector3.Dot(direction, normal) * 2 * normal ;

            Handles.color = Color.green;
            Handles.DrawLine(start, pt);

            //Draw
            count -= 1;
            this.ShootRayCast(pt, projectionOnNormal.normalized, count);
        }
        else
        {
            //Draw
            Handles.color = Color.red;
            Handles.DrawLine(start, start + direction);
        }
    }
}
