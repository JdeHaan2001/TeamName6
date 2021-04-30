using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[CreateAssetMenu(fileName = "Quest File", menuName = "Quest Files Archive")]
public class Quest : ScriptableObject
{
    public bool IsActive;

    public string Title;
    public string Description;
    public int FollowersReward;
    public int MoneyReward;
}
