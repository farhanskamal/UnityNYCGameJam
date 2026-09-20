using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneI : MonoBehaviour
{
    private CutsceneH CutsceneH;
    private GameObject SM;
    private GameObject yap;

    public void Start() 
    {
        CutsceneH = GetComponent<CutsceneH>();
        SM = GameObject.Find("StoryM");
        yap = GameObject.Find("Canvas");
        if (SM.GetComponent<StoryM>().firstTime == true) 
        {
            CutsceneH.PlayNextElement();
            yap.GetComponent<Dialogue>().StartTalking(); // start the talking function
        }
        else 
        {
            Debug.Log("SAD");
        }
    }
}
