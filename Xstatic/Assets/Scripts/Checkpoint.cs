using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;

    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public Transform GetRespawnPosition()
    {
        return respawnPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            boxCollider.enabled = false;
            CheckpointManager.Instance.SetRespawnPosition(respawnPosition);
        }
    }
}
