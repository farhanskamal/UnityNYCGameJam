using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCAssetHolder NPCAssets;
    public GameObject gameManager;

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
        gameManager = GameObject.Find("GameManager");
        NPCAssets = GameObject.Find("NPCAssetsHolder").GetComponent<NPCAssetHolder>();
        RandomizeOutfit();
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

        //Sets a local variable for what each object is, and compares it later on
        Sprite myMouth = mouth.GetComponent<SpriteRenderer>().sprite;
        Sprite myShirt = shirt.GetComponent<SpriteRenderer>().sprite;
        Sprite myPants = pants.GetComponent<SpriteRenderer>().sprite;
        Sprite myHat = hat.GetComponent<SpriteRenderer>().sprite;
        Sprite myAccessory = accessory.GetComponent<SpriteRenderer>().sprite;

        foreach(GameObject activeNPC in gameManager.GetComponent<GameManager>().NPCs)
        {
            if(activeNPC == this.gameObject) continue; //In a sense, this line checks if the GameObject is equal to this NPC, and skips it to prevent an infinite loop

            NPC other = activeNPC.GetComponent<NPC>(); // grabs the other script from another NPC to check it's traits

            if(other != null)
            {
                //Grabs the local variable from the other ones in the list, and compares it to the original
                Sprite otherMouth = other.mouth.GetComponent<SpriteRenderer>().sprite;
                Sprite otherShirt = other.shirt.GetComponent<SpriteRenderer>().sprite;
                Sprite otherPants = other.pants.GetComponent<SpriteRenderer>().sprite;
                Sprite otherHat = other.hat.GetComponent<SpriteRenderer>().sprite;
                Sprite otherAccessory = other.accessory.GetComponent<SpriteRenderer>().sprite;

                if(myMouth == otherMouth && myShirt == otherShirt && myPants == otherPants && myHat == otherHat && myAccessory == otherAccessory)
                {
                    Debug.Log("Duplicate. Rerolling outfit.");
                    RandomizeOutfit();
                    return;
                }
            }
        }
    }
}
