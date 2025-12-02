using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource audioSource;
    public static AudioClip coinGain;
    public static AudioClip coinThrow;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        coinGain = Resources.Load<AudioClip>("PickCoin");
        coinThrow = Resources.Load<AudioClip>("ThrowCoin");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void GetCoin()
    {
        audioSource.PlayOneShot(coinGain);
    }
    public static void ThrowCoin()
    {
        audioSource.PlayOneShot(coinThrow);
    }
}
