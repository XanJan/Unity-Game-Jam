using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform weaponTip;
    public float damage = 1f;
    public float range;
    public float fireRate;
    public GameObject impactFX;
    public LineRenderer lr;
    public GameObject muzzleFlash;
    public RaycastHit2D hitInfo;
    public LayerMask LayerMask;
    public int maxAmmo;
    public float reloadSpeed;

    private float timeTillNext = 0f;
    private bool readyToShoot = true;
    private float timeTillDestroy;
<<<<<<< HEAD
    private int currentAmmo;
    private bool isReloading = false;


    private void Start()
    {
        currentAmmo = maxAmmo;
    }
=======


    void Start()
    {
        //hitInfo = Physics2D.Raycast(weaponTip.position, weaponTip.up, range);
    }


>>>>>>> 2fa5722c222f6849f18ceeb540314510627a7e41
    void Update()
    {
        if (Time.time >= timeTillNext)
            readyToShoot = true;
        else
            readyToShoot = false;

        if (Input.GetButton("Fire1") && readyToShoot && currentAmmo > 0)
        {
            Shoot();
        }

        if (Time.time >= timeTillDestroy)
        {
            lr.SetPosition(0, Vector3.zero);
            lr.SetPosition(1, Vector3.zero);
            muzzleFlash.SetActive(false);
        }
        if (isReloading)
            return;
        if (currentAmmo <= 0)
        {
            isReloading = true;
            StartCoroutine(Reload());
            return;
        }
    }

    void Shoot()
    {
<<<<<<< HEAD
        Debug.Log(currentAmmo);
        currentAmmo --;
        timeTillDestroy = Time.time + 0.02f;
=======

        timeTillDestroy = Time.time + 0.05f;

>>>>>>> 2fa5722c222f6849f18ceeb540314510627a7e41
        RaycastHit2D hitInfo = Physics2D.Raycast(weaponTip.position, weaponTip.up, range, ~LayerMask);


        var end = weaponTip.position + weaponTip.up.normalized * range;
        Debug.DrawLine(weaponTip.position, end, Color.red);

        if (hitInfo.collider != null)
        {
            Debug.Log(hitInfo.collider.tag);
            GameObject impactOB = Instantiate(impactFX, new Vector3(hitInfo.point.x, hitInfo.point.y, 0), Quaternion.LookRotation(hitInfo.normal));
            impactOB.GetComponent<ParticleSystem>().Play();
            Destroy(impactOB, 2f);
            lr.SetPosition(0, weaponTip.position);
            lr.SetPosition(1, hitInfo.point);

            EnemyDamage enemy = hitInfo.transform.GetComponent<EnemyDamage>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            lr.SetPosition(0, weaponTip.position);
            lr.SetPosition(1, end);
        }


        timeTillNext = Time.time + 1f / fireRate;
        muzzleFlash.SetActive(true);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}