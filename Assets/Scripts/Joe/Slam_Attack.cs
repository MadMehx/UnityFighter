using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam_Attack : MonoBehaviour
{
    public CharacterController controller3;
    public Animator animator;

    public float attackRate = 1f;
    float nextAttackTime = 0f;
    float lastTap = 0f;

    public Transform SlamAttackHitboxSweetSpot;
    public Transform SlamSplashDamageHitbox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            //Do slam animation
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetKeyDown(KeyCode.C) && controller3.isGrounded)
                {
                    doSlam();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void doSlam()
    {
        if (lastTap + 0.5f <= Time.time)
        {
            animator.SetTrigger("Slam");
            lastTap = Time.time;

            //detect enemies
            Collider[] hitenemies = Physics.OverlapSphere(SlamAttackHitboxSweetSpot.position, attackRange, enemyLayers);

            //damage enemies
            foreach (var enemy in hitenemies)
            {
                Debug.Log("We hit " + enemy.name + " with a big ol' SLAM");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (SlamAttackHitboxSweetSpot == null)
        {
            return;
        }
        if (SlamSplashDamageHitbox == null)
        {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(SlamAttackHitboxSweetSpot.position, attackRange);
        Gizmos.DrawWireSphere(SlamSplashDamageHitbox.position, attackRange);
    }
}
