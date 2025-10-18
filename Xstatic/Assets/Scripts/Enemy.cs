using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    private HealthSystem healthSystem;
    private Rigidbody enemyRb;
    private Animator enemyAnim;
    private PlayerMovement player;
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
        float attackRange = 5f;
        if(Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            enemyAnim.SetBool("isAttacking", true);
            navMeshAgent.SetDestination(player.transform.position);
        }
        else
        {
            enemyAnim.SetBool("isAttacking", false);
        }
    }

    public HealthSystem GetEnemyHealthSystem()
    {
        return healthSystem;
    }
}
