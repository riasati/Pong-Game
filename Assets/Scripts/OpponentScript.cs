using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(float verticalMove,float speed, float upScreenEdge, float downScreenEdge)
    {
        transform.Translate(transform.up * -1 * verticalMove * Time.deltaTime * speed);
        if (transform.position.y < downScreenEdge)
        {
            transform.position = new Vector3(transform.position.x, downScreenEdge, 0);
        }
        if (transform.position.y > upScreenEdge)
        {
            transform.position = new Vector3(transform.position.x, upScreenEdge, 0);
        }
    }
}
