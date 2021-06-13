using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject panel;
    public static bool isAtShop = false;
    public static bool here = false;

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && here){
            isAtShop = !isAtShop;
            panel.SetActive(isAtShop);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.gameObject.tag == "Player"){
            //Debug.Log("Tut");
            here = true;
        }
    }
    void OnTriggerExit2D(Collider2D trigger){
        if(trigger.gameObject.tag == "Player"){
            //Debug.Log("Ne Tut");
            here = false;
        }
    }
}
