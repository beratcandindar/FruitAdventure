using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Button previousBtn, nextBtn;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;
    void Start()
    {
        
    }
    public void Awake(){
        currentPage = (PlayerPrefs.GetInt("MaxReachedLevel")/6)+1;
        targetPos = levelPagesRect.localPosition;
        for (int i = 1; i<currentPage;i++)
            {
            if (i == currentPage-1){
                if(PlayerPrefs.GetInt("MaxReachedLevel") % 6 == 0) break;
            }
            targetPos+= pageStep;
            MovePage();
        }
        UpdateArrowButton();
    }
    public void Next(){
        if(currentPage < maxPage){
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }
    public void Previous(){
        if(currentPage > 1){
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }
    public void MovePage(){
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
        UpdateArrowButton();
    }
    void UpdateArrowButton()
    {
        nextBtn.interactable = true;
        previousBtn.interactable = true;
        if(currentPage == 1) previousBtn.interactable=false;
        else if(currentPage == maxPage) nextBtn.interactable=false;
    }
}
