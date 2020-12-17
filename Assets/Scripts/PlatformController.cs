using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] Platforms;
    public GameObject[] prefabPlatforms;

    void Update()
    {
        for (int i = 0; i < Platforms.Length; i++)
        {
            if (Platforms[i] == null)
            {
                if (i != 0)
                {
                    Platforms[i] = Instantiate(prefabPlatforms[Random.Range(0, 6)], new Vector3(0, 0, Platforms[i - 1].transform.position.z + 49.9f), Platforms[i-1].transform.rotation);
                }
                else
                {
                    Platforms[i] = Instantiate(prefabPlatforms[Random.Range(0, 6)], new Vector3(0, 0, Platforms[3].transform.position.z + 49.9f), Platforms[3].transform.rotation);
                }
            }
        }
    }


}