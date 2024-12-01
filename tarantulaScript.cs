using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tarantulaScript : MonoBehaviour
{

    public Animator animControl;
    public AnimationState swingAnimation;
    public GameObject pivotCameraLookAt, cameraPos, meshChild;
    public Camera cam;
    public Rigidbody rb;
    public AudioSource spiderSwing;
    public AudioClip sw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, cameraPos.transform.position.z);
        cam.transform.LookAt(pivotCameraLookAt.transform.position);
        pivotCameraLookAt.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.W))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            animControl.SetBool("isRunning", true);
            transform.Translate(transform.forward * 3 * Time.deltaTime);

            //diagonal movement
            if (Input.GetKey(KeyCode.D))
            {
                animControl.SetBool("isRunning", true);
                transform.localRotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);                
                transform.Translate(transform.forward * 3 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                animControl.SetBool("isRunning", true);
                transform.localRotation = Quaternion.Euler(0.0f, -45.0f, 0.0f);
                transform.Translate(transform.forward * 3 * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animControl.SetBool("isRunning", true);
            transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            transform.Translate(transform.forward * -3 * Time.deltaTime);

            //diagonal movement
            if (Input.GetKey(KeyCode.D))
            {
                animControl.SetBool("isRunning", true);
                transform.localRotation = Quaternion.Euler(0.0f, 120.0f, 0.0f);
                transform.Translate(transform.forward * -3 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                animControl.SetBool("isRunning", true);
                transform.localRotation = Quaternion.Euler(0.0f, -120.0f, 0.0f);
                transform.Translate(transform.forward * -3 * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animControl.SetBool("isRunning", true);
            transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            transform.Translate(transform.right * 3 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animControl.SetBool("isRunning", true);
            transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            transform.Translate(transform.right * -3 * Time.deltaTime);
        }
        else
        {
            animControl.SetBool("isRunning", false);
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            animControl.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * 500);
        }

        if(Input.GetMouseButtonDown(0))
        {
            animControl.SetBool("isSwinging", true);
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            spiderSwing.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "floor")
        {
            animControl.SetBool("isJumping", false);
        }
    }
}
