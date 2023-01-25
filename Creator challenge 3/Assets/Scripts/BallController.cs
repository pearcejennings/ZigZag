using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public static BallController instance;
    Rigidbody RB;
    public bool isStarted;
    public float currentSpeed;
    public bool isGoingRight;
    bool isAlive = true;


    private void OnEnable()
    {
        instance = this;
    }

   
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (isStarted && isAlive)
        {
            MoveBall();
        }
    }

    void MoveBall()
    {
        if (isGoingRight)
        {
            RB.velocity = (Vector3.right * currentSpeed) + Physics.gravity;
        }
        else
        {
            RB.velocity = (Vector3.forward * currentSpeed) + Physics.gravity;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathZone")
        {
            isAlive = false;
            RB.velocity = Physics.gravity;
            MenuController.instance.GameOver();
        }
    }

}
