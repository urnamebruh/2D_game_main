using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
  public UIMan2 UIMan2;

  public float bulletSpeed = 2.0f;
  public float moveSpeed = 5.0f;
  public float targetTime = 4.0f;
  public float DamagTimer = 0.3f;

  int AttackNum = 0;
  public int dam = 0;

  //health
  public int MaxHealth = 10;
  int Health = 0;
  public Slider healthBar;

  bool abc = true;
  bool xyz = true;
  bool MAttack = true;

  // Material Related
  public Material myMaterial;
  [Range(0f,1f)]
  float Timer1 = 1.5f;
  public float alpha = 0f;

  void Start()
  {
    Health = MaxHealth;
    alpha = 0f;
    m_transform = this.transform;
    m_GO = this.gameObject;
    rb2d = GetComponent<Rigidbody2D>();
    Debug.Log(rb2d.velocity);
    Debug.Log(m_GO);
    Debug.Log(Time.time);
  }

  void Update()
  {
    healthBar.value = Health;
    DamagTimer -= Time.deltaTime;
    if(Health <= 0)
    {
      Debug.Log("Player_DEAD");
      UIMan2.death = true;
      alpha = 0f;
    }
    if(Health == 1)
    {
      alpha = 0.25f;
    }
    if (dam >= 1)
    {
      Health -= dam;
      dam = 0;
      Debug.Log(Health);
      alpha = 0.5f;
    }

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
    myMaterial.color = new Color(myMaterial.color.r, myMaterial.color.g, myMaterial.color.b, alpha);
    alpha -= Time.deltaTime;
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
  public void OnParticleCollision(GameObject other)
  {
    if(DamagTimer <= 0)
    {
      DamagTimer = 0.3f;
      Health -= 1;
      alpha = 0.5f;
      Debug.Log(Health);
    }
  }
}