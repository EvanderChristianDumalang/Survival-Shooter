using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public abstract void Awake();
    public abstract void OnTriggerEnter(Collider other);
}
