using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public Vector2 input;
    public float speed = 50.0f;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody rg;
    public float motionSmoothing;
    public float fallAceleration;
    public float jumpImpulse;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveInput();
    }

    public void MoveInput(){
        float inputX = Input.GetAxis("Horizontal") * speed;
        float inputY = Input.GetAxis("Vertical") * speed;
        //float inputZ = Input.GetAxis("Vertical") * speed;

        //rg.velocity = Vector3.SmoothDamp(rg.velocity, new Vector2(inputX, -fallAceleration), ref velocity, motionSmoothing);
        transform.Translate(inputX * Time.deltaTime, inputY * Time.deltaTime, 0f);
        /*if(Input.GetButton("Jump") && !isJumping){
            Debug.Log("Salto");
            //transform.Translate(0f, Input.GetAxis("Jump") * Time.deltaTime * jumpImpulse, 0f);
            //rg.AddForce(Vector2.up * Input.GetAxis("Jump") * jumpImpulse, ForceMode.Impulse);
            isJumping = true;
        }*/
    }

    private void OnCollisionEnter(Collision other){
    if (other.gameObject.CompareTag("Floor")){
        isJumping = false;
        Debug.Log("Nosalto");
        rg.velocity = new Vector2(rg.velocity.x, 0);
        }
    }
}