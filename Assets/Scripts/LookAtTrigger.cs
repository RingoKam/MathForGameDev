using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 

// Make a look-at-trigger
// Detect whether or not an object is looking at the trigger
// Have a threshold range from 0 to 1 where:
// 1 = you have to look exactly toward the trigger to activate it
// 0 = you have to look perpendicular or closer to activate it (facing away counts as outside)
// Draw a line gizmo green if looking closely enough, red if looking too away from it
public class LookAtTrigger : MonoBehaviour
{
    public Transform target;
    public float dotProductResult;
    [Range(0f, 1f)]
    public float Treshold = 0f;

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
        var currentPos = this.transform.position;
        var targetPos = this.target.position;

        dotProductResult = Vector3.Dot(Vector3.forward, Vector3.Normalize(targetPos - currentPos));
        // dotProductResult = currentPos.x * targetPos.x + currentPos.y * targetPos.y + currentPos.z * targetPos.z;  
        if (dotProductResult > this.Treshold)
        {
            Handles.color = Color.green;
        }
        else
        {
            Handles.color = Color.red;
        }
        Handles.DrawLine(this.transform.position, this.target.position);
    }
    #endif
}
