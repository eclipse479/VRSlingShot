using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    //have a boxcollider
    public BoxCollider m_box_collider;

    //have a default score of 0
    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //update the score
            score++;

            transform.position = new Vector3(0, 0, 0);

            //teleport the target
            transform.position = new Vector3(Random.Range(-20, 20), Random.Range(2, 20), Random.Range(-20, 20));

        }
    }
}
