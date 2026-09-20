using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundScript : MonoBehaviour
{
    private float minX = -5.2f;
    private float maxX = 5.2f;
    private float minY = -1.5f;
    private float maxY = 3.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float newY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        
        // 2. Stop it from going past minX or maxX
        newX = Mathf.Clamp(newX, minX, maxX);
        newY = Mathf.Clamp(newY, minY, maxY);

        Vector3 camerapos = GameObject.Find("Main Camera").transform.position;
        Vector3 mousepos = Input.mousePosition;
        float speed = .1f;
        transform.position = new Vector3(Mathf.Lerp(camerapos.x, newX, speed), Mathf.Lerp(camerapos.y, newY, speed), transform.position.z);
    }
}
