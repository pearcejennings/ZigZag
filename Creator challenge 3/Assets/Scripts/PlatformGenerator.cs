using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform currentPlatform;
    [SerializeField] int startingPlatformCount;

    int nextPlatformDirection;

    public static PlatformGenerator instance;

    private void OnEnable()
    {
        instance = this;
    }

  
    void Start()
    {
        GenerateStartingPlatforms();
    }

    void GenerateStartingPlatforms()
    {
        for (int i = 0; i < startingPlatformCount; i++)
        {
            nextPlatformDirection = Random.Range(0, 2);
            if (nextPlatformDirection == 0)
            {
                currentPlatform = Instantiate(platformPrefab, currentPlatform.position + Vector3.right * 2, Quaternion.identity).transform;
            }
            else
            {
                currentPlatform = Instantiate(platformPrefab, currentPlatform.position + Vector3.forward * 2, Quaternion.identity).transform;
            }
        }
    }


    public void NextPlatform()
    {
        nextPlatformDirection = Random.Range(0, 2);
        if (nextPlatformDirection == 0)
        {
            currentPlatform = Instantiate(platformPrefab, currentPlatform.position + Vector3.right * 2, Quaternion.identity).transform;
        }
        else
        {
            currentPlatform = Instantiate(platformPrefab, currentPlatform.position + Vector3.forward * 2, Quaternion.identity).transform;
        }
    }


}



