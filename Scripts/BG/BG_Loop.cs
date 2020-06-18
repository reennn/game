using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Loop : MonoBehaviour
{

    public float parallaxspeed = 0.1f;

    private Vector2 offset = Vector2.zero;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;//получение материала из объекта
        offset = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += parallaxspeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
