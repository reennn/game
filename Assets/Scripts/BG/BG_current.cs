using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_current : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var height = Camera.main.orthographicSize * 2.3f;//настройка объекта по у
        var width = height * Screen.width / Screen.height;//настройка объекта по х

        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector3(width, height, 0);
        }
        else
        {
            transform.localScale = new Vector3(width + 3f, 5, 0);
        }

    }

}
