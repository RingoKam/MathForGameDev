using System.Collections;
using System.Collections.Generic;
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
    public Transform localObj;
    public Transform WorldObj;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            //From local to world. get the origin of local and then see the world space in that. 
        }   
    }

}
