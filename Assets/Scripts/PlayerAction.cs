using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerAction : MonoBehaviour
{
    private float hp, armor, coins;
    private bool dead = false, beginRecovery = false, recoveryRoutine = false, gotHit = false, isMelee = false;

    public bool buyMode = false;

    //private int[] weaponAccuracy = { 6, 8, 7, 7, 10 };
    //private int accuracyDropsAfter = 20;

    private int activeWeaponIndex = 0, // only owned weapons indexes
    activeGunIndex = 0,
    activeMeleeIndex = 0;
    public GameObject aCamera, bullet, enemyBullet;

    public GameObject[] muzzleFlash = new GameObject[5];
    public GameObject[] gunsObjects = new GameObject[5];
    public GameObject[] meleeObjects = new GameObject[1];
    public GameObject[] weaponsObjects; // changed based on the attack mode
    private Weapon[] gunsProps = new Weapon[5];
    private Weapon[] meleeProps = new Weapon[1];

    private AudioSource weaponAudio;
    public AudioSource outOfAmmo;
    public Text ammoText, coinsText, hpText, vestText;
    public Animator handAnim;
    public GameObject info, blood;

    // Start is called before the first frame update
    void Start()
    {
        this.hp = 100f;
        this.armor = 0f;
        this.coins = 2000f;
        weaponsObjects = gunsObjects;
        initWeapons();
        ammoMessage();

    }
    void initWeapons()
    {
        gunsProps[0] = new Weapon(true, false, 50, 25, 0, 40, "Handgun", 500);
        gunsProps[1] = new Weapon(false, false, 15, 6, 0, 80, "Shotgun", 1500);
        gunsProps[2] = new Weapon(false, false, 90, 8, 0, 45, "Assault", 3500);
        gunsProps[3] = new Weapon(false, false, 20, 8, 0, 30, "Pistol", 700);
        gunsProps[4] = new Weapon(false, false, 9, 4, 0, 100, "Sniper", 5000);
    }


    void Update()
    {

        manageHealth();
        updateStats();
        if (!buyMode)
        {
            showInfo();
            changeAttackMode();
            chooseWeapon();
            shoot();
        }
        if (!recoveryRoutine) // if routine not running
            StartCoroutine(recovery()); // recover if found some cover ..

    }
    void changeAttackMode()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isMelee)
            {
                isMelee = false;
                weaponsObjects = gunsObjects;
                activeMeleeIndex = activeWeaponIndex;
                activeWeaponIndex = activeGunIndex;
            }
            else
            {
                isMelee = true;
                weaponsObjects = meleeObjects;
                activeGunIndex = activeWeaponIndex;
                activeWeaponIndex = activeMeleeIndex;
            }
        }
    }
    private void ammoMessage()
    {
        if (!isMelee)
        {
            ammoText.text = gunsProps[activeWeaponIndex].getAmmoLeft() + "/" + gunsProps[activeWeaponIndex].getMaxAmmo();
        }
        else
        {
            ammoText.text = "infinity";
        }

    }

    private void chooseWeapon()
    {
        if (Input.GetKeyDown("1"))
        {
            for (int i = activeWeaponIndex - 1; i >= 0; i--)
            {
                if (checkIfOwned(i))
                {
                    activeWeaponIndex = i;
                    break;
                }
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            for (int i = activeWeaponIndex + 1; i < weaponsObjects.Length; i++)
            {
                if (checkIfOwned(i))
                {
                    activeWeaponIndex = i;
                    break;
                }
            }
        }
        activateWeapon(activeWeaponIndex);
        ammoMessage();
    }
    private bool checkIfOwned(int index)
    {
        if (isMelee)
        {
            return meleeProps[index].getIsOwned();
        }
        else
        {
            return gunsProps[index].getIsOwned();
        }
    }

    private void activateWeapon(int weaponIndex)
    {
        for (int i = 0; i < weaponsObjects.Length; i++)
        {
            if (i != weaponIndex)
                weaponsObjects[i].SetActive(false);
            else
            {
                weaponsObjects[i].SetActive(true);
                weaponAudio = weaponsObjects[i].GetComponent<AudioSource>();
            }
        }
        if (isMelee)
            disableGunObjects();
        else
            disableMeleeObjects();
    }

    private void disableMeleeObjects()
    {
        for (int i = 0; i < meleeObjects.Length; i++)
        {
            meleeObjects[i].SetActive(false);
        }
    }

    private void disableGunObjects()
    {
        for (int i = 0; i < gunsObjects.Length; i++)
        {
            gunsObjects[i].SetActive(false);
        }
    }



    private void shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (isMelee) // melee weapon
            {
                weaponAudio.Play();
                StartCoroutine(melee());
            }
            else if (gunsProps[activeWeaponIndex].getAmmoLeft() > 0)
            {
                weaponAudio.Play();
                StartCoroutine(ShowFlash());
                if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
                {
                    if (simMissRate(hit.transform.position))
                    {
                        checkTarget(hit.collider);
                        bullet.SetActive(true);
                        bullet.transform.position = hit.point;
                    }
                }
                int currentAmmo = gunsProps[activeWeaponIndex].getAmmoLeft();
                gunsProps[activeWeaponIndex].setAmmoLeft(currentAmmo - 1);
                ammoMessage();
            }
            else if (gunsProps[activeWeaponIndex].getAmmoLeft() == 0) // no ammo
            {
                outOfAmmo.Play();
            }

        }

    }

    private bool simMissRate(Vector3 target)
    {
        float distance = Vector3.Distance(this.transform.position, target);
        int missRateIncrease = gunsProps[activeWeaponIndex].getMissRateIncrease();
        if (distance < missRateIncrease)
        {
            return true;
        }
        else
        {
            float hitChance = Random.Range(0, 100);
            float missRate = gunsProps[activeWeaponIndex].getMissRate() * (distance / missRateIncrease);
            if (hitChance > missRate)
            {
                return true;
            }
            else
                return false;
        }

    }
    private void checkTarget(Collider c)
    {
        if (c.tag == "ZombieHead")
        {
            coins += 1000;
        }
        else if (c.tag == "EnemyBody")
        {
            BodyHit bh = c.GetComponent<BodyHit>();
            bh.setDmg(gunsProps[activeWeaponIndex].getDamage());
        }
        else if (c.tag == "CitizenBody")
        {
            BodyHit bh = c.GetComponent<BodyHit>();
            bh.setDmg(gunsProps[activeWeaponIndex].getDamage());
            coins -= 2000;
        }
    }
    void manageHealth()
    {
        if (hp <= 0f)
        {
            hp = 0;
            StartCoroutine(simDeath());
        }
        else if (hp < 100f)
        {
            if (beginRecovery)
                hp += 0.01f;
        }
    }
    void updateStats()
    {
        hpText.text = "health " + (int)hp;
        vestText.text = "Vest " + (int)armor;
        coinsText.text = (int)coins + " Bitcoins";
    }
    void showInfo()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (info.activeSelf)
                info.SetActive(false);
            else
                info.SetActive(true);
        }
    }

    IEnumerator melee()
    {
        handAnim.SetInteger("handMotion", 2);
        yield return new WaitForSeconds(0.5f);
        handAnim.SetInteger("handMotion", 0);
    }

    IEnumerator ShowFlash()
    {
        handAnim.SetInteger("handMotion", 1);
        muzzleFlash[activeWeaponIndex].SetActive(true);
        yield return new WaitForSeconds(0.05f);
        handAnim.SetInteger("handMotion", 0);
        muzzleFlash[activeWeaponIndex].SetActive(false);
        yield return new WaitForSeconds(0.05f);
    }

    IEnumerator simBlood()
    {
        blood.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        blood.SetActive(false);
    }

    IEnumerator simDeath()
    {
        RawImage ri = blood.GetComponent<RawImage>();
        float alpha = 1f; //1 is opaque, 0 is transparent
        Color currColor = Color.black;
        currColor.a = alpha;
        ri.color = currColor;
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = false;
        CharacterController controller = GetComponent<CharacterController>();
        controller.enabled = false;
        blood.SetActive(true);
        yield return new WaitForSeconds(5f);
        blood.SetActive(false);
        SceneManager.UnloadScene("MainScene");
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHit")
        {
            enemyBullet.SetActive(false);
            if (armor > 0)
                armor -= 10;
            else
                hp -= 10f;
            beginRecovery = false; // cannot recover if under constant attack
            gotHit = true;
            StartCoroutine(simBlood());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zombie")
        {
            hp -= 0.1f;
            beginRecovery = false; // cannot recover if under constant attack
            gotHit = true;
            StartCoroutine(simBlood());
        }
    }

    IEnumerator recovery()
    {
        recoveryRoutine = true; // routine started
        gotHit = false; // flag to check if by the end of the routine the plauer was hit..
        yield return new WaitForSeconds(5f);
        if (!gotHit)
            beginRecovery = true;
        recoveryRoutine = false; // routine ended
    }
    public float getCoins()
    {
        return coins;
    }
    public void setCoins(float coins)
    {
        this.coins = coins;
    }

    public void setVest()
    {
        this.armor = 100;
    }
    public Weapon[] getGunProps()
    {
        return gunsProps;
    }

}
