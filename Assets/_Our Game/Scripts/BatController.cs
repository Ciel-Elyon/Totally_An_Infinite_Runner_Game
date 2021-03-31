using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public Vector3[] locations;
    public int currentLoc = 0;
    public float speed = 1f;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != locations[currentLoc])
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, locations[currentLoc], step);
        }
        else
        {
            currentLoc++;
            if (currentLoc >= locations.Length) currentLoc = 0;
        }
    }
}
