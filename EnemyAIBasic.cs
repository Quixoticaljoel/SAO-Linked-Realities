using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAIBasic : MonoBehaviour


{

    public Rigidbody rb;
    public Animator anim;
    int Not = Animator.StringToHash("Run");
    int Run = Animator.StringToHash("NoRun");
    int attack = Animator.StringToHash("Attack");
    
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject Self;
    public Transform Self2;
    public Transform Death;

    public healthbarscript healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        target = GameObject.Find("XR Rig(Clone)").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
    }


    void Update()
    {
        target = GameObject.Find("XR Rig(Clone)").transform;
        agent = GetComponent<NavMeshAgent>();

        
        float distance = Vector3.Distance(target.position, transform.position);

        if (currentHealth <= 0)
        {
            Destroy(Self);

            Debug.Log("enemy dead");
        }

    

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);


            if (distance <= agent.stoppingDistance)
            {
                
                PlayAttack();
                FaceTarget();
            }


        }


    }

   

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void PlayAttack()
    {
        
        anim.Play("ComboAttack");
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Sword")
        {
            Debug.Log("Enemy Damage taken");
            TakeDamage(5);
        }
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("Enhacement hit");
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}