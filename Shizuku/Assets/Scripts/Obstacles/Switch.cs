﻿using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public float pressHeight = 0.2F;
    public UnityEvent pressEvent;
    public UnityEvent releaseEvent;

    private Vector3 startPos;
    private int overlap;


    private void Start()
    {
        startPos = transform.position;
        overlap = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

        overlap++;

        if(IsPressed())
            pressEvent.Invoke();

        transform.position = startPos - new Vector3(0, pressHeight, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        overlap--;

        if (!IsPressed())
        {
            transform.position = startPos;
            releaseEvent.Invoke();
        }
    }

    public bool IsPressed()
    {
        return overlap != 0;
    }
}
