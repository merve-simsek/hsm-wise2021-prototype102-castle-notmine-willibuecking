using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLauncher : MonoBehaviour
{
    public GameObject Rock;
    
    private bool rockLaunched = false;      //flag to check of a rock is already being launched

    private float levelNumber;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        levelNumber = GameObject.Find("Player").GetComponent<PlayerController>().level;
        if(!rockLaunched)
        {
            StartCoroutine("RockTimer");        //start the rocklauncher
            rockLaunched = true;
        }
    }

    public IEnumerator RockTimer()
    {
        float timeToLaunch = Random.Range((1f/levelNumber)*3, (1f/levelNumber)*6);      //wait for a random amount of seconds between values derived from the current level
        yield return new WaitForSeconds(timeToLaunch);
        Instantiate(Rock, transform.position, transform.rotation);      //launch a rock
        rockLaunched = false;                                           //reset rocklaunch-flag
    }
}
