using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public CharacterController character;

    public healthbarscript healthBar;

    
 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.tag == "EnemyObject")
        {
                      Debug.Log("Damage taken");
            TakeDamage(10);
        }

    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Update()
    {
        character.SimpleMove(new Vector3(0.0000000000001f, 0f, 0f));
        
        if (currentHealth == 0)
        {
            SceneManager.LoadScene(4);
        }
        
    }

}
