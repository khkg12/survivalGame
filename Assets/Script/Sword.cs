using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Sword : MonoBehaviour
{    
    private Player player;    
    
    void Start()
    {        
        player = GameManager.Instance.player;        
    }

    private void OnTriggerEnter(Collider other)
    {
        Monster monster;        
        if(other.gameObject.TryGetComponent<Monster>(out monster))
        {            
            monster.Hit();
            player.JetKaraGage += 1;
            monster.Hp -= player.Atk;
        }        
    }
}
