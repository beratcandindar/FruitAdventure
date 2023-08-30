using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private int scenetoContinue;
    // Start is called before the first frame update
    public void StartGame()
    {
        if (!(PlayerPrefs.GetInt("MaxReachedLevel") > 0)){
            PlayerPrefs.SetInt("MaxReachedLevel", 1);
            Debug.Log(!(PlayerPrefs.GetInt("MaxReachedLevel") >= 0));
        }
        if (!(PlayerPrefs.GetInt("SavedScene") > 0)){
            PlayerPrefs.SetInt("SavedScene", 1);
        }
        scenetoContinue = PlayerPrefs.GetInt("SavedScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(scenetoContinue >= 0 && scenetoContinue <= 24){
            SceneManager.LoadScene(scenetoContinue);
        }
        else{
            SceneManager.LoadScene("Level 1");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
