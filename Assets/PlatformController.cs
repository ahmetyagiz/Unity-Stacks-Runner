using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 5f; // Platformun h�z�
    public float leftLimit = -4f; // Sol s�n�r
    public float rightLimit = 4f; // Sa� s�n�r
    private bool isMoving = true;
    private Vector3 moveDirection; // Platformun hareket y�n�

    void Start()
    {
        // Platform ba�lang��ta rastgele sa�a veya sola hareket edecek
        if (Random.Range(0, 2) == 0)
        {
            moveDirection = Vector3.right; // Sa�a hareket et
        }
        else
        {
            moveDirection = Vector3.left; // Sola hareket et
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // Platformu hareket ettir
            transform.Translate(moveDirection * speed * Time.deltaTime);

            // Platform s�n�rlar� ge�ti�inde y�n de�i�tir
            if (transform.position.x >= rightLimit && moveDirection == Vector3.right)
            {
                moveDirection = Vector3.left; // Sa�a giderken sa� s�n�ra ula�t�, sola d�n
            }
            else if (transform.position.x <= leftLimit && moveDirection == Vector3.left)
            {
                moveDirection = Vector3.right; // Sola giderken sol s�n�ra ula�t�, sa�a d�n
            }
        }
    }

    public void StopPlatform()
    {
        isMoving = false;
    }
}