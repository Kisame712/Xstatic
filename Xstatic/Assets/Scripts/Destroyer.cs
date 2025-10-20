using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1f);
    }
}
