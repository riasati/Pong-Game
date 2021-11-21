using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class CubeBallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddForce(int roundNumber)
    {
        Random rnd = new Random();
        double min = 100;
        double max = 300;
        double range = max - min;
        double sample = rnd.NextDouble();
        double scaled = (sample * range) + min;
        double sample2 = rnd.NextDouble();
        double scaled2 = (sample * range) + min;
        if (roundNumber % 2 == 0)
        {
            scaled2 = -1 * scaled2;
        }
        Debug.Log("here");
        rb.AddForce(transform.up * (float) scaled + transform.right * (float) scaled2);
    }
}
