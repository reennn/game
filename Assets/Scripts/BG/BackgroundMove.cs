using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BackgroundMove : MonoBehaviour
{
    public Transform cameraTransform;//отслеживание движения камеры
    public Transform [] layers;// массив бэкграундов

    public float viewZone = 5f;// видимая зона 
    private int leftIndex;// левый бэкграунд
    private int rightIndex;// правый бэкграунд
    public float backgroundSize = 20f;//размер бэкграунда

    public float parralaxSpeed = 0.3f;// скорость изменения бэкграаунда
    private float lastCameraX;//последнее расположение камеры


    // Start is called before the first frame update
    void Start()
    {
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];//создаём массив из дочерних элементов(бэкграундов)
        for (int i = 0;i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
            leftIndex = 0;
            rightIndex = layers.Length - 1;
            
        }
    }

    void ScrollRight()
    {
        float lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if(leftIndex == layers.Length)//обнуление левого индекса
        {
            leftIndex = 0;
        }
    }

    void ScrollLeft()
    {
        float lastIndex = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0)//присваивание начального значения
        {
            rightIndex = layers.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, cameraTransform.position.y);//слежение за персом по вертикали
        layers[leftIndex].position = new Vector2(layers[leftIndex].transform.position.x, cameraTransform.position.y);
        layers[rightIndex].position = new Vector2(layers[rightIndex].transform.position.x, cameraTransform.position.y);
        lastCameraX = cameraTransform.position.x;
        float deltaX = cameraTransform.position.x - lastCameraX;
        
        transform.position += Vector3.right * (deltaX * parralaxSpeed);
        
        if(cameraTransform.position.x < layers[leftIndex].transform.position.x + viewZone)
        {
            ScrollLeft();
        }
        if(cameraTransform.position.x > layers[rightIndex].transform.position.x - viewZone)
        {
            ScrollRight();
        }
    }
}
