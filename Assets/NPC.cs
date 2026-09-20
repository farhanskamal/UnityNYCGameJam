using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public NPCAssetHolder NPCAssets;
    public GameObject gameManager;

    public GameObject mouth;
    public GameObject shirt;
    public GameObject pants;
    public GameObject hat;
    public GameObject accessory;

    public Animator animator;

    public GameObject mark;
    public bool isMarked = false;

    public bool hoveringover;

    public GameObject[] hitboxes;

    public bool ismoving;
    public float timer;
    public float randomtime;
    public int directionmovingto;

    public List<GameObject> availablemovements = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        NPCAssets = GameObject.Find("NPCAssetsHolder").GetComponent<NPCAssetHolder>();
        RandomizeOutfit();
    }


    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= randomtime)
        {
            foreach(GameObject barrier in hitboxes)
            {
                if(barrier.GetComponent<HitBoxCheck>().blockedpath == false)
                {
                    availablemovements.Add(barrier);
                }
            }
            directionmovingto = Random.Range(0, availablemovements.Count);
            StartCoroutine(movement());
            timer = 0;
            randomtime = Random.Range(1f, 1.8f);
        }
        if(ismoving)
        {
            if(availablemovements[directionmovingto].GetComponent<HitBoxCheck>().blockedpath)
            {
                ismoving = false;
                animator.SetBool("Idle", true);
                availablemovements = new List<GameObject>();
            }
            else
            {
                Transform locationtomove;
                locationtomove = availablemovements[directionmovingto].transform;

                Vector3 direction = (locationtomove.position - transform.position).normalized;

                transform.Translate(direction * 2.2f * Time.deltaTime, Space.World);
                animator.SetBool("Idle", false);
            }
        }
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

        if(Input.GetKeyDown(KeyCode.M) && hoveringover && !isMarked)
        {
            isMarked = true;
        }
        else if(Input.GetKeyDown(KeyCode.M) && hoveringover && isMarked)
        {
            isMarked = false;
        }
        if(Input.GetMouseButtonDown(0) && hoveringover && gameManager.GetComponent<GameManager>().scoped)
        {
            if(this.gameObject == gameManager.GetComponent<GameManager>().Hunted)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
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
    IEnumerator movement()
    {
        ismoving = true;
        animator.SetBool("Idle", false);
        yield return new WaitForSeconds(Random.Range(.33f, 1f));
        ismoving = false;
        animator.SetBool("Idle", true);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoveringover = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hoveringover = false;
    }
}
