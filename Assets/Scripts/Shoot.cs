using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    //Gun
    public Transform Gun;
    Vector2 direction;
    //Barrel
    public Transform ShootPoint;

    //Bullet
    public GameObject Bullet;
    public float BulletSpeed;

    //Ammo
    [SerializeField]
    private GameObject[] ammo;

    private int ammoAmount;

    //FireRate
    public float fireRate;
    float ReadyforNextShot;

    //MuzzleFlash
    public GameObject MuzzleFlash;
    [Range(0, 5)]
    public int FramesToFlash = 1;
    bool _isFlashing = false;

    //Audio
    AudioSource m_shootingSound;

    void Start()
    {
        //Ammo
        for (int i = 0; i <= 5; i++)
        {
            ammo[i].gameObject.SetActive(true);
        }
        ammoAmount = 6;

        //Audio
        m_shootingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerHealth.isDie == true)
        {
            var obj = GameObject.FindGameObjectWithTag("PlayerTorso");
            obj.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else if(PlayerHealth.isDie == false)
        {
            //Follow Mouse
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePos - (Vector2)Gun.position;
            FaceMouse();

            //Shoot
            if (Input.GetButtonDown("Fire1") && ammoAmount > 0)
            {
                if (Time.time > ReadyforNextShot)
                {
                    ReadyforNextShot = Time.time + 1 / fireRate;
                    Fire();
                    m_shootingSound.Play();
                }
            }
            else if (Input.GetButtonDown("Fire1") && ammoAmount == 0)
            {
                var obj = GameObject.FindGameObjectWithTag("NoAmmo");
                obj.GetComponent<AudioSource>().Play();
            }
        }
    }

    void FaceMouse()
    {
        Gun.transform.right = direction;
    }

    void Fire()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        ammoAmount -= 1;
        ammo[ammoAmount].gameObject.SetActive(false);
        if (!_isFlashing)
        {
            StartCoroutine(DoFlash());
        }
    }

    IEnumerator DoFlash()
    {
        MuzzleFlash.SetActive(true);
        var framesFlashed = 0;
        _isFlashing = true;

        while (framesFlashed <= FramesToFlash)
        {
            framesFlashed++;
            yield return null;
        }

        MuzzleFlash.SetActive(false);
        _isFlashing = false;
    }
}
