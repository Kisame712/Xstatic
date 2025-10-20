using UnityEngine;
using System.Collections.Generic;


public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;
    [SerializeField] private GameObject player;
    public static CheckpointManager Instance { private set; get; }

    private List<Transform> checkpointList;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of CheckPointManager");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        checkpointList = new List<Transform>();

        foreach(Transform checkpointTransform in transform)
        {
            checkpointList.Add(checkpointTransform);
        }

        Checkpoint firstCheckPoint = checkpointList[0].GetComponent<Checkpoint>();
        respawnPosition = firstCheckPoint.GetRespawnPosition();
    }

    public void RespawnPlayer()
    {
        player.transform.position = respawnPosition.position;
        HealthSystem playerHealthSystem = player.GetComponent<HealthSystem>();
        playerHealthSystem.RestoreHP();
    }

    public void SetRespawnPosition(Transform respawnPosition)
    {
        this.respawnPosition = respawnPosition;
    }

}
