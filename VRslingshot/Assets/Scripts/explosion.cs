using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public int SecondsToDestroy = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.05F,0.05F, 0.05F);
        Destroy(gameObject, SecondsToDestroy);
    }
}
