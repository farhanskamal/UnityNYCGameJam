using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> NPCs = new List<GameObject>();

    public GameObject Hunted;

    public GameObject[] spawnlocations;
    public GameObject NPCPref;

    public GameObject camera;
    public GameObject scope;
    public bool scoped;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(NPCs.Count != 20)
        {
            NPCs.Add(Instantiate(NPCPref, spawnlocations[Random.Range(0, spawnlocations.Length)].transform.position, Quaternion.identity));
        }
        if(NPCs.Count == 20 && Hunted == null)
        {
            Hunted = NPCs[Random.Range(0, NPCs.Count)];
        }

        if(Input.GetMouseButtonDown(1) && !scoped)
        {
            camera.GetComponent<Camera>().orthographicSize = 2.5f;
            scoped = true;
            scope.SetActive(true);
            camera.GetComponent<CameraBoundScript>().movement = true;
        }
        else if(Input.GetMouseButtonDown(1) && scoped)
        {
            camera.GetComponent<Camera>().orthographicSize = 5f;
            camera.transform.position = new Vector3(0, 1, -10);
            scoped = false;
            scope.SetActive(false);
            camera.GetComponent<CameraBoundScript>().movement = false;
        }
    }
}
