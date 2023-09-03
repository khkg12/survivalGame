using JetBrains.Annotations;
using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    private static GameManager instance;

    
    public Player player;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI jetKaraGageText;

    public int Gold
    {
        get => gold;
        set
        {            
            gold = value;
            goldText.text = $"Gold : {gold}";
        }
    }
    private int gold;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = $"Score : {score}";
        }
    }    
    private int score;


    private void Awake()
    {
        var thisObj = FindObjectsOfType<GameManager>();  // FindObjectsOfType : 해당하는 타입의 오브젝트를 찾아서 배열로줌
        if (thisObj.Length == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }        
    }

    

}
