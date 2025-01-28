using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;

    public Transform m_transform;
    public Transform B_transform;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;
    public GameObject sword;
    public GameObject wand;
    GameObject m_GO;

    public float bulletSpeed = 2.0f;
    public float moveSpeed = 5.0f;
    public float targetTime = 4.0f;

    int AttackNum = 0;

    bool abc = true;
    bool xyz = true;
    bool MAttack = true;
    

    void Start()
    {
      m_transform = this.transform;
      m_GO = this.gameObject;
      rb2d = GetComponent<Rigidbody2D>();
      Debug.Log(rb2d.velocity);
      Debug.Log(m_GO);
      Debug.Log(Time.time);
    }

    void Update()
    {
      targetTime -= Time.deltaTime;
      if (targetTime <= 0.0f)
      {
          abc = true;
          xyz = true;
      }
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
          Debug.Log("A1");
          AttackNum = 1;
          sword.SetActive(true);
          wand.SetActive(false);
      }
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
          AttackNum = 2;
          sword.SetActive(false);
          wand.SetActive(true);
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
      float moveInputX = Input.GetAxisRaw("Horizontal");
      float moveInputY = Input.GetAxisRaw("Vertical");
      Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
      moveDirection.Normalize();

      rb2d.velocity = moveDirection * moveSpeed;
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