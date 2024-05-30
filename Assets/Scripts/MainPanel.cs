using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Options")]
    public Slider volumen;
    public AudioMixer mixer;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene("Vector_velocity_personaje 1");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        // Cierra la aplicación
        Application.Quit();

        // Si estás en el editor de Unity, esta línea es útil para detener el modo de juego
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Awake()
    {
        volumen.onValueChanged.AddListener(ChangeVolumen);
    }

    public void OpenPanel(GameObject panel) {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);

        panel.SetActive(true);
    }

    public void ChangeVolumen(float v) {
        mixer.SetFloat("Volumen", v);
    }


}
