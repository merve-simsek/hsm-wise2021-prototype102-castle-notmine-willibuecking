using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsMover : MonoBehaviour
{
    private float levelNumber;
    
    
    void Update()
    {   
        levelNumber = GameObject.Find("Player").GetComponent<PlayerController>().level;
        transform.Translate(Vector3.left * Time.deltaTime * levelNumber);     //slowly push the stairs sideways (by rotating the object the stairs and stairlaunche are contained in, a motion upwards and to the left is done)

        if(transform.position.x <= -30)     //destroy a set of stairs once it is definitively out of frame
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)     //destroy a set of stairs if it is hit by a falling cannonball
    {
        Destroy(gameObject);
    }
}
