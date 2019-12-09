using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : BaseClass
{
    private Animator anim;

    public WarriorClass(){
        ClassName = "Warrior";
        Health = 10;
        Strength = 9;
        Intelligence = 4;
        Speed = 4;
        Damage = 9;
        CanShoot = false;
    }
    public void Hit(){
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("attack", false);
        StartCoroutine(HitSword());
    }
    IEnumerator HitSword(){
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("attack", false);
    }
}
