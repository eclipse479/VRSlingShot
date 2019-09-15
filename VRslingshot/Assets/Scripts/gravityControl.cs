using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float grav = 100.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Physics.gravity = new Vector3(0, 0, -75);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Physics.gravity = new Vector3(0, 0, 75);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Physics.gravity = new Vector3(0, 75, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Physics.gravity = new Vector3(0, -75, 0);
        }
    }
}
