using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
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
