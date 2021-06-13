using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    public GameObject effect;
    public bool isSelfDestroyable;

    // public bool isExplosive;
    // public float explosionRadius;
    // public int explosionDamage;
    // public float explodeForce;

    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Boss boss = hitInfo.GetComponent<Boss>();
        if(hitInfo.gameObject.tag == "Boss")
        {
            GameObject effectObject = Instantiate(effect, transform.position, Quaternion.identity);
            boss.TakeDamage(damage);
            Destroy(gameObject);
            if(isSelfDestroyable){
                Destroy(effectObject, 0.4f);
            }
        }
        if(hitInfo.gameObject.tag == "Enemy")
        {
            GameObject effectObject = Instantiate(effect, transform.position, Quaternion.identity);
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            if(isSelfDestroyable){
                Destroy(effectObject, 0.4f);
            }
        }
        if(hitInfo.gameObject.tag == "Wall")
        {
            GameObject effectObject = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if(isSelfDestroyable){
                Destroy(effectObject, 0.4f);
            }
            
        }
    }

    // public void Explosion(){
    //     Collider2D[] overlappedColliders = Physics.OverlapSphere(transform.position, explosionRadius);

    //     for(int i = 0; i < overlappedColliders.Lenght; i++){
    //         Rigidbody2D rb = overlappedColliders[i].attachedRigidbody2D;
    //         if(rb){
    //             rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);

    //         }
    //     }
    // }
}