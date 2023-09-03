using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUp : MonoBehaviour
{
    Player player;
    int requiredHpGold = 100;
    int requiredAtkGold = 100;
    int requiredSpeedGold = 100;
    private void Start()
    {
        player = GameManager.Instance.player;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(GameManager.Instance.Gold > requiredHpGold)
            {
                GameManager.Instance.Gold -= requiredHpGold;
                player.Hp += 10;
                requiredHpGold *= 2;
            }
            else
            {
                Debug.Log("돈이 부족합니다");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GameManager.Instance.Gold > requiredAtkGold)
            {
                GameManager.Instance.Gold -= requiredAtkGold;
                player.Atk += 5;
                requiredAtkGold *= 2;
            }
            else
            {
                Debug.Log("돈이 부족합니다");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (GameManager.Instance.Gold > requiredSpeedGold)
            {
                GameManager.Instance.Gold -= requiredSpeedGold;
                player.MoveSpeed += 0.002f;
                requiredSpeedGold *= 2;
            }
            else
            {
                Debug.Log("돈이 부족합니다");
            }
        }
    }
}
