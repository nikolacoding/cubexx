using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    
    private AudioSource _audioSource;
    public AudioClip buttonPressSound;

    // Singleton implementation
    public void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }
    public void Start() {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void PlayClip(AudioClip clip) {
        _audioSource.PlayOneShot(clip);
    }

    public void PlayButtonPressSound() => PlayClip(buttonPressSound);
}
