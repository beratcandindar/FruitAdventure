using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NexLevel : MonoBehaviour
{
    public GameObject StarMenu,Box,Star1,Star2,Star3,Continuebutton,Menubutton,Startbutton;
    private AudioSource FinishSoundEffect;
    private Color yeniRenk = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0);
    // Start is called before the first frame update
    void Start()
    {
        FinishSoundEffect = GetComponent<AudioSource>();
    }
    public void ExitGame(){
        Application.Quit();
    }
    public void LevelMap(){
        SceneManager.LoadScene("Level Map");
    }
    public void Menu(){
        SceneManager.LoadScene("StartScreen");
    }
    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player"){ 
            FinishSoundEffect.Play();
            Invoke("CompleteLevel", 0.3f);
        }
    }
    // Update is called once per frame
    private void CompleteLevel(){
        int fruitLeft = PlayerPrefs.GetInt("Fruitleft");
        int MaxFruit = PlayerPrefs.GetInt("Fruits");
        int fruitCollected = MaxFruit - fruitLeft;
        
        float percentage = float.Parse( fruitCollected.ToString()) / float.Parse(MaxFruit.ToString()) * 100f;
        Debug.Log(percentage);
        if (percentage >= 10 && percentage < 50){
            Star1.GetComponent<Image>().color = yeniRenk;
            if(PlayerPrefs.GetInt("Star" + SceneManager.GetActiveScene().buildIndex) <= 1){
                PlayerPrefs.SetInt(("Star" + SceneManager.GetActiveScene().buildIndex),1);
            }
        }
        else if (percentage >= 50 && percentage < 80){
            Star1.GetComponent<Image>().color = yeniRenk;
            Star2.GetComponent<Image>().color = yeniRenk;
            if(PlayerPrefs.GetInt("Star" + SceneManager.GetActiveScene().buildIndex) <= 1){
                PlayerPrefs.SetInt(("Star" + SceneManager.GetActiveScene().buildIndex),2);
            }
        }
        else if (percentage >= 80 && percentage <= 100){
            Star1.GetComponent<Image>().color = yeniRenk;
            Star2.GetComponent<Image>().color = yeniRenk;
            Star3.GetComponent<Image>().color = yeniRenk;
            if(PlayerPrefs.GetInt("Star" + SceneManager.GetActiveScene().buildIndex) <= 1){
                PlayerPrefs.SetInt(("Star" + SceneManager.GetActiveScene().buildIndex),3);
            }
        }
        else if ((percentage == 0) && (PlayerPrefs.GetInt("Star" + SceneManager.GetActiveScene().buildIndex) == 0)){
             PlayerPrefs.SetInt(("Star" + SceneManager.GetActiveScene().buildIndex),0);
        }
        if (PlayerPrefs.GetInt("MaxReachedLevel") < SceneManager.GetActiveScene().buildIndex+1){
            PlayerPrefs.SetInt("MaxReachedLevel", SceneManager.GetActiveScene().buildIndex+1);
        }
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex+1);
        PlayerPrefs.Save();
        StarMenu.SetActive(true);
        LeanTween.moveLocal(Box, new Vector3 (0f, 0f, 0f), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeOutCirc).setOnComplete(starsAnimation);
        LeanTween.alpha(Star1.GetComponent<RectTransform>(), 1f, .5f).setDelay(1f);
        LeanTween.alpha(Star2.GetComponent<RectTransform>(), 1f, .5f).setDelay(1.4f);
        LeanTween.alpha(Star3.GetComponent<RectTransform>(), 1f, .5f).setDelay(1.8f);
    }
    void starsAnimation(){
        LeanTween.scale(Star1, new Vector3(1.4f, 1.4f, 1.4f), 1f).setEase(LeanTweenType.easeOutElastic);     
        LeanTween.scale(Star2, new Vector3(1.4f, 1.4f, 1.4f), 1f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic); 
        LeanTween.scale(Star3, new Vector3(1.4f, 1.4f, 1.4f), 1f).setDelay(.4f).setEase(LeanTweenType.easeOutElastic).setOnComplete(MenuAnimation);
        
    }
    void MenuAnimation(){
        LeanTween.alpha(Continuebutton.GetComponent<RectTransform>(), 1f, .5f).setDelay(.6f);
        LeanTween.alpha(Menubutton.GetComponent<RectTransform>(), 1f, .5f).setDelay(.6f);
        LeanTween.alpha(Startbutton.GetComponent<RectTransform>(), 1f, .5f).setDelay(.6f);
    }
}
