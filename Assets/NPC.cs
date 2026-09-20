using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCAssetHolder NPCAssets;

    public GameObject mouth;
    public GameObject shirt;
    public GameObject pants;
    public GameObject hat;
    public GameObject accessory;

    public GameObject mark;
    public bool isMarked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMarked)
        {
            mark.SetActive(true);
        }
        else
        {
            mark.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            RandomizeOutfit();
        }
    }
    void RandomizeOutfit()
    {
        mouth.GetComponent<SpriteRenderer>().sprite = NPCAssets.mouth[Random.Range(0, NPCAssets.mouth.Count)];
        shirt.GetComponent<SpriteRenderer>().sprite = NPCAssets.shirt[Random.Range(0, NPCAssets.shirt.Count)];
        pants.GetComponent<SpriteRenderer>().sprite = NPCAssets.pants[Random.Range(0, NPCAssets.pants.Count)];
        hat.GetComponent<SpriteRenderer>().sprite = NPCAssets.hat[Random.Range(0, NPCAssets.hat.Count)];
        accessory.GetComponent<SpriteRenderer>().sprite = NPCAssets.accessory[Random.Range(0, NPCAssets.accessory.Count)];

    }
}
