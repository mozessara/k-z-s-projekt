using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    private string className;
    private int health;
    private int strength;
    private int intelligence;
    private int speed;
    private int damage;
    private bool canShoot;

    public string ClassName{
        get{
            return className;
            }
        set{
            className = value;
        }
    }
    public int Health{
        get{return health;}
        set{health = value;}
    }
    public int Strength{
        get{return strength;}
        set{strength = value;}
    }
    public int Speed{
        get{return speed;}
        set{speed = value;}
    }
    public int Intelligence{
        get{return intelligence;}
        set{intelligence = value;}
    }
    public int Damage{
        get{return damage;}
        set{damage = value;}
    }
    public bool CanShoot{
        get{return canShoot;}
        set{canShoot = value;}
    }
}
