using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fruitCollecter : MonoBehaviour
{
    private Scene scene;
    bool done = false;
    private int maxfruits;
    private int fruit = 0;
    [SerializeField] private AudioSource CollectSoundEffect;
    [SerializeField] private Text Level;
    [SerializeField] private Text FruitCounter;
    [SerializeField] private Text FruitMax;
    // Start is called before the first frame update
    void Start()
    {
        maxfruits = GameObject.FindGameObjectsWithTag("fruit").Length;
        FruitMax.text = ""+maxfruits;
        scene = SceneManager.GetActiveScene();
        Level.text = (scene.name);
        PlayerPrefs.SetInt("Fruits", maxfruits);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("fruit") && !done){
            
            CollectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruit++;
            FruitCounter.text = ":" + fruit + "|";
            PlayerPrefs.SetInt("Fruitleft", maxfruits-fruit);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
