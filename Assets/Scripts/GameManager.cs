using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> NPCs = new List<GameObject>();

    public GameObject[] spawnlocations;
    public GameObject NPCPref;
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
    }
}
