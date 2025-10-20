using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private int damageAmount;
    [SerializeField] private float cooldownTimer;
    private HealthSystem healthSystem;
    private Rigidbody enemyRb;
    private Animator enemyAnim;
    private PlayerMovement player;

    private bool playerHit = false;
    private float nextAttackTime;
    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        float followRange = 5f;
        if(Vector3.Distance(transform.position, player.transform.position) < followRange)
        {
            enemyAnim.SetBool("isAttacking", true);
            navMeshAgent.SetDestination(player.transform.position);

            float attackRange = 0.5f;
            if (Vector3.Distance(transform.position, player.transform.position) < attackRange && !playerHit)
            {
                AttackPlayer();
                playerHit = true;
            }
        }
        else
        {
            enemyAnim.SetBool("isAttacking", false);
        }

        nextAttackTime += Time.deltaTime;
        if(nextAttackTime > cooldownTimer)
        {
            nextAttackTime = 0f;
            playerHit = false;
        }
    }

    public HealthSystem GetEnemyHealthSystem()
    {
        return healthSystem;
    }

    public void AttackPlayer()
    {
        if(player.TryGetComponent<HealthSystem>(out HealthSystem playerHealthSystem))
        {
            playerHealthSystem.TakeDamage(damageAmount, true);
        }
    }
}
