using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballLauncher : MonoBehaviour
{
   public GameObject Cannonball;
    
    private bool cannonballLaunched = false;      //flag to check of a cannonball is already being launched
    private bool cannonballLaunchedPlayer = false;

    private float levelNumber;

    private float playerX;      //variables for players position on x and z axis
    private float playerZ;


    void Update()
    {
        playerX  = GameObject.Find("Player").transform.position.x + 4;              //find player position to launch cannonball slightly in front of them
        playerZ  = GameObject.Find("Player").transform.position.z;

        levelNumber = GameObject.Find("Player").GetComponent<PlayerController>().level;
        
        if(!cannonballLaunched)
        {
            StartCoroutine("RockTimer");        //start the cannonballlauncher
            cannonballLaunched = true;
        }

        if(!cannonballLaunchedPlayer)
        {
            StartCoroutine("RockTimerPlayer");        //start the cannonballlauncher
            cannonballLaunchedPlayer = true;
        }
    }

    public IEnumerator RockTimer()
    {
        float timeToLaunch = Random.Range((1f/levelNumber)*3, (1f/levelNumber)*6);      //wait for a random amount of seconds between values derived from the current level
        yield return new WaitForSeconds(timeToLaunch);
        Instantiate(Cannonball, transform.position, transform.rotation);      //launch a cannonball
        cannonballLaunched = false;                                           //reset cannonballlaunch-flag
    }
}
