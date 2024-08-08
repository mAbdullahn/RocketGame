using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotations : MonoBehaviour
{
    // Start is called before the first frame update
    Transform tr;
    void Start()
    {
        tr=GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        tr.transform.Rotate(0,0,0.1f);
        
    }
}
