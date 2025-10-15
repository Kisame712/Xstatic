using UnityEngine;

public class SFXSoundPlayer : MonoBehaviour
{
    public static SFXSoundPlayer Instance { private set; get; }
    AudioSource audioSource;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of EffectSoundManager" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void PlaySoundEffect(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
