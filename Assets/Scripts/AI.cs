using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour
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
    private int ammoAmount;

    //Reload
    private float maxTime;
    private float reloadTime;
    private bool reloadActive = false;

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
        ammoAmount = 6;

        //Reload
        maxTime = 3;
        reloadTime = maxTime;

        //Audio
        m_shootingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Reload
        if (reloadActive == true)
        {
            reloadTime = reloadTime - Time.deltaTime;
        }
        else if (reloadTime <= 0)
        {
            reloadActive = false;
            reloadTime = maxTime;

            Reload();
        }

        if (EnemyHealth.isDie == true)
        {
            var obj = GameObject.FindGameObjectWithTag("EnemyTorso");
            obj.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else if (EnemyHealth.isDie == false)
        {
            if(ammoAmount == 0)
            {
                reloadActive = true;
            }
            else if(ammoAmount > 0)
            {
                if (Time.time > ReadyforNextShot)
                {
                    ReadyforNextShot = Time.time + 1/fireRate;
                    Fire();
                    m_shootingSound.Play();
                }
            }
        }
    }

    void Fire()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        ammoAmount -= 1;
        if (!_isFlashing)
        {
            StartCoroutine(DoFlash());
        }
    }

    void Reload()
    {
        ammoAmount = 6;
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
