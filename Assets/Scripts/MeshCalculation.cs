using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeshCalculation : MonoBehaviour
{
    public Mesh mesh;
    public int TriangleCount = 0;
    public float surfaceArea = 0;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Vertices Vector3[]
    // Triangles int[], 3 points make up a mesh.
    void Update()
    {
        //reference mesh triangles and vertices are expensive operation, lets cache them by declaring a variable
        var tris = this.mesh.triangles;
        var verts = this.mesh.vertices;

        var area = 0f;
        //loop thru the array of tris
        for (int i = 0; i < tris.Length; i += 3)
        {
            //gather the points needed
            var a = verts[tris[i]];
            var b = verts[tris[i + 1]];
            var c = verts[tris[i + 2]];

            //now we have all 3 points... calculate the cross product of 2 vector
            area += Vector3.Cross(b - a, c - a).magnitude;
        }
        this.surfaceArea = area / 2;
        this.TriangleCount = this.mesh.triangles.Length;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
    }
#endif

}
