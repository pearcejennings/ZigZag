using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody RB;
    bool hasBeenTouched;
    Transform ballTransform;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        if (hasBeenTouched && RB.isKinematic)
        {
            if (Vector3.Distance(transform.position, ballTransform.position) > 2f)
            {
                RB.isKinematic = false;
            }
        }
        if (transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            ballTransform = collision.transform;
            if (!hasBeenTouched)
            {
                PlatformGenerator.instance.NextPlatform();
                hasBeenTouched = true;
            }
        }
    }



}
