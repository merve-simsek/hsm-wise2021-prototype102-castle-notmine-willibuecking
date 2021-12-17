using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public ParticleSystem dust;
    public int levelPercentage;
    public float level = 4;

    private int remainingJumps = 2;

    private float jumpForce = 350;     //define how strong the jump should be, e.g. how high the player flies

    public RestartScene scenerestarter;
    private AudioManager _audioManager;

    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();

        levelPercentage = 0;
    }


    void Update()
    {


        /* if(Input.GetKey(KeyCode.Space))
        {
            jumpForce += 0.2f;
        } */
        if(Input.GetKeyDown(KeyCode.Mouse0) && remainingJumps > 0)       //make rigidbody jump when space-button is pressed but only 2 consecutive times
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(15, jumpForce, 0), ForceMode.Impulse);
            remainingJumps -= 1;
            levelPercentage += 1;            //count number of jumps so far
            jumpForce -= 5;                 //slows the player down over time by decreasing the jump height (hopefully, should be tested)
            Debug.Log(levelPercentage);
            dust.Play();
        }


        if(levelPercentage >= level*10)      //increase speed of everything if certain number of jumps is reached
        {
            level += 1;         
            levelPercentage = 0;
        }

        if (transform.position.y <= -8)        //restart scene if player falls down
        {
            _audioManager.GameOverSound();
            scenerestarter.Restart();
        }

        
    }    

    private void OnCollisionEnter(Collision collision)     //reset number of jumps possible if player hits floor again
    {
        remainingJumps = 2;
    }

    public void OnCollisionEnter(Collider other)     //destroy rock if it hits a set of stairs
    {
        if (other.tag == "Rock")       //destroy rock if it hits a stair or falls out of bounds
        {
            // Destroy(gameObject);
            _audioManager.GameOverSound();
            scenerestarter.Restart();
        }
    }
    void CreateDust()
    {
        dust.Play();
    }

}
