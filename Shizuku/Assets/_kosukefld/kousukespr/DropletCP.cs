﻿using UnityEngine;

public class DropletCP : MonoBehaviour
{
    public Vector3 Direction { private get; set; }      // the direction the droplet is falling
    public float Speed { private get; set; }            // the speed of the droplet


    void Start()
    {
        Destroy(gameObject, 10F);
    }

    void Update()
    {
        // apply gravity in direction by speed
        transform.position += Direction * Time.deltaTime * Speed;
    }
}
