using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Slam_Attack : MonoBehaviour
{
    public CharacterController controller3;
    public Animator animator;

    public int attackSweetSpotDamage = 10;
    public int splashDamage = 5;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    float lastTap = 0f;

    public float hitboxStartTime = 0.5f;
    public float hitboxEndTime = 0.7f;
    public float startAnimationTime = 0f;
    public float splashLength = 0.1f;

    public Transform SlamAttackHitboxSweetSpot;
    public Transform SlamSplashDamageHitbox1;
    public Transform SlamSplashDamageHitbox2;
    public Transform SlamSplashDamageHitbox3;
    public float attackRange = 0.5f;
    public float splashRange = 0.5f;
    public LayerMask enemyLayers;

    ArrayList alreadyHit = new ArrayList();


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

                    startAnimationTime = Time.time;
                }
            }
        }

        if (Time.time > 0.8f && Time.time >= startAnimationTime + hitboxStartTime && Time.time <= startAnimationTime + hitboxEndTime)
        {
            //detect enemies
            Collider[] hitenemies = Physics.OverlapSphere(SlamAttackHitboxSweetSpot.position, attackRange, enemyLayers);

            //damage enemies
            doDamage(hitenemies, attackSweetSpotDamage);

        }//checks if the current time is during when we want the hitbox to be active

        if (Time.time > 0.8f && Time.time >= startAnimationTime + hitboxEndTime && Time.time <= startAnimationTime + hitboxEndTime + splashLength)
        {
            //detects enemies for each splash damage hitbox
            Collider[] hitBySplash1 = Physics.OverlapSphere(SlamSplashDamageHitbox1.position, splashRange, enemyLayers);
            Collider[] hitBySplash2 = Physics.OverlapSphere(SlamSplashDamageHitbox2.position, splashRange, enemyLayers);
            Collider[] hitBySplash3 = Physics.OverlapSphere(SlamSplashDamageHitbox3.position, splashRange, enemyLayers);

            Collider[] hitBySplashTotal = hitBySplash1.Concat(hitBySplash2.Concat(hitBySplash3)).ToArray();

            //goes through and damages each enemy based on which hitbox hit
            doDamage(hitBySplashTotal, splashDamage);
        }

        if (Time.time > startAnimationTime + hitboxEndTime + splashLength)//if the animation is over, the array is emptied
        {
            alreadyHit.Clear();
        }
    }

    void doSlam()
    {
        if (lastTap + 0.5f <= Time.time)
        {
            animator.SetTrigger("Slam");
            lastTap = Time.time;
        }
    }

    void doDamage(Collider[] hitenemies, int attackDamage)
    {
        foreach (var enemy in hitenemies)
        {
            if (!alreadyHit.Contains(enemy))
            {
                enemy.GetComponent<HealthScript>().TakeDamage(attackDamage);
                Debug.Log("We hit " + enemy.name + " with " + attackDamage + " power. They have " + 
                    enemy.GetComponent<HealthScript>().getHealth() + " health left");

                alreadyHit.Add(enemy);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (SlamAttackHitboxSweetSpot == null)
        {
            return;
        }

        if (SlamSplashDamageHitbox1 == null)
        {
            return;
        }
        if (SlamSplashDamageHitbox2 == null)
        {
            return;
        }
        if (SlamSplashDamageHitbox3 == null)
        {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(SlamAttackHitboxSweetSpot.position, attackRange);

        Gizmos.DrawWireSphere(SlamSplashDamageHitbox1.position, splashRange);
        Gizmos.DrawWireSphere(SlamSplashDamageHitbox2.position, splashRange);
        Gizmos.DrawWireSphere(SlamSplashDamageHitbox3.position, splashRange);
    }
}
