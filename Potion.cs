using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int HpGiven;
    public int ManaGiven;
    public GameObject effect;

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.gameObject.tag == "Player"){
        Hero.health += HpGiven;
        Hero.mana += ManaGiven;
        Instantiate(effect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        }
    }
}
