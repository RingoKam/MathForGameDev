using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovThingy : MonoBehaviour
{
    public Transform Target;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = this.GetComponent<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (Target == null) return;
        this.camera = this.GetComponent<Camera>();

        var relativePos = this.Target.position - this.camera.transform.position;
        var o = relativePos.y;
        var a = relativePos.x;
        var rad = Mathf.Atan(o / a);
        var fov = Mathf.Abs(rad * Mathf.Rad2Deg * 2);
        this.camera.fieldOfView = Mathf.Clamp(fov, 30, 100);

    }
#endif

}
