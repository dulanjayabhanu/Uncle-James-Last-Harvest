using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BulletShooter : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform firePoint;
    public Transform muzzleFlashPoint;
    public float bulletForce = 0.2f;

    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;
    public GameObject damagePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (!UserClickEventValidate())
            {
                BulletShoot();
            }
        }
    }

    bool UserClickEventValidate()
    {
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject != damagePanel && !IsChildOfDamageIndicator(result.gameObject, damagePanel))
            {
                return true;
            }
        }

        return false;
    }

    bool IsChildOfDamageIndicator(GameObject targetObject, GameObject potentialParent)
    {
        Transform targetTransform = targetObject.transform;
        
        while (targetTransform != null)
        {
            if (targetTransform.gameObject == potentialParent)
            { 
                return true;
            } 

            targetTransform = targetTransform.parent;
        }

        return false;
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
