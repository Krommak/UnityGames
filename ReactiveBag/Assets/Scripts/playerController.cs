using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody leftRigidBody;
    public Rigidbody rightRigidBody;

    public Camera mainCamera;

    public GameObject Player;
    public float speed = 10f;

    public GameObject gameOverPanel;

    public GameObject builder;
   
    private float mainCameraPos = 6f;
    public float rotationMult = 0.8f;

    private bool toTopAndLeft = false;
    private bool toTopAndRight = false;

    private bool isStarted = false;
    
    public GameObject start;
    
    private Rigidbody playerRB;
    void Start()
    {
        playerRB = Player.GetComponent<Rigidbody>();
    }
    void Update()
    {
        mainCameraPos = Player.transform.position.y + 6.65f;

        Vector3 minForce = Vector3.up * speed * rotationMult;
        Vector3 maxForce = Vector3.up * speed;
        
        Vector3 leftForce = Vector3.zero;
        Vector3 rightForce = Vector3.zero;
        
        mainCamera.transform.position = new Vector3(-2.5f, mainCameraPos, -20);

        if(toTopAndLeft)
        {
            rightRigidBody.AddRelativeForce(Vector3.up * speed);
            leftRigidBody.AddRelativeForce(Vector3.up * speed * rotationMult);

            leftForce = minForce;
            rightForce = maxForce;
        } 
        if (toTopAndRight)
        {
            rightRigidBody.AddRelativeForce(Vector3.up * speed * rotationMult);
            leftRigidBody.AddRelativeForce(Vector3.up * speed);

            leftForce = maxForce;
            rightForce = minForce;
        }
        if (toTopAndLeft && toTopAndRight)
        {
            leftRigidBody.AddRelativeForce(Vector3.up * speed);
            rightRigidBody.AddRelativeForce(Vector3.up * speed);

            leftForce = maxForce;
            rightForce = maxForce;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            toTopAndLeft = true;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            toTopAndLeft = false;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            toTopAndRight = true;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            toTopAndRight = false;
        }
        
    }
    private void OnTriggerEnter(Collider obj)
    {
        if(obj.CompareTag("GenerateDot"))
        {
            builder.GetComponent<worldBuilder>().CreateSection();

            Destroy(obj.gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "warning")
        {
            gameOverPanel.SetActive(true);
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    public void toLeft()
    {
        toTopAndLeft = true;
    }
    public void toRight()
    {
        toTopAndRight = true;
    }
    public void toLeftStop()
    {
        toTopAndLeft = false;
    }
    public void toRightStop()
    {
        toTopAndRight = false;
    }

    public void gameStart()
    {
        if(isStarted == false)
        {
            start.transform.tag ="warning";
        }
    }

}
