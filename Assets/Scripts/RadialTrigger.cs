using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
//Recreate the radial trigger we made on stream
//Try to not look back at the stream, see if you can remember the concepts
//Use OnDrawGizmos to draw a circle representing the radius
//Detect if an object's location is inside or outside the radial trigger
//Draw the gizmo green if inside, red if outside
//The trigger should be able to be placed at any location(ie, not just at 0,0)
public class RadialTrigger : MonoBehaviour
{
    public Vector3 origin;
    public float radius;
    public Transform target;

    public float dist;
    public float dist2;
    public bool isWithin;

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
        //Calculate the distance between origin of the circle to the target
        this.dist = Vector3.Distance(origin, target.position);
        //real math
        this.dist2 = Mathf.Sqrt(
            Mathf.Pow(target.position.x - origin.x, 2f)
            + Mathf.Pow(target.position.z - origin.z, 2f)
        );
        //optimize without sqrt
        this.isWithin = (target.position - origin).sqrMagnitude < (radius * radius);

        if (dist > radius)
        {
            Handles.color = Color.red;
        }
        else
        {
            Handles.color = Color.green;
        }
        Handles.DrawWireDisc(origin, new Vector3(0,1,0), this.radius);
    }
#endif
}