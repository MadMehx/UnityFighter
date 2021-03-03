using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public CharacterController controller2;
    public Animator animator;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    float lastTap = 0f;

    public Transform Attack1Hitbox;
    public Transform Attack2Hitbox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                if (Input.GetKeyDown(KeyCode.C) && controller2.isGrounded)
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
        else
        {
            AttackFollowUp();
        }
    }

    void Attack()
    {
        //play attack animation
        animator.SetTrigger("Hit_1");
        lastTap = Time.time;

        //detect enemies
        Collider[] hitenemies = Physics.OverlapSphere(Attack1Hitbox.position, attackRange, enemyLayers);

        //damage enemies
        foreach (var enemy in hitenemies)
        {
            Debug.Log("We hit the dummy!");
        }
    }

    void AttackFollowUp()
    {
        if (Input.GetKeyDown(KeyCode.C) && (lastTap + 0.5f >= Time.time))
        {
            //play attack animation
            animator.SetTrigger("Hit_2");

            //detect enemies
            Collider[] hitenemies = Physics.OverlapSphere(Attack1Hitbox.position, attackRange, enemyLayers);

            //damage enemies
            foreach (var enemy in hitenemies)
            {
                Debug.Log("We hit the dummy with a follow up!");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (Attack1Hitbox == null)
        {
            return;
        }
        if (Attack2Hitbox == null)
        {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Attack1Hitbox.position, attackRange);
        Gizmos.DrawWireSphere(Attack2Hitbox.position, attackRange);

    }
}
