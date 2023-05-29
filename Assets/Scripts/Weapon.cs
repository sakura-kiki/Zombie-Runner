using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;  //* The weapon's damage 
    [SerializeField] float timeBetweenShots = 0.5f;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);

        canShoot = true;
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
            CreateHitImpact(hit);
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

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //* hit.point is the location of the instationtion
        //* Quaternion.identity would do the same thing
        //* The hit.normal is the "normal" from the physics
        //* Look rotation means where the player look at
        Destroy(impact, 0.1f);
    }
}
