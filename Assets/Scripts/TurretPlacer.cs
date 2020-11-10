using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TurretPlacer : MonoBehaviour
{
    private Vector3[] corners = new Vector3[]{
 	// bottom 4 positions:
	new Vector3( 1, 0, 1 ),
    new Vector3( -1, 0, 1 ),
    new Vector3( -1, 0, -1 ),
    new Vector3( 1, 0, -1 ),
	// top 4 positions:
	new Vector3( 1, 2, 1 ),
    new Vector3( -1, 2, 1 ),
    new Vector3( -1, 2, -1 ),
    new Vector3( 1, 2, -1 )
};



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
        if (Physics.Raycast(this.transform.position, this.transform.forward, out RaycastHit hit))
        {
            void DrawRay(Vector3 p, Vector3 dir) => Gizmos.DrawLine(p, p + dir);

            //Draw XYZ
            var pt = hit.point;
            var up = hit.normal;
            var right = Vector3.Cross(up, this.transform.forward).normalized;
            var forward = Vector3.Cross(right, up);

            //Draw Bounding Box
            //we can create localSpace position by creating a matrix
            var turrentRotation = Quaternion.LookRotation(forward, up);
            var turrentToWorldMatrix = Matrix4x4.TRS(pt, turrentRotation, Vector3.one);

            //this.corners.ToList().ForEach(corner => {
            //    var worldPt = turrentToWorldMatrix.MultiplyPoint3x4(corner);
            //    Gizmos.DrawSphere(worldPt, 0.075f);
            //});

            //to optimize above, we can use helper function offer by unity to help
            Gizmos.matrix = turrentToWorldMatrix;
            this.corners.ToList().ForEach(corner => {
                Gizmos.DrawSphere(corner, 0.075f);
            });

            Gizmos.color = Color.green;
            DrawRay(Vector3.zero, Vector3.up);
            Gizmos.color = Color.red;
            DrawRay(Vector3.zero, Vector3.right);
            Gizmos.color = Color.blue;
            DrawRay(Vector3.zero, Vector3.forward);
        }

    }
#endif

    private void DrawXYZ(RaycastHit hit)
    {
       
        

     

    }
   
}
