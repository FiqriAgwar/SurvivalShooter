using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    Animator anim;
    public Text warningText;

    void Awake(){
        anim = GetComponent<Animator>();
    }

    void Update(){
        if (playerHealth.currentHealth <= 0){
            anim.SetTrigger("GameOver");
        }
    }

    public void ShowWarning(float enemyDistance){
        warningText.text = string.Format("! {0} m !", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }
}