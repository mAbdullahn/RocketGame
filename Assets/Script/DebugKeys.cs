using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.L)) {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex == 0) { sceneIndex++; }
            else { sceneIndex = 0; }

            SceneManager.LoadScene(sceneIndex);

        }
        
    }
}
