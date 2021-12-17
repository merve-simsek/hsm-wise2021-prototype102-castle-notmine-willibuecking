using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public GameObject explosion;
    private AudioManager _audioManager;

    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnTriggerEnter(Collider other)     //destroy cannonball if it hits a set of stairs
    {
        if (other.tag == "Stairs" || transform.position.y <= -10)       //destroy cannonball if it hits a stair or falls out of bounds
        {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        _audioManager.RockBreaking();
        }
    }
}
