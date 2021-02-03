using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager GameManager;
    public bool toLeft = false;
    public bool toRight = false;

    public Transform cam;

    private float mainCameraPos;

    private WorldBuilder worldBuilder;

    public UI uI;

    public float toLeftRight = 1;

    void Start()
    {
        worldBuilder = GameObject.Find("WorldBuilder").GetComponent<WorldBuilder>();

        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        uI = GameObject.Find("UI").GetComponent<UI>();
    }
    void Update()
    {
        mainCameraPos = transform.position.z;
        if(toLeft && GameManager.isStart)
        {
            transform.Translate(-toLeftRight * Time.deltaTime, 0, 0);
        }
        
        if(toRight && GameManager.isStart)
        {
            transform.Translate(toLeftRight * Time.deltaTime, 0, 0);
        }

        cam.position = new Vector3(0, 1, mainCameraPos -1.5f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Generate")
        {
            worldBuilder.CreateSection();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Danger")
        {
            GetComponent<Animator>().SetTrigger("Death");
            uI.GameOver();
        }
    }
    public void toLeftButton(bool value)
    {
        toLeft = value;
    }

    public void toRightButton(bool value)
    {
        toRight = value;
    }

}
