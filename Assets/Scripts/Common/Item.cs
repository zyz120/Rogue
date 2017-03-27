using UnityEngine;
using System.Collections;

public class Item
{
    public enum ItemType { none, consumable, dagger, sword, bow, staff, armor, leggings, shoes, handguard };

    public ItemType type;

    // 消耗品属性
    public float resumeHP;
    public float resumeSP;
    public float duration;

    // 攻击属性
    public float physicsAttack;
    public float magicAttack;

    // 防御属性
    public float physicsDefense;
    public float magicDefense;

    // 通用属性
    public int price;

    public Item()
    {
        type = ItemType.none;
    }
    

}
