using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeDelay = 1f;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] float audioVolume = .5f;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;


    AudioSource audioSourcePlayer;

    bool isLoading = false;
    bool isCrashOn = true;
    void Start()
    {
        audioSourcePlayer = GetComponent<AudioSource>();
    }
    void Update()
    {
        Cheat();
    }
    void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCrash();
        }
    }
    void ToggleCrash()
    {
        isCrashOn = !isCrashOn;
    }
    void OnCollisionEnter(Collision other)
    {
        if (isLoading) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                if (isCrashOn)
                { CrashSequence(); }
                break;
        }
    }

    void SuccessSequence()
    {
        isLoading = true;
        GetComponent<Movement>().enabled = false;
        audioSourcePlayer.Stop();
        audioSourcePlayer.PlayOneShot(successAudio, audioVolume);
        successParticles.Play();
        Invoke("LoadNextLevel", invokeDelay);
    }

    void CrashSequence()
    {
        isLoading = true;
        audioSourcePlayer.Stop();
        audioSourcePlayer.PlayOneShot(crashAudio, audioVolume);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", invokeDelay);
    }
    void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
    void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        if (SceneManager.sceneCountInBuildSettings == nextLevelIndex)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }
}
