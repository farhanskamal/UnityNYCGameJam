using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bounty : MonoBehaviour
{
    public List<string> descriptor;

    public List<string> descriptions;
    public List<string> colors;
    public NPCAssetHolder npcAssets;
    public GameObject gameManager;

    public bool facialhair;
    public bool upperwares;
    public int hat;

    public TextMeshProUGUI myTextComponent;
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
        if(gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().mouth.GetComponent<SpriteRenderer>().sprite.name == "BushyStache" 
        || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().mouth.GetComponent<SpriteRenderer>().sprite.name == "TinyStache" 
        || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().mouth.GetComponent<SpriteRenderer>().sprite.name == "Beard")
        {
            facialhair = true;
        }
        else
        {
            facialhair = false;
        }
        if(gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().shirt.GetComponent<SpriteRenderer>().sprite == null)
        {
            upperwares = false;
        }
        else if(gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().shirt.GetComponent<SpriteRenderer>().sprite.name == "PuffyJacket" 
        || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().shirt.GetComponent<SpriteRenderer>().sprite.name == "Shirt")
        {
            upperwares = true;
        }
        if(gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().hat.GetComponent<SpriteRenderer>().sprite == null)
        {
            hat = 4;
        }
        else if(gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().hat.GetComponent<SpriteRenderer>().sprite.name == "Hair1" 
        || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().hat.GetComponent<SpriteRenderer>().sprite.name == "Hair3" 
        || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().hat.GetComponent<SpriteRenderer>().sprite.name == "Hair4")
        {
            hat = 1;
        }
        else if(gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().hat.GetComponent<SpriteRenderer>().sprite.name == "Hair2" 
        || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().hat.GetComponent<SpriteRenderer>().sprite.name == "Hair5" 
        || gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().hat.GetComponent<SpriteRenderer>().sprite.name == "Hair6")
        {
            hat = 2;
        }
        else
        {
            hat = 3;
        }
    }
    void SetBounty()
    {
        int randomnum = Random.Range(0, descriptor.Count);
        if(randomnum == 0)
        {
            if(upperwares)
            {
                myTextComponent.text = (descriptions[randomnum] + "either a shirt or jacket...");
            }
            else
            {
                myTextComponent.text = (descriptions[randomnum] + "nothing on the upper body... weirdo");
            }
        }
        else if(randomnum == 1)
        {
            myTextComponent.text = (descriptions[randomnum] + " " + gameManager.GetComponent<GameManager>().Hunted.GetComponent<NPC>().accessory.GetComponent<SpriteRenderer>().sprite.name);
        }
        else if(randomnum == 2)
        {
            if(hat == 1)
            {
                myTextComponent.text = (descriptions[randomnum] + "short hair");
            }
            if(hat == 2)
            {
                myTextComponent.text = (descriptions[randomnum] + "long hair");
            }
            if(hat == 3)
            {
                myTextComponent.text = (descriptions[randomnum] + "a hat");
            }
            if(hat == 4)
            {
                myTextComponent.text = (descriptions[randomnum] + "no headwear, he may be bald");
            }
        }
        else if(randomnum == 3)
        {
            myTextComponent.text = ("hair color not assigned yet.");
        }
        else if(randomnum == 4)
        {
            if(facialhair)
            {
                myTextComponent.text = (descriptions[randomnum] + "facial hair...");
            }
            else
            {
                myTextComponent.text = (descriptions[randomnum] + "no facial hair.");
            }
        }
        else if(randomnum == 5)
        {
            myTextComponent.text = (descriptions[randomnum] + "moving");
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
