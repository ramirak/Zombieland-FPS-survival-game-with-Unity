using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    private AudioSource siren;
    public static int maxZombies, maxCleaners, level;
    private const int initNumZombies = 16, initNumCleaners = 10;
    public static int zombiesLeft, cleanersLeft;
    private float maxDistance = 150;
    public List<NavMeshAgent> allZombies;
    public List<NavMeshAgent> allCleaners;
    public List<NavMeshAgent> allAllies;

    public GameObject zombieObject, cleanerObject, ally1Object, ally2Object;
    private NavMeshAgent zombie, cleaner; // Are going to be spawned continusly..
    public GameObject center, enemySpawnLocation;
    public Text wavesText;
    private bool started = false, zombieRoutine = false, cleanersRoutine = false, timerRoutine = false;
    void Start()
    {
        allZombies = new List<NavMeshAgent>();
        allCleaners = new List<NavMeshAgent>();
        siren = GetComponent<AudioSource>();
        zombie = zombieObject.GetComponent<NavMeshAgent>();
        cleaner = cleanerObject.GetComponent<NavMeshAgent>();
        maxZombies = initNumZombies;
        maxCleaners = initNumCleaners;
        zombiesLeft = 0;
        cleanersLeft = 0;
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (!timerRoutine)
                wavesText.text = "Wave " + level + "\nEnemies left " + cleanersLeft;
            if (zombiesLeft < maxZombies && !zombieRoutine) // Keep zombies count the same during each level.
            {
                zombieRoutine = true;
                StartCoroutine(spawnZombie());
            }
            if (cleanersLeft == 0 && !cleanersRoutine) // The level is cleared, advance to next level.
            {
                maxCleaners = initNumCleaners + level * 2;
                maxZombies = initNumZombies + level * 2;
                level++;
                cleanersRoutine = true;
                StartCoroutine(spawnCleaners());
            }
            removeDeads();
            ally1Object.SetActive(true);
            ally2Object.SetActive(true);
        }
    }
    IEnumerator timer(float seconds)
    {
        timerRoutine = true;
        for (float i = seconds; i >= 0; i--)
        {
            wavesText.text = "Time until next wave " + i;
            yield return new WaitForSeconds(1f);
        }
        timerRoutine = false;
        siren.Play();
    }
    IEnumerator spawnCleaners()
    {
        float seconds;
        if (level <= 1)
            seconds = -1;
        else
            seconds = 60;

        StartCoroutine(timer(seconds));
        yield return new WaitForSeconds(seconds);

        for (int i = 0; i < maxCleaners; i++)
        {
            float directionFacing = Random.Range(0f, 360f);
            NavMeshAgent aCleaner = Instantiate(cleaner, getRandomDestination(enemySpawnLocation), Quaternion.Euler(new Vector3(0f, directionFacing, 0f)));
            aCleaner.gameObject.active = true;
            allCleaners.Add(aCleaner);
            cleanersLeft++;
        }
        cleanersRoutine = false;
    }

    IEnumerator spawnZombie()
    {
        yield return new WaitForSeconds(0.3f);
        float directionFacing = Random.Range(0f, 360f);
        NavMeshAgent aZombie = Instantiate(zombie, getRandomDestination(center), Quaternion.Euler(new Vector3(0f, directionFacing, 0f)));
        aZombie.gameObject.active = true;
        allZombies.Add(aZombie);
        zombiesLeft++;
        zombieRoutine = false;
    }

    Vector3 getRandomDestination(GameObject spawnLocation)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + spawnLocation.transform.position;
        NavMeshHit hit; // NavMesh Sampling Info Container
        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
        Vector3 vector = new Vector3(hit.position.x, hit.position.y, hit.position.z);
        return vector; // or return hit.position where y is random
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !started)
        {
            started = true;
        }
    }

    void removeDeads()
    {

        for (int i = allZombies.Count - 1; i >= 0; i--)
        {
            if (!allZombies[i].enabled)
            {
                allZombies.RemoveAt(i);
                zombiesLeft--;
            }
        }

        for (int i = allCleaners.Count - 1; i >= 0; i--)
        {
            if (!allCleaners[i].enabled)
            {
                allCleaners.RemoveAt(i);
                cleanersLeft--;
            }
        }

        for (int i = allAllies.Count - 1; i >= 0; i--)
        {
            if (!allAllies[i].enabled)
                allAllies.RemoveAt(i);
        }
    }

}