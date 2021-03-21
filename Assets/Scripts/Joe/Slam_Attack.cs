using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam_Attack : MonoBehaviour
{
    public CharacterController controller3;
    public Animator animator;

    public int attackSweetSpotDamage = 10;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    float lastTap = 0f;

    public float hitboxStartTime = 0.5f;
    public float hitboxEndTime = 0.7f;
    public float startAnimationTime = 0f;

    public Transform SlamAttackHitboxSweetSpot;
    public Transform SlamSplashDamageHitbox;
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

        if (Time.time >= startAnimationTime + hitboxStartTime && Time.time <= startAnimationTime + hitboxEndTime)
        {
            //detect enemies
            Collider[] hitenemies = Physics.OverlapSphere(SlamAttackHitboxSweetSpot.position, attackRange, enemyLayers);

            //damage enemies
            foreach (var enemy in hitenemies)
            {
                if (!alreadyHit.Contains(enemy))
                {
                    Debug.Log("We hit " + enemy.name + " with a big ol' SLAM");
                    enemy.GetComponent<HealthScript>().TakeDamage(attackSweetSpotDamage);
                    alreadyHit.Add(enemy);
                }
            }
        }//checks if the current time is during when we want the hitbox to be active

        if (Time.time > startAnimationTime + hitboxEndTime)//if the animation is over, the array is emptied
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
        Gizmos.DrawWireSphere(SlamSplashDamageHitbox.position, splashRange);
    }
}
