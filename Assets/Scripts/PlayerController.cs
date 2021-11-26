using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int levelPercentage = 0;
    public float level = 2;

    private int remainingJumps = 2;

    private float jumpForce = 300;     //define how strong the jump should be, e.g. how high the player flies
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        /* if(Input.GetKey(KeyCode.Space))
        {
            jumpForce += 0.2f;
        } */
        if(Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0)       //make rigidbody jump when space-button is pressed but only 2 consecutive times
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(15, jumpForce, 0), ForceMode.Impulse);
            remainingJumps -= 1;
            levelPercentage += 1;            //count number of jumps so far
           // Debug.Log(levelPercentage);
        }


        if(levelPercentage >= level*10)      //increase speed of everything if certain number of jumps is reached
        {
            level += 1;         
            levelPercentage = 0;
          //Debug.Log(level);
        }

        
    }    

    private void OnCollisionEnter(Collision collision)     //reset number of jumps possible if player hits floor again
    {
        remainingJumps = 2;
    }

}
