using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oooo : MonoBehaviour
{
    public Transform m_transform;
    public Transform B_transform;
    public GameObject bulletPrefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;

    public float bulletSpeed = 2.0f;
    public float targetTime = 4.0f;

    public int AttackNum = 1;

    public bool abc = true;
    public bool xyz = true;
    public bool MAttack = true;

    void start()
    {
        m_transform = this.transform;
    }
    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        m_transform.rotation = rotation;
    }
    void Update()
    {
        LAMouse();
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            abc = true;
            xyz = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AttackNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AttackNum = 2;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (abc == false)
        {
            if (xyz == true)
            {
                targetTime = 4.0f;
                xyz = false;
            }
        }
    }
    void Shoot()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        B_transform.rotation = rotation;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, firePointRotation.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePointRotation.right * bulletSpeed;
        Destroy(bullet, 5f);
    }
    void Melee()
    {
        MAttack = true;
    }

    void Attack()
    {
        if(AttackNum==1)
        {
            Melee();
        }
        if(AttackNum==2)
        {
            if(abc == true)
            {
                Shoot();
                abc = false;
            }            
        }
    }
}