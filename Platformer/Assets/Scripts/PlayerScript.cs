using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float jumpForce = 400f;
    public float horizontalMove;
    private bool jump = false;
    Rigidbody2D rb;

    public string playerClass = "player";
    public int playerHP;
    public int playerStrength;
    public int playerIntelligence;
    public int playerSpeed;
    public int playerDamage;

    public Transform firePoint;
    public List<GameObject> weapons = new List<GameObject>();

    public GameObject sword_prefab;
    public GameObject staff_prefab;
    public GameObject bow_prefab;
    public ShootController fireBall_prefab;
    public ShootController grenade_prefab;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

        if(horizontalMove < 0f) transform.localEulerAngles = new Vector3(0, 180, 0);
        if(horizontalMove > 0f) transform.localEulerAngles = new Vector3(0, 0, 0);

        if(Input.GetButtonDown("Jump")) jump = true;

        if(Input.GetButtonDown("Fire1")){
            if(GetComponent<warrior>()) GetComponent<warrior>().Hit();
            else if(GetComponent<Wizard>()) GetComponent<Wizard>().Hit(fireBall_prefab);
            else if(GetComponent<RangerClass>()) GetComponent<RangerClass>().Hit(grenade_prefab);
        }
    }
    public void WarriorClass(){
        if(!GetComponent<warrior>()){
            if(GetComponent<Wizard>() || GetComponent<RangerClass>()){
                Destroy(GetComponent<RangerClass>());
                Destroy(GetComponent<Wizard>());
            }
            var klassz = gameObject.AddComponent<warrior>();
            playerClass = klassz.ClassName;
            playerHP = klassz.Health;
            playerStrength = klassz.Strength;;
            playerIntelligence = klassz.Intelligence;
            playerSpeed = klassz.Speed;
            playerDamage = klassz.Damage;

            firePoint.localEulerAngles = new Vector3(0, 0, 0);

            if(weapons.Count == 1){
                Destroy(weapons[0]);
                weapons.Remove(weapons[0]);
            }
            if(weapons.Count < 1){
                weapons.Add(Instantiate(sword_prefab, transform, false));
                weapons[0].transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                weapons[0].gameObject.SetActive(true);

            }
            
        }
    }
    public void WizardClass(){
        if(!GetComponent<Wizard>()){
            if(GetComponent<warrior>() || GetComponent<RangerClass>()){
                Destroy(GetComponent<RangerClass>());
                Destroy(GetComponent<warrior>());
            }
            var klassz = gameObject.AddComponent<Wizard>();
            playerClass = klassz.ClassName;
            playerHP = klassz.Health;
            playerStrength = klassz.Strength;;
            playerIntelligence = klassz.Intelligence;
            playerSpeed = klassz.Speed;
            playerDamage = klassz.Damage;

            firePoint.localEulerAngles = new Vector3(0, 0, 0);

             if(weapons.Count == 1){
                Destroy(weapons[0]);
                weapons.Remove(weapons[0]);
            }
            if(weapons.Count < 1){
                weapons.Add(Instantiate(staff_prefab, transform, false));
                weapons[0].transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                weapons[0].gameObject.SetActive(true);

            }

        }
    }
    public void RangerClass(){
        if(!GetComponent<RangerClass>()){
            if(GetComponent<Wizard>() || GetComponent<warrior>()){
                Destroy(GetComponent<warrior>());
                Destroy(GetComponent<Wizard>());
            }
            var klassz = gameObject.AddComponent<RangerClass>();
            playerClass = klassz.ClassName;
            playerHP = klassz.Health;
            playerStrength = klassz.Strength;;
            playerIntelligence = klassz.Intelligence;
            playerSpeed = klassz.Speed;
            playerDamage = klassz.Damage;

            firePoint.localEulerAngles = new Vector3(0, 0, 45);
            if(weapons.Count == 1){
                Destroy(weapons[0]);
                weapons.Remove(weapons[0]);
            }
            if(weapons.Count < 1){
                weapons.Add(Instantiate(bow_prefab, transform, false));
                weapons[0].transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                weapons[0].gameObject.SetActive(true);

            }
        
        }
    }
    private void FixedUpdate(){
        Moving(horizontalMove, jump);
    }
     void Moving(float movement, bool canjump)
    {
        rb.velocity = new Vector2(movement * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (canjump && GetComponent<CircleCollider2D>().IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = !canjump;
        }
    }
    
}
