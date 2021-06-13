using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;

public class Menu : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject Overall;
    private bool panel = false;
    private bool panelOverall = true;
    
    public void ChangeScenes(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Instructions(){
        panel = !panel;
        Instruction.SetActive(panel);
        panelOverall = !panelOverall;
        Overall.SetActive(panelOverall);
    }
}
