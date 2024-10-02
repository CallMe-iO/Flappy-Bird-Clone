using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Referensi Rigidbody2D burung
    private Rigidbody2D rb;

    // Besarnya gaya lompatan
    public float jumpForce = 5f;

    // Menyimpan status apakah burung sudah mati atau tidak
    private bool isDead = false;

    // Inisialisasi
    void Start()
    {
        // Mengambil komponen Rigidbody2D yang ada di burung
        rb = GetComponent<Rigidbody2D>();
    }

    // Update dipanggil sekali per frame
    void Update()
    {
        // Cek apakah burung sudah mati
        if (isDead)
            return;

        // Jika pemain menekan tombol space atau klik pada layar, burung melompat
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Reset kecepatan vertikal menjadi 0 sebelum memberikan gaya lompatan
            rb.velocity = Vector2.zero;

            // Tambahkan gaya lompatan ke Rigidbody2D agar burung "melompat"
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Metode ini dipanggil jika burung bertabrakan dengan sesuatu
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Pipe"))
        {
            // Hentikan game ketika burung menabrak pipa

            Time.timeScale = 0; // Menghentikan semua aktivitas game
                                // Tampilkan Game Over UI atau lakukan tindakan lain

            // Set burung menjadi mati jika terjadi tabrakan
            isDead = true;
        }

        // Ketika burung mati, Anda bisa menambahkan logika seperti menampilkan layar Game Over
        // Contoh: Debug.Log("Game Over");
    }
}
