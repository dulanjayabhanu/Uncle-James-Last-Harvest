using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletShooter : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform firePoint;
    public Transform muzzleFlashPoint;
    public float bulletForce = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                BulletShoot();
            }
        }
    }

    void BulletShoot()
    {
        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, muzzleFlashPoint.position, muzzleFlashPrefab.transform.rotation);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(firePoint.forward * 14f, ForceMode.Impulse);

        audioSource.PlayOneShot(audioClip);

        // bullet destroy
        Destroy(bullet, 0.3f);
        // muzzle flash destroy
        Destroy(muzzleFlash, 0.1f);
    }
}
