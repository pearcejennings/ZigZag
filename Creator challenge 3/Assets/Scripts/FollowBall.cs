using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    Transform target;
    Vector3 startingDistance;
   
    void Start()
    {
        target = BallController.instance.transform;
        startingDistance = transform.position - target.position;
    }
  
    void Update()
    {
        followBall();
    }

    void followBall()
    {
        transform.position = new Vector3(target.position.x + startingDistance.x, startingDistance.y, target.position.z + startingDistance.z);
    }
}
