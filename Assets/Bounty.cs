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

    public bool facialhair;
    public bool upperwares;
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
        if(gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().mouth.GetComponent<SpriteRenderer>().sprite.name == "BushyStache" || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().mouth.GetComponent<SpriteRenderer>().sprite.name == "TinyStache" || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().mouth.GetComponent<SpriteRenderer>().sprite.name == "Beard")
        {
            facialhair = true;
        }
        else
        {
            facialhair = false;
        }
        if(gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().shirt.GetComponent<SpriteRenderer>().sprite.name == "PuffyJacket" || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().shirt.GetComponent<SpriteRenderer>().sprite.name == "Shirt")
        {
            upperwares = true;
        }
        else
        {
            upperwares = false;
        }
    }
    void SetBounty()
    {
        int randomnum = Random.Range(0, descriptor.Count);
        if(randomnum == 0)
        {
            if(upperwares)
            {
                print(descriptions[randomnum] + "either a shirt or jacket...");
            }
            else
            {
                print(descriptions[randomnum] + "nothing on the upper body... weirdo");
            }
        }
        else if(randomnum == 1)
        {
            print(descriptions[randomnum] + " " + gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().accessory.GetComponent<SpriteRenderer>().sprite.name);
        }
        else if(randomnum == 2)
        {

        }
        else if(randomnum == 3)
        {

        }
        else if(randomnum == 4)
        {

        }
        /*“Your target is wearing, uhh, a [color variable] [clothing variable].”
        “I think they have a [accessory variable].”
        “Your target has [hair length variable] hair.”
        “Your target’s hair is… [hair color variable], I believe.”
        “They have [facial hair variable].”
        “Your target is probably [walking or standing variable].”
        */
    }
    void descriptionStrings()
    {
        
    }
}
