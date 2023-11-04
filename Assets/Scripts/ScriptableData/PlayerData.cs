using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 1)]
public class PlayerData : ScriptableObject 
{
    public bool playerCanMove=true;

    //Toogle Koyucam. Boylelikle playerin yolunu belirledikten sonra hizini secebilirler ve engellere carpmadan gecebilir.
    public int Speed=5;
    
}
