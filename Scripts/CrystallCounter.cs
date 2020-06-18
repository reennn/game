using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystallCounter : MonoBehaviour
{

    public static int crystallAmount;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        crystallAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "X " + crystallAmount;
    }
}
