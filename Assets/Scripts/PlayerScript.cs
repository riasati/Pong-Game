using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float upScreenEdge;
    public float downScreenEdge;

    public GameObject opponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float verticalMove = Input.GetAxis("Vertical");
        transform.Translate(transform.up * verticalMove * Time.deltaTime * speed);
        if (transform.position.y < downScreenEdge)
        {
            transform.position = new Vector3(transform.position.x, downScreenEdge, 0);
        }
        if (transform.position.y > upScreenEdge)
        {
            transform.position = new Vector3(transform.position.x, upScreenEdge, 0);
        }
        opponent.GetComponent<OpponentScript>().Movement(verticalMove,speed,upScreenEdge,downScreenEdge);
    }
}
