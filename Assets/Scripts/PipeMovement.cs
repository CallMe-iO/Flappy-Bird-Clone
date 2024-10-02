using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pipa bergerak

    void Update()
    {
        // Menggerakkan pipa ke kiri
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Menghancurkan pipa jika sudah keluar dari layar
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
