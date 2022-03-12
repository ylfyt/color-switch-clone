using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 circleStartPosition;
    public Vector3 checkPointOffset;
    public Vector3 circleOffset;

    public GameObject circlePrefab;
    public GameObject checkpointPrefab;
    void Start()
    {
        int numOfCircle = Random.Range(4, 15);
        for(int i = 0; i < numOfCircle; i++)
        {
            Instantiate(circlePrefab, circleStartPosition + i * circleOffset,  Quaternion.identity);
            Instantiate(checkpointPrefab, (circleStartPosition + i * circleOffset) + checkPointOffset, Quaternion.identity);
        }   
    }
}
