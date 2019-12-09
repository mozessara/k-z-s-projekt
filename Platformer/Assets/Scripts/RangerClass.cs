using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerClass : BaseClass
{
    private GameObject firepoint;
    public RangerClass(){
        ClassName = "Ranger";
        Health = 8;
        Strength = 3;
        Intelligence = 2;
        Speed = 5;
        Damage = 5;
        CanShoot = true;
    }
    void start(){
        firepoint = GameObject.Find("FirePoint");
    }

    public void Hit(ShootController prefab){
        Instantiate(prefab, firepoint.transform.position, firepoint.transform.rotation);
    }
}
