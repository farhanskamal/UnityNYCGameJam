using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    // Line 8 and 9 create variables that we will manipulate to change text
    public TextMeshProUGUI textC; // Dialogue
    public TextMeshProUGUI NameC; // Name
    public string[] names; // Name 
    public string[] lines; // serialized field of idalogue
    public float textSpeed; // How fast text goes
    public GameObject yes;
    public GameObject panel;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textC.text = string.Empty; // set dialogue lines empty
        NameC.text = string.Empty; // set name empty
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //|| Input.GetKeyDown("E")
            if (textC.text == lines[index]) // If the text content is the same as whats listed
            {
                NextPart(); // Move to the next part function plays
            }
            else // If not
            {
                StopAllCoroutines(); // Pause typing
                textC.text = lines[index]; // check if its the same text
            }
        }
    }

    public void StartTalking() // When function starts talking
    {
        yes.SetActive(true);
        index = 0; // start at determine first line
        StartCoroutine(TypeLine()); // start moving up 1
    }

    IEnumerator TypeLine() // In this system
    {
        foreach (char c in names[index].ToCharArray())
        {
            NameC.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        foreach (char c in lines[index].ToCharArray()) // we check each letter in the dialogue for it
        {
            textC.text += c; // We add each character in
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextPart()
    {
        if(index < lines.Length - 1 && index < names.Length -1)
        {
            index++;
            textC.text = string.Empty;
            NameC.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            yes.SetActive(false);
        }
    }
}
