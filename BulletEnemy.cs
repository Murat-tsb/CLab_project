using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class BulletEnemy : MonoBehaviour
{
    public float speed;
    public int damage;
    public float explosionRadius;
    public Rigidbody2D rb;
    public GameObject effect;
    private GameObject player;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update(){
        if(!Shop.isAtShop){
            rb.velocity = -transform.right * speed;
        }
    }

    async Task OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.tag == "Player")
        {
            explosion();
            Destroy(gameObject);
        }
        if(hitInfo.gameObject.tag == "Wall")
        {
            explosion();
            Destroy(gameObject);
        }
    }

    public async Task explosion(){
        float blowRadiusX = transform.position.x - player.transform.position.x;
        float blowRadiusY = transform.position.y - player.transform.position.y;
        GameObject BlowEffect = Instantiate(effect, gameObject.transform.position, Quaternion.identity);
        Destroy(BlowEffect, 0.4f);
        if((blowRadiusX >= -explosionRadius && blowRadiusX <= explosionRadius) && (blowRadiusY >= -explosionRadius && blowRadiusY <= explosionRadius)){
            Hero.health -= damage;
            player.GetComponent<Renderer>().material.color = Color.red;
            await Task.Delay(500);
            player.GetComponent<Renderer>().material.color = Color.white;
                
        }
    }
}