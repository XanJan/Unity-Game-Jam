using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public Transform weaponTip;
    public float damage;
    public float range;
    public float fireRate;
    public GameObject impactFX;
    public LineRenderer lr;
    public GameObject muzzleFlash;
    public RaycastHit2D hitInfo;
    public LayerMask LayerMask;
    public int maxAmmo;
    public float reloadSpeed;
    public TextMeshProUGUI ammoVisual;
    private GameManager gM;

    private float timeTillNext = 0f;
    private bool readyToShoot = true;
    private float timeTillDestroy;
    private int currentAmmo;
    private bool isReloading = false;


    private void Start()
    {
        currentAmmo = maxAmmo;
        gM = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    void Update()
    {
        ammoVisual.text = currentAmmo + "/" + maxAmmo;
        if (Time.time >= timeTillNext)
            readyToShoot = true;
        else
            readyToShoot = false;

        if (Input.GetButton("Fire1") && readyToShoot && currentAmmo > 0 && isReloading == false && gM.GameIsPaused == false)
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
        if (currentAmmo <= 0 && isReloading == false || Input.GetKeyDown(KeyCode.R) && isReloading == false)
        {
            isReloading = true;
            StartCoroutine(Reload());
            return;
        }
    }

    void Shoot()
    {
        currentAmmo--;
        timeTillDestroy = Time.time + 0.02f;
        RaycastHit2D hitInfo = Physics2D.Raycast(weaponTip.position, weaponTip.up, range, ~LayerMask);
        var end = weaponTip.position + weaponTip.up.normalized * range;

        if (hitInfo.collider != null)
        {
            EnemyDamage enemy = hitInfo.transform.GetComponent<EnemyDamage>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
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

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}