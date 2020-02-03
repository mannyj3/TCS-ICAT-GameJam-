using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    public float speed;
    public Vector3 CenterPoint;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(CenterPoint, new Vector3(0,0,1), speed* Time.deltaTime);
    }
}
