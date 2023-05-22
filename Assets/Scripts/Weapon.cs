using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;  //* The weapon's damage 
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        //* In order to execute Raycast method we have to give it some parameters
        //* FPCamera.transform.position is for the starting point
        //* FPCamera.transform.forward is for the direction of the cast
        RaycastHit hit;
        //* This one will store the information about the object that the cast collided with.
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing:" + hit.transform.name);
            //TODO: Add some visual or sound hit effect for players
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            //* Prevent the error messages when we shoot the game props
            if (target == null) return;
            target.TakeDamage(damage);
        }
        //* This will prevent getting error messages when we shoot the sky/raycast goes to infinity
        else
        {
            return;
        }
    }
}
