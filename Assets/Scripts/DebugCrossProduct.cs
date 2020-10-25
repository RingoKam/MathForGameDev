using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebugCrossProduct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var headPos = transform.position;
        var lookDir = transform.forward;

        void DrawRay(Vector3 pts, Vector3 dir) => Handles.DrawAAPolyLine(pts, pts + dir);

        if (Physics.Raycast(headPos, transform.forward, out RaycastHit hit))
        {
            Vector3 hitPos = hit.point;
            Vector3 normal = hit.normal;

            Handles.color = Color.green;
            Handles.DrawAAPolyLine(headPos, hitPos);
            Handles.color = Color.cyan;
            DrawRay(hitPos, hit.normal);
        }
        else
        {
            Handles.color = Color.red;
            DrawRay(headPos, lookDir);
        }

    }
#endif
}
