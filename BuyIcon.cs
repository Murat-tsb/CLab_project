using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyIcon : MonoBehaviour
{
    private Transform shop;
    private Transform player;
    private Vector2 ShopPos;
    public GameObject item;
    public int itemCost;
    public static bool alreadyBought = false;
    public bool isUnlimited;
    
    void Start(){
        shop = GameObject.FindWithTag("Shop").transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    public void BuyItem(){
        if(player.position.x > shop.position.x){
            ShopPos = new Vector2(player.position.x + 2, player.position.y);
        }
        else{
            ShopPos = new Vector2(player.position.x - 2, player.position.y);
        }
        if(isUnlimited){
            if(Hero.coins - itemCost >= 0){
            Instantiate(item, ShopPos, Quaternion.identity);
            Hero.coins -= itemCost;
            }
        }
        else{
            if(Hero.coins - itemCost >= 0 ){ //&& !alreadyBought
            Instantiate(item, ShopPos, Quaternion.identity);
            alreadyBought = true;
            Hero.coins -= itemCost;
            }
        }
    } 
}
