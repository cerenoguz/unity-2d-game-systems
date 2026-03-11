using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{

    public GameObject dinazor;
    public float parallaxEffect;
    private float width, positionX;

    public static RepeatingBG instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        positionX = transform.position.x;
    }

    void Update()
    {
        float parallaxDistance = dinazor.transform.position.x * parallaxEffect;
        float Y = dinazor.transform.position.y;
        float remainingDistance = dinazor.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(positionX + parallaxDistance, Y, transform.position.z);

        if (remainingDistance > positionX + width)
        {
            positionX += width;
        }
    }
}
