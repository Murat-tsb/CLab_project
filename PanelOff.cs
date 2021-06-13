using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOff : MonoBehaviour
{
    public GameObject panel;

    public void PanelSwitchOFff(){
        panel.SetActive(false);
    }
}
