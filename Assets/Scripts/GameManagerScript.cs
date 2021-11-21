using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManagerScript : MonoBehaviour
{
    public GameObject cubeBall;

    public bool isNewRound = true;

    public int roundNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cubeBall.transform,new Vector3(this.transform.position.x + 3f,this.transform.position.y,this.transform.position.z),this.transform.rotation);
        cubeBall.gameObject.GetComponent<CubeBallScript>().AddForce(roundNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateNewCubeBall()
    {
        Random rnd = new Random();
        // double min = -3;
        // double max = +3;
        // double range = 3;
        double sample = rnd.NextDouble();
        double scaled = (sample * 3) + -3;
        Instantiate(cubeBall.transform,new Vector3(this.transform.position.x,this.transform.position.y + (float)scaled,this.transform.position.z),this.transform.rotation);
        cubeBall.gameObject.GetComponent<CubeBallScript>().AddForce(roundNumber);
        
    }
}
