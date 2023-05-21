using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //* In order to execute Raycast method we have to give it some parameters
        //* FPCamera.transform.position is for the starting point
        //* FPCamera.transform.forward is for the direction of the cast
        RaycastHit hit;
        //* This one will store the information about the object that the cast collided with.
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range); //? Why we indicate out hit, what does it mean?

        Debug.Log("I hit this thing:" + hit.transform.name);
    }
}
