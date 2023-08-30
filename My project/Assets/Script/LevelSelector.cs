using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int level;
    [SerializeField] private Text LevelText;
    public GameObject Lock,Star1,Star2,Star3;
    
    private Color yeniRenk = new Color(255f / 255f, 255f / 255f, 255f / 255f, 1); // R, G, B değerleri 0-255 arasında
    void Start()
    {
        if(PlayerPrefs.GetInt("MaxReachedLevel") >= level){
            Lock.SetActive(false);
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            
            if(PlayerPrefs.GetInt("Star" + level) >= 1){
                Star3.GetComponent<Image>().color = yeniRenk;
            }
            if(PlayerPrefs.GetInt("Star" + level) >= 2){
                Star1.GetComponent<Image>().color = yeniRenk;
            }
            if(PlayerPrefs.GetInt("Star" + level) == 3){
                Star2.GetComponent<Image>().color = yeniRenk;
            }
        }
        LevelText.text = level.ToString();
    }
    public void ExitGame(){
        Application.Quit();        
    }
    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
