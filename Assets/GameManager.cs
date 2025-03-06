using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int vidas = 3;
    private int score;
    private int mae = 0;
    public GUISkin layout;
    private int cena = 2;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
    }

    void OnGUI()
    {
        switch(SceneManager.GetActiveScene().name)
        {
        case "Ganhou":
            cena = 3;
            break;
        case "Perdeu":
            cena = 2;
            break;
        default:
            cena = 1;
            break;
        }
        // GUI Vidas
        if(cena == 1)// Jogo normal
        {
            GUI.skin = layout;
            GUI.skin.label.fontSize = 30;
            Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent("Vidas"));
            GUI.Label(new Rect(30, Screen.height-label1.y-40, label1.x, label1.y), "Vidas");

            GUI.skin.label.fontSize = 30;
            Vector2 LVidas = GUI.skin.label.CalcSize(new GUIContent(vidas.ToString()));
            GUI.Label(new Rect(60, Screen.height-LVidas.y-10, LVidas.x, LVidas.y), vidas.ToString());

            // GUI score
            GUI.skin.label.fontSize = 30;
            Vector2 label2 = GUI.skin.label.CalcSize(new GUIContent("Pontuação"));
            GUI.Label(new Rect(10, 10, label2.x+10, label2.y), "Pontuação");

            GUI.skin.label.fontSize = 30;
            Vector2 LScore = GUI.skin.label.CalcSize(new GUIContent(score.ToString()));
            GUI.Label(new Rect(85-(LScore.x/2), 40, LScore.x+10, LScore.y), score.ToString());
        }
        else if(cena == 2)// perdeu
        {
            GUI.skin = layout;
            GUI.skin.label.fontSize = 50;
            Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent("Fim de Jogo"));
            GUI.Label(new Rect((Screen.width-label1.x)/2, (Screen.height-label1.y)/2-30, label1.x+5, label1.y), "Fim de Jogo");

            GUI.skin.label.fontSize = 30;
            Vector2 LScore = GUI.skin.label.CalcSize(new GUIContent("Sua pontuação foi "+score.ToString()));
            GUI.Label(new Rect((Screen.width-LScore.x)/2, (Screen.height-LScore.y)/2+20, LScore.x+5, LScore.y), "Sua pontuação foi "+score.ToString());

            GUI.skin.label.fontSize = 10;
            Vector2 label2 = GUI.skin.label.CalcSize(new GUIContent("Aperte espaço para recomeçar"));
            GUI.Label(new Rect((Screen.width-label2.x)/2, (Screen.height-label2.y)/2+70, label2.x+5, label2.y), "Aperte espaço para recomeçar");
        }
        else if(cena == 3)// ganhou
        {
            GUI.skin = layout;
            GUI.skin.label.fontSize = 50;
            Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent("Vitória!"));
            GUI.Label(new Rect((Screen.width-label1.x)/2, (Screen.height-label1.y)/2-30, label1.x+5, label1.y), "Vitória");

            GUI.skin.label.fontSize = 30;
            Vector2 LScore = GUI.skin.label.CalcSize(new GUIContent("Sua pontuação final foi de "+score.ToString()));
            GUI.Label(new Rect((Screen.width-LScore.x)/2, (Screen.height-LScore.y)/2+20, LScore.x+5, LScore.y), "Sua pontuação final foi de "+score.ToString());

            GUI.skin.label.fontSize = 10;
            Vector2 label2 = GUI.skin.label.CalcSize(new GUIContent("Aperte espaço para recomeçar"));
            GUI.Label(new Rect((Screen.width-label2.x)/2, (Screen.height-label2.y)/2+70, label2.x+5, label2.y), "Aperte espaço para recomeçar");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cena == 1)
        {
            GameObject refPlayer = GameObject.Find("Nave");
            PlayerControll player = refPlayer.GetComponent<PlayerControll>();
            vidas = player.vidas;
            GameObject[] bots = GameObject.FindGameObjectsWithTag("Bot");
            score = (14-bots.Length)*20+mae;
            if(mae == 0 && GameObject.Find("Mae") == null){
                mae = 100;
            }
            if(vidas == 0)
            {
                cena = 2;
                SceneManager.LoadScene("Perdeu");
                PlayerPrefs.SetInt("score", score); // Salva o valor de "score"
                PlayerPrefs.Save();
            }
            else if(bots.Length == 0)
            {
                cena = 3;
                SceneManager.LoadScene("Ganhou");
                PlayerPrefs.SetInt("score", score); // Salva o valor de "score"
                PlayerPrefs.Save();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                score = 0;
                vidas = 3;
                SceneManager.LoadScene("Jogo");
            }
        }
    }
}
