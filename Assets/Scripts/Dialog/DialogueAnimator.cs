using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    public void OntriggerEnter2D(Collider2D other)
    {
        startAnim.SetInteger("STARTopen", 1);
    }

    public void OntriggerExit2D(Collider2D other)
    {
        startAnim.SetInteger("STARTopen", 0);
        dm.EndDialogue();
    }
}
