using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Boss : MonoBehaviour
{

    [Header("Points")] 
    public int scoreGiven;
    public int manaGiven;
    public int coinsGiven;
    
    [Header("Characteristics")]
    public int health;
    public int enemyDamage;
    public float speed;
        
    [Header("AttackRange")]
    public float attackRange;

    [Header("gameObjects")]
    private GameObject player;
    public GameObject effect;
    public GameObject blowEffect;
    public GameObject bulletEnemy;
    public GameObject shotPoint1;
    public GameObject shotPoint2;
    public GameObject shotPoint3;
    public GameObject Coin;

    [Header("Reload")]
    public float reloadTime;
    public float StartReloadTime;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if(!Shop.isAtShop){
            if (Hero.health > 0){
                moveToHero();
                
        if(health > 0 && Hero.health > 0){
                AttackRange();
                }
            }
            death();
            rotation();
        }
    }

    public async Task TakeDamage(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            GetComponent<Renderer>().material.color = Color.red;
            await Task.Delay(200);
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public async Task death()
    {
        if (health <= 0)
        {   
            this.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().material.color = Color.red;

            ScoreManager.score += scoreGiven;
            Hero.scoreTaken += scoreGiven;
            Hero.mana += manaGiven;
            Destroy(gameObject);
            GameObject CoinCreater = Instantiate(Coin, gameObject.transform.position, Quaternion.identity);
        }
    }


    void moveToHero()
    {
        float attackRangeX = this.transform.position.x - player.transform.position.x;
        float attackRangeY = this.transform.position.y - player.transform.position.y;
        if (health > 0)
        {   
            if ((attackRangeX >= -attackRange && attackRangeX <= attackRange) && (attackRangeY >= -attackRange && attackRangeY <= attackRange)){
                
            }
            else{
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            
        }
    }

    void rotation(){
        if (health > 0)
        { 
            if (transform.position.x <= player.transform.position.x){
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    async Task AttackRange()
    {
        float attackRangeX = this.transform.position.x - player.transform.position.x;
        float attackRangeY = this.transform.position.y - player.transform.position.y;

        if ((attackRangeX >= -attackRange && attackRangeX <= attackRange) && (attackRangeY >= -attackRange && attackRangeY <= attackRange))
        {
            if (reloadTime <= 0)
            {
                Instantiate(bulletEnemy, shotPoint1.transform.position, shotPoint1.transform.rotation);
                Instantiate(bulletEnemy, shotPoint2.transform.position, shotPoint2.transform.rotation);
                Instantiate(bulletEnemy, shotPoint3.transform.position, shotPoint3.transform.rotation);
                reloadTime = StartReloadTime;
            }
            else
            {
                reloadTime -= Time.deltaTime;
            }
        }
    }

}