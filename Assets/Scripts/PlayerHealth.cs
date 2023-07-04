using SceneChangerNS;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerHealthNS
{
    public class PlayerHealth : MonoBehaviour
    {
        private GameObject[] Health = new GameObject[3] ;
        [SerializeField] private float invincibleTime = 2f;
        [SerializeField] private GameObject pause;
        [SerializeField] private GameObject dieMenu;
        public static int HealthNow;
        private SpriteRenderer spriteRenderer;
        public bool isInvincible = false;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            for (int i = 0; i < 3; i++)
            {
                Health[i] = GameObject.Find($"Small Heart {i + 1}");
            }
            HealthNow = 3;


        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("CannonBall"))
            {

                TakeDamage();

            }
            if (collision.gameObject.CompareTag("BigHeart"))
            {
                if (HealthNow < 3)
                {

                    Health[HealthNow++].SetActive(true);
                    Destroy(collision.gameObject);
                }
            }



        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Bomb"))
            {
                TakeDamage();
            }
            

        }

        public void TakeDamage()
        {
            if (!isInvincible && HealthNow != 0) // если юнит не находитс€ в режиме неу€звимости
            {
                StartCoroutine(ChangeColor());
                HealthNow--; // отнимаем здоровье
                Health[HealthNow].SetActive(false);
                if (HealthNow <= 0) // если здоровье закончилось
                {
                    Die(); // вызываем метод смерти
                }
                else // иначе
                {
                     // переводим юнита в режим неу€звимости
                    StartInvincible(); // запускаем корутину неу€звимости
                }
            }
        }
        public void StartInvincible()
        {
            isInvincible = true;
            StartCoroutine(InvincibleCoroutine());
        }


        private IEnumerator InvincibleCoroutine()
        {
            yield return new WaitForSeconds(invincibleTime); // ждем указанное врем€
            isInvincible = false; // переводим юнита в обычный режим
        }
        private IEnumerator ChangeColor()
        {
            spriteRenderer.color = new Color32(255,185, 185, 255);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color32(255, 255, 255, 255);

        }



        private void Die()
        {
            pause.SetActive(false);
            dieMenu.SetActive(true);
            Time.timeScale = 0;

        }

        public void ContinueClick()
        {
            StartInvincible();
            foreach (var item in Health)
            {
                item.SetActive(true);
            }
            HealthNow = 3;
            pause.SetActive(true);
            dieMenu.SetActive(false);
            Time.timeScale = 1;
            
        }

        public void RestartClick()
        {
            pause.SetActive(true);
            dieMenu.SetActive(false);
            Time.timeScale = 1;
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }

        public void MainMenuClick()
        {
            pause.SetActive(true);
            dieMenu.SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }


    }

}
