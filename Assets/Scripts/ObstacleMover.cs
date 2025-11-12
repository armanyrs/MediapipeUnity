using UnityEngine;
public class ObstacleMover : MonoBehaviour
{
    public float speed = 3f;
    public float destroyX = -10f; // posisi X ketika obstacle akan dihancurkan

void Update()
    {
        // Gerakkan obstacle ke kiri
        transform.position += Vector3.left * speed * Time.deltaTime;
        // Jika sudah lewat layar kiri, hapus obstacle

    if (transform.position.x < destroyX)
            {
                Destroy(gameObject);
            }
        }
}