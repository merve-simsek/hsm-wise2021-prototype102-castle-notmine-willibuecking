using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsLauncher : MonoBehaviour
{
    public GameObject Stairs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchStairs", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void LaunchStairs()
    {
        Instantiate(Stairs, transform.position, Stairs.transform.rotation);
    }
}
