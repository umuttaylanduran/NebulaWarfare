using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AuidoPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 0.5f;


    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 0.5f;

    static AuidoPlayer instance;  //? bu scriptin bir örneğini oluşturuyoruz.Bu maviyle yazılanlar singleton yapısıdır farklı yolla nasıl yapılır onunla ilgili bilgi veriyoruz.
  
    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {

        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }                               //?Bu ilf else bölümü de ikinci örnek iki türlüde doğru hangi yoldan yaparsan yap.
        else
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        //! int instanceCount = FindObjectsOfType(GetType()).Length; //! GetType() returns the exact runtime type of the current instance 
        // //! ses oynatıcımızın kaç örneği olduğunu buluyoruz.
        //! if (instanceCount > 1)
        //! {
        //!     gameObject.SetActive(false); //! eğer birden fazla örneği varsa bu örneği pasif hale getiriyoruz. Bu sayede sadece bir tane ses oynatıcımız olacak.
        // !    Destroy(gameObject); //! eğer birden fazla örneği varsa bu örneği yok ediyoruz. Bu sayede sadece bir tane ses oynatıcımız olacak.
        //! }
        //! else
        // !{
        //  !   DontDestroyOnLoad(gameObject); //! eğer bir tane örneği varsa bu örneği yok etmiyoruz. bu sayede diğer sahnelere aynı sesi iletiyopruz.
        // !}
     
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }

    }
}
