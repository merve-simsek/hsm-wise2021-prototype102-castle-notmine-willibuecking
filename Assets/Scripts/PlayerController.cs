using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float jumpedHeight = 0f;
    public float jumpSize = 3f;
    public float jumpSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 0.7f);

        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine("Jump");
        }
        
    }

    IEnumerator Jump ()
    {
        bool jumped = false;
        while(jumpedHeight <= jumpSize && !jumped)
        {
           transform.Translate(Vector3.up * jumpSpeed);
           jumpedHeight += jumpSpeed;
           yield return null;
        }
        if (jumpedHeight >= jumpSize)
        {
            jumped = true;
        }
        while(jumped && jumpedHeight > 0)
        {
            transform.Translate(Vector3.up * -jumpSpeed);
           jumpedHeight -= jumpSpeed;
           yield return null;
        }

    }


}
