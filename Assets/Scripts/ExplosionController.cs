using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy ()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
