using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairFollowmouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;

        mousepos.z = 10f;
        transform.position = Camera.main.ScreenToWorldPoint(mousepos);
    }
}
