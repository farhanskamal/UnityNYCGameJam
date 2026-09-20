using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCheck : MonoBehaviour
{
    public bool blockedpath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Barrier"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 0f);
            blockedpath = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Barrier"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 0f);
            blockedpath = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Barrier"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0f, 0f);
            blockedpath = false;
        }
    }
}
