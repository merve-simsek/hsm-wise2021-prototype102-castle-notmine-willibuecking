using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 3f;
    public float jumpSize = 3f;
    
    public float walkSpeed = 0.8f;

    private bool isJumping;

    private float timeToJump = 0.3f;

    private Vector3 targetPos;
    private Vector3 jumpPeak;

    private bool jumped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

/*         transform.Translate(Vector3.right * Time.deltaTime * walkSpeed);
        transform.Translate(Vector3.down * Time.deltaTime * walkSpeed); */

        if(Input.GetKeyUp(KeyCode.Space) && !jumped && !isJumping)
        {
            isJumping = true;
            targetPos = transform.position + new Vector3(0, 0, 0);
            jumpPeak = transform.position + new Vector3(0, jumpHeight, 0);
            StartCoroutine("Jump");
        }
        if(jumped)
        {
            StartCoroutine("Land");
            jumped = false;
        }

        
    }



    public IEnumerator Jump()
   {
        var currentPos = transform.position;
        float t = 0f;
        while(t < 1f)
        {
            t += Time.deltaTime / timeToJump;
            transform.position = Vector3.Slerp(currentPos, jumpPeak, t);
            yield return null;
        }
        jumped = true;
   }

    public IEnumerator Land()
    {
        var currentPos = transform.position;
        float t = 0f;
        while(t < 1f)
            {
                t += Time.deltaTime / timeToJump;
                transform.position = Vector3.Slerp(jumpPeak, targetPos, t);
                yield return null;
            }
        isJumping = false;
    }
      

}
