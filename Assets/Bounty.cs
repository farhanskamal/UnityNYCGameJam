using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounty : MonoBehaviour
{
    public List<string> descriptor;
    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetBounty();
        }
    }
    void SetBounty()
    {
        print("You have one job... take out the one with " + descriptor[Random.Range(0, descriptor.Count)]);
    }
}
