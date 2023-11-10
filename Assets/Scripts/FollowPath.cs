using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    public PathCreator pathC;
    public float speed = 1.27f;
    float distance; 
    
    // Update is called once per frame
    void Update()
    {
        distance += speed * Time.deltaTime;
        transform.position = pathC.path.GetPointAtDistance(distance);
        transform.rotation = pathC.path.GetRotationAtDistance(distance); 

        
    }
}
