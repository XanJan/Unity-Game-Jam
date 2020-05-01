﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform weaponTip;
    public float damage;
    public float range;
    public float fireRate;
    public GameObject impactFX;
    public LineRenderer lr;
    public GameObject muzzleFlash;

    private float timeTillNext = 0f;
    private bool readyToShoot = true;
    private float timeTillDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeTillNext)
            readyToShoot = true;
        else
            readyToShoot = false;
        if (Input.GetButton("Fire1") && readyToShoot)
        {
            Shoot();
        }

        if (Time.time >= timeTillDestroy)
        {
            lr.SetPosition(0, Vector3.zero);
            lr.SetPosition(1, Vector3.zero);
            muzzleFlash.SetActive(false);
        }
    }

    void Shoot()
    {
        timeTillDestroy = Time.time + 0.05f;

        RaycastHit2D hitInfo = Physics2D.Raycast(weaponTip.position, weaponTip.up, range);

        var end = weaponTip.position + weaponTip.up.normalized * range;
        Debug.DrawLine(weaponTip.position, end, Color.red);

        if(hitInfo.collider != null)
        {
            Debug.Log(hitInfo.collider.tag);
            GameObject impactOB = Instantiate(impactFX, new Vector3(hitInfo.point.x, hitInfo.point.y, 0), Quaternion.LookRotation(hitInfo.normal));
            impactOB.GetComponent<ParticleSystem>().Play();
            Destroy(impactOB, 2f);
            lr.SetPosition(0, weaponTip.position);
            lr.SetPosition(1, hitInfo.point);
        }
        else
        {
            lr.SetPosition(0, weaponTip.position);
            lr.SetPosition(1, end);
        }


        timeTillNext = Time.time + 1f / fireRate;
        muzzleFlash.SetActive(true);
    }
}