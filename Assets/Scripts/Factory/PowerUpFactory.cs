using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    public GameObject[] powerUp;
    public Transform[] spawnPoints;

    public GameObject FactoryMethod(int tag)
    {
        int powerUpIdx = Random.Range(0, 2);
        GameObject powerUpObject = Instantiate(powerUp[powerUpIdx], spawnPoints[tag].position, spawnPoints[tag].rotation);
        return powerUpObject;
    }
}
