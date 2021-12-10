using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsLauncher : MonoBehaviour
{
    public GameObject Stairs;       


    private float timeToLaunch;

    private float levelNumber;

    private bool stairLaunched = false;


    void Update()
    {   
        levelNumber = GameObject.Find("Player").GetComponent<PlayerController>().level;
        timeToLaunch = (1f/levelNumber)-0.001f;

        if(!stairLaunched)
        {
            StartCoroutine("StairLaunch");
            stairLaunched = true;
        }
    }

    public IEnumerator StairLaunch()
    {
        yield return new WaitForSeconds(timeToLaunch);
        
        Instantiate(Stairs, transform.position, transform.rotation);
        
        stairLaunched = false;        
    }
}