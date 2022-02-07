using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeDelay = 1f;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] float audioVolume = .5f;

    AudioSource audioSourcePlayer;
    private void Start()
    {
        audioSourcePlayer = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log(other.gameObject.tag);
                break;
            case "Finish":
                Debug.Log(other.gameObject.tag);
                SuccessSequence();
                break;
            default:
                Debug.Log("default: " + other.gameObject.tag);
                CrashSequence();
                break;
        }
    }

    private void SuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        audioSourcePlayer.PlayOneShot(successAudio, audioVolume);
        Invoke("LoadNextLevel", invokeDelay);
    }

    void CrashSequence()
    {
        audioSourcePlayer.PlayOneShot(crashAudio, audioVolume);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", invokeDelay);
    }
    private void ReloadLevel()
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
