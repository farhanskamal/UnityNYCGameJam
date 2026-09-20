using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounty : MonoBehaviour
{
    public List<string> descriptor;

    public List<string> descriptions;
    public List<string> colors;
    public NPCAssetHolder npcAssets;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager");
        
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
        int randomnum = Random.Range(0, descriptor.Count);
        print("You have one job... take out the one with " + descriptor[randomnum]);
    }
    void descriptionStrings()
    {
        
    }
}
