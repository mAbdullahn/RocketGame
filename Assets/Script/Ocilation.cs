using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocilation : MonoBehaviour
{
    float period = 5f;
    Vector3 startingPosition;
    [SerializeField]Vector3 movingVector;
    [SerializeField][Range(0, 1)] float movingFactor; 
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(period> 0)
        {
            float cycle = Time.time / period;
            const float tau = Mathf.PI * 2;
            float rawsign = Mathf.Sin(tau * cycle);
            movingFactor = rawsign;

            Vector3 targetPostion = movingVector * movingFactor;
            transform.position = startingPosition + targetPostion;
        }
        
        
    }
}
