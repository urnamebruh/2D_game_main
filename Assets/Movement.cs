using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;
    Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    

    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      if (Input.GetButtonDown("Fire1"))
      {
        Shoot();
      } 
      float moveInputX = Input.GetAxisRaw("Horizontal"); // For horizontal movement (left/right)
      float moveInputY = Input.GetAxisRaw("Vertical");   // For vertical movement (up/down)
      // Normalise the vector so that we don't move faster when moving diagonally.
      Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
      moveDirection.Normalize();

      // Assign velocity directly to the Rigidbody
      rb2d.velocity = moveDirection * moveSpeed;
    }

    void RotateBulletSpawnPointTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        
        Vector2 direction = (mousePosition - firePointRotation.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePointRotation.rotation = Quaternion.Euler(new Vector3(0,0, angle));

    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, firePointRotation.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePointRotation.right * bulletSpeed;
        Destroy(bullet, 5f);
    }
}