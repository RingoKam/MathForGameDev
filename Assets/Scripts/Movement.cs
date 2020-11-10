using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 StartOffset;
    public Vector3 EndOffset;
    public float speed;

    private Vector3 origin;
    private Vector3 direction;
    private Vector3 start, end;


    private void Start()
    {
        this.origin = this.transform.position;
        this.start = this.transform.position + StartOffset;
        this.end = this.transform.position + EndOffset;
        this.direction = start;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClose(this.transform.position, start))
        {
            this.direction = end;
        }
        else if (IsClose(this.transform.position, end))
        {
            this.direction = start;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.direction, speed);
    }

    bool IsClose(Vector3 pt, Vector3 pt2)
    {
        return Vector3.Distance(pt, pt2) < 0.1f;
    }


}
