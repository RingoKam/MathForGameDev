using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LookAtTrigger2 : MonoBehaviour
{
    [Range(10f, 100f)]
    public float DegreeThreshold = 10f;
    private float toObjectRad;
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        //Draw Forward

        //Draw a Cone to Visualize 
        //var lines = 100;
        //var tau = Mathf.PI * 2;
        //for (int i = 0; i < lines; i++)
        //{
        //    var rad = i / (float) lines * tau;
        //    var x = Mathf.Cos(rad);
        //    var y = Mathf.Sin(rad);
        //    this.DrawLine(new Vector3(x, y, 0) + this.transform.position);
        //}

        //Wire Arc
        var center = this.transform.localPosition;
        var transformRight = this.transform.right;
        Handles.DrawLine(this.transform.position, this.transform.position + this.transform.right);
        var playerToTriggerDirection = (this.transform.localPosition + transformRight - center).normalized;
        Handles.DrawWireArc(center, Vector3.forward, playerToTriggerDirection, this.DegreeThreshold, 1f);
        Handles.DrawWireArc(center, Vector3.forward, playerToTriggerDirection, -this.DegreeThreshold, 1f);
        //Solid Arc
        //Handles.DrawSolidArc(center, Vector3.forward, playerToTriggerDirection, this.DegreeThreshold, 1f);
        //Handles.DrawSolidArc(center, Vector3.forward, playerToTriggerDirection, -this.DegreeThreshold, 1f);

        this.DrawLine(this.Target.transform.position);
    }
#endif

    void DrawLine(Vector3 targetPos)
    {
        var center = this.transform.position;
        var transformRight = this.transform.right;
        var playerToTriggerDirection = targetPos - center;
        //Get the dot product to see how close is the target object compare to user lookDir
        var dotProduct = Vector2.Dot(transformRight, playerToTriggerDirection.normalized);
        var rad = Mathf.Acos(Mathf.Clamp(dotProduct, -1, 1));
        var thresholdRad = this.DegreeThreshold * Mathf.Deg2Rad;

        if (rad < thresholdRad)
        {
            Handles.color = Color.green;
        }
        else
        {
            Handles.color = Color.red;
        }
        Handles.DrawLine(center, targetPos);
    }



}
