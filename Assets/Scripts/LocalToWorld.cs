using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/* 
Make a function that can transform:
	A) a world space point to a local space point
	B) a local space point to a world space point
	...taking rotation of the object into account
2D only
You can ignore scale if you want
You are not allowed to use:
transform.TransformPoint
transform.TransformVector
transform.TransformDirection
Quaternions
You are allowed to use
transform.right
transform.up
transform.forward
You need to do this manually, using the dot product and vector math!
*/
public class LocalToWorld : MonoBehaviour
{
    public Vector3 localObj;
    public Vector3 WorldObj;

    public Transform LocalToWorldPoint;

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
        var objpos = transform.position;
        var up =  transform.forward;
        var right = transform.right;

        DrawXZGizmos(objpos, up, right);
        DrawXZGizmos(Vector3.zero, Vector3.forward, Vector3.right);

        //var worldPos = TransformLocalToWorld(this.localObj);
        //Gizmos.DrawSphere(worldPos, 0.1f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.WorldObj, 0.1f);
        var localPos = TransformWorldToLocal(this.WorldObj);
        this.LocalToWorldPoint.localPosition = localPos;
    }
    #endif

    //take in a world position and transform it to a local position
    //1. Get the relative offset between the world position and the local space origin in world space
    //2. With the difference between those 2 point, we can use it to realign it with the normal of the LOCAL Axis
    //3. We use the DotProduct to project the difference to the local object space x,z axis  
    //4. Returned result is the localPosition Vector
    Vector3 TransformWorldToLocal(Vector3 worldPosition) {
        var relativeOffset = worldPosition - this.transform.position;
        var z = Vector3.Dot(relativeOffset, this.transform.forward);
        var x = Vector3.Dot(relativeOffset, this.transform.right);
        return new Vector3(x, 0, z);
    }

    //take in a local position and transform it to a world position
    //1. Get the forward and right of the object space, multiple/scale it by the local space length
    Vector3 TransformLocalToWorld(Vector3 localPosition) {
        var z = transform.forward * localPosition.z;
        var x = transform.right * localPosition.x;
        return z + x + transform.position;
    }

    private void DrawXZGizmos(Vector3 point, Vector3 up, Vector3 right)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(point, up);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(point, right);
        Gizmos.color = Color.white;
    }
}
