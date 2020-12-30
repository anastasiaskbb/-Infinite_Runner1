
using UnityEngine;

public class Moving_Platforms : MonoBehaviour
{
    void Update()
    {
        if (life.lifeHero)
        {
            transform.Translate(new Vector3(15f, 0f, 0f) * Time.deltaTime);

            if (transform.position.z <= -20)
            {
                Destroy(gameObject);

            }
        }
    }
}
