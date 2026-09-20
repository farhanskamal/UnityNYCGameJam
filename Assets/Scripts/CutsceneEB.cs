using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEB : MonoBehaviour
{
    public float howlong;
    private CutsceneH CutsceneH;

    public void Start()
    {
        CutsceneH = GetComponent<CutsceneH>();
    }

    public virtual void Execute() // This is a proxy and will load any execute function from a different file
    {
        
    }

    // Coroutine is something that can pause
    // Protected is where a function can ONLY be used WHEN its used by others
    protected IEnumerator WaitAndAdvance() 
    {
        yield return new WaitForSeconds(howlong); 
        CutsceneH.PlayNextElement();
    }
}
