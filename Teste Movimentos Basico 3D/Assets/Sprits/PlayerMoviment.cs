using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float zMovement = joystick.Vertical();

        transform.position += new Vector3(xMovement, 0f, zMovement) * speed * Time.deltaTime;

    }

}
