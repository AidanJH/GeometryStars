using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{

     public enum WeaponType
    {
        StandardBullet,
        Laser,
        DelayedBullet
    }

    private Rigidbody2D rb;

    public WeaponType currentWeaponType;
    public GameObject bulletPrefab;
    public GameObject laserPrefab;
    public GameObject delayedBulletPrefab;


    public float fireRate = 0.1f; // Weapon can fire once every 0.5 seconds
    private float nextFireTime = 0.0f;
    float weaponOffset = 1f;
    public float bulletSpeed = 10f;
    public float laserChargeTime = 1f;
    public float delayedBulletDelay = 0.5f;
    public int gamepadIndex = 0;

    private Gamepad gamepad;
    private Quaternion targetRotation;

    void Start()
    {
        currentWeaponType = WeaponType.StandardBullet;
        rb = GetComponent<Rigidbody2D>();
        if (Gamepad.all.Count > gamepadIndex)
        {
            gamepad = Gamepad.all[gamepadIndex];
        }
    }

    void Update()
    {
        if (gamepad == null)
        {
            return;
        }

        Vector2 direction = gamepad.rightStick.ReadValue();


        if (direction.sqrMagnitude > 0 && Time.time > nextFireTime)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
            FireWeapon(direction);
            nextFireTime = Time.time + fireRate;
            // StartCoroutine(FireLaser());
            // StartCoroutine(FireDelayedBullet());
        }
    }

    public void FireWeapon(Vector2 direction)
    {
        switch (currentWeaponType)
        {
            case WeaponType.StandardBullet:
                FireBullet(direction);
                break;
            // case WeaponType.Laser:
            //     StartCoroutine(FireLaser(direction));
            //     break;
            // case WeaponType.DelayedBullet:
            //     StartCoroutine(FireDelayedBullet(direction));
            //     break;
        }
    }

    void FireBullet(Vector2 direction)
    {
        Vector2 bulletSpawnPosition = transform.position + weaponOffset * transform.up;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);

        bullet.GetComponent<Bullet>().Initialize(direction);
        
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        float totalSpeed = rb.velocity.magnitude + bulletSpeed;
        bulletRb.velocity = direction.normalized * totalSpeed;
    }

    IEnumerator FireLaser(Vector2 direction)
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.LookRotation(direction));
        laser.GetComponent<Laser>().Initialize(direction);
        //Need to implement a slight widening and brightening of the prefab

        yield return new WaitForSeconds(laserChargeTime);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        if (hit.collider != null)
        {
            // Handle hit
        }
    }

    IEnumerator FireDelayedBullet(Vector2 direction)
    {
        yield return new WaitForSeconds(delayedBulletDelay);
        GameObject delayedBullet = Instantiate(bulletPrefab, transform.position, targetRotation);
        Rigidbody2D delayedBulletRb = delayedBullet.GetComponent<Rigidbody2D>();
        delayedBulletRb.velocity = transform.up * bulletSpeed;
    }
}
