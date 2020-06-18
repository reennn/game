using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCrystall : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
    {
        Destroy(gameObject);
        CrystallCounter.crystallAmount += 1;
    }
}
