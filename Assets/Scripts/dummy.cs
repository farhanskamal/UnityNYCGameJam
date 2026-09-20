using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : CutsceneEB
{
    public override void Execute() // Override helps take over the Execut function over in CutsceneEB
    {
        //StartCoroutine(WaitAndAdvance());
        Debug.Log("Hi " + name);
    }
}
