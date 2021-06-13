using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class Hero : MonoBehaviour
{
    [Header("Health and mana")]
    public static int health = 100;
    public Text healthText;
    public static int mana = 100;
    public Text manaText;
    public static int coins = 1000;
    public Text coinsText;
    public Slider healthBar;
    public Slider manaBar;

    [Header("Movement")]
    public float runSpeed = 6f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    [Header("Panel")]
    public GameObject panelRestart;
    public static float scoreTaken = 0;

    [Header("Weapon")]
    public List<GameObject> unlockedWeapon;
    public GameObject[] allWeapons;
    public Image weaponImage;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (health > 0 && !Shop.isAtShop) {
            SwitchWeapon();
        }
        healthBar.value = health;
        manaBar.value = mana;
        dead();
    }
        
    void FixedUpdate(){
        if (health > 0 && !Shop.isAtShop) {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
            rotation();
            move();
            checkMH();
        }
    }

    void move(){
        if (health > 0)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * runSpeed;
        }
    }

    void checkMH(){
        healthText.text = health.ToString();
        manaText.text = mana.ToString();
        coinsText.text = coins.ToString();


        healthText.text = health + "/100";
        manaText.text = mana + "/100";
        coinsText.text = "" + coins;

        if(mana > 100){
            mana = 100;
        }
        if(health > 100){
            health = 100;
        }
    }

    

    void rotation()
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (this.transform.position.x < worldPos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void dead()
    {
        if(health <= 0)
        {
            health = 0;
            scoreTaken = 0;
            panelRestart.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Weapon")){
            for (int i = 0; i < allWeapons.Length; i++)
            {
                if(other.name == allWeapons[i].name + "(Clone)"){
                    unlockedWeapon.Add(allWeapons[i]);
                }
            }
            Destroy(other.gameObject);
        }
    }

    void SwitchWeapon(){
        if(Input.GetKeyDown(KeyCode.Q)){
        for (int i = 0; i < unlockedWeapon.Count; i++)
        {
            if(unlockedWeapon[i].activeInHierarchy){
                unlockedWeapon[i].SetActive(false);
                if(i != 0){
                    unlockedWeapon[i-1].SetActive(true);
                    weaponImage.sprite = unlockedWeapon[i-1].GetComponent<SpriteRenderer>().sprite;

                }
                else{
                    unlockedWeapon[unlockedWeapon.Count-1].SetActive(true);
                    weaponImage.sprite = unlockedWeapon[unlockedWeapon.Count-1].GetComponent<SpriteRenderer>().sprite;
                }
                // weaponImage.SetNativeSize();
                break;
            }
        }
        }
    }
}










