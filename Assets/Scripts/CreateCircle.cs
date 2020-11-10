using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCircle : MonoBehaviour
{
    [Range(1,30)]
    public int Dots = 0;
    private const float Tau = Mathf.PI * 2f; //full circle

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
        for (int i = 0; i < Dots; i++)
        {
            var rad =  ((float) i) / Dots * Tau;
            //if we want to convert to degrees...
            var degrees = Mathf.Rad2Deg * rad;
            var x = Mathf.Cos(rad);
            var y = Mathf.Sin(rad);
            Gizmos.DrawSphere(new Vector3(x, y, 0), 0.05f);
        }
    }
#endif
}
