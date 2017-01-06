using UnityEngine;
using System.Collections;

public enum CharacterType
{
    Swordman,
    Magician,
}

public class PlayerStatus : MonoBehaviour {

    public CharacterType Type = CharacterType.Magician;
    public int Level = 1;
    public string Name = "染指空白";
    public float MaxHP = 100;
    public float CurrentHP = 100;
    public float MaxMP = 100;
    public float CurrentMP = 100;

    public int Attack = 20;
    public int AttackPlus = 0;

    public int Def = 20;
    public int DefPlus = 0;

    public int Speed = 20;
    public int SpeedPlus = 0;

    public int RemainPoint = 0;

    public bool GetPoint(int point = 1)
    {
        if (RemainPoint >= point)
        {
            RemainPoint -= point;
            return true;
        }
        return false;
    }
}
