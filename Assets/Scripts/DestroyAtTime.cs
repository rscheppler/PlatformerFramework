using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    //time to wait before destroying
    public float DeathTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeathTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
