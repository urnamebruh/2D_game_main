using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public Transform m_transform;
    public float bulletSpeed = 0f;
    Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    public GameObject m_GO;
    

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
    void LAMouse()
    {
      Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    void Shoot()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, firePointRotation.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePointRotation.right * bulletSpeed;
        Destroy(bullet, 5f);
    }
}