using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{    
    public Button BattleBtn;
    void Start()
    {
        BattleBtn.onClick.AddListener(() => GoToBattleScene());
    }
    
    public void GoToBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
