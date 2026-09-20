using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneH : MonoBehaviour
{
    public CutsceneEB[] cutsceneEl;
    private int index = -1; // Current CutScene

    public void Start() 
    {
        cutsceneEl = GetComponents<CutsceneEB>();
    }

    private void ExecuteCurrentScene() 
    {
        if(index >= 0 && index < cutsceneEl.Length) 
        {
            cutsceneEl[index].Execute();
        }
    }

    public void PlayNextElement()
    {
            index++; // Index += 1;
            ExecuteCurrentScene();
    }
}
