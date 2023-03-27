using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOscillation : MonoBehaviour
{
    Vector3 startPosition;
    float movementFactor;

    [Header("Parameters")]
    [SerializeField]
    Vector3 movementVector;
    [SerializeField]
    float cycleTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 0.25f, Space.World);

        if (cycleTime <= 0f) return;

        float cycles = Time.time / cycleTime;
        float tau = Mathf.PI * 2;
        float sinWave = Mathf.Sin(cycles * tau);

        movementFactor = sinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;
    }
}
