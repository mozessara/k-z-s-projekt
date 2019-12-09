using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : BaseClass
{
    private GameObject firepoint;

    public Wizard(){
        ClassName = "Wizard";
        Health = 5;
        Strength = 3;
        Intelligence = 8;
        Speed = 4;
        Damage = 6;
        CanShoot = true;
    }
    void start(){
        firepoint = GameObject.Find("FirePoint");
    }

    public void Hit(ShootController prefab){
        Instantiate(prefab, firepoint.transform.position, firepoint.transform.rotation);
    }
}
