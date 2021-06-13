using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject player;
    public float range;
    public float speed;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate(){
        float pickUpRangeX = this.transform.position.x - player.transform.position.x;
        float pickUpRangeY = this.transform.position.y - player.transform.position.y;
        if ((pickUpRangeX >= -range && pickUpRangeX <= range) && (pickUpRangeY >= -range && pickUpRangeY <= range)){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            Hero.coins++;
            Destroy(gameObject);
        }
    }
    
    
}
