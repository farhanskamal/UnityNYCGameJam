using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAtEnd : MonoBehaviour
{
    public GameObject dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue.GetComponent<Dialogue>().index == dialogue.GetComponent<Dialogue>().lines.Length-1)
        {
            gameObject.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, .1f);
        }
    }
}
