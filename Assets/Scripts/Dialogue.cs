using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textC;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textC.text = string.Empty;
        StartTalking();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //|| Input.GetKeyDown("E")
            if (textC.text == lines[index])
            {
                NextPart();
            }
            else
            {
                StopAllCoroutines();
                textC.text = lines[index];
            }
        }
    }

    void StartTalking()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textC.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextPart()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textC.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
