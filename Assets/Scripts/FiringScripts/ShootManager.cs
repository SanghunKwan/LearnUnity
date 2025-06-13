using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public CannonComponent[] cannons;
    public ProjectileObject[] bodys;
    public Material[] materials;
    public GameObject[] effects;

    int currentCannonIndex = 0;
    public float delayTime;
    float lastTime;


    private void Awake()
    {
        lastTime = Time.time - delayTime;
    }
    private void Update()
    {
        if (lastTime + delayTime > Time.time) return;

        ProjectileObject po = Instantiate(GetRandomComponent(bodys));
        cannons[currentCannonIndex++].Shoot(po, GetRandomComponent(materials), this);
        currentCannonIndex %= 4;
        lastTime = Time.time;

    }
    int GetRandomIndex<T>(T[] values)
    {
        return Random.Range(0, values.Length);
    }
    T GetRandomComponent<T>(T[] values)
    {
        return values[GetRandomIndex(values)];
    }
    public void CallEffect(in Vector3 vec)
    {
        GameObject ob = Instantiate(GetRandomComponent(effects), vec, Quaternion.identity);
        Destroy(ob, delayTime);
    }
}
