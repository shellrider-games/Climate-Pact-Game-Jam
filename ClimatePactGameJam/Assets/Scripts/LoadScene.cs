using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void InitSceneLoad(){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
