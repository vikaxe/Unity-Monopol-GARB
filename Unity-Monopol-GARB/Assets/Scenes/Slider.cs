using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Slider : MonoBehaviour
{
    public string scennName;

    [SerializeField] private TextMeshProUGUI text = null;


    public void SliderChange(float value)
    {
        float localValue = value;
        text.text = localValue.ToString("0");
    }

    public void changeScene()
    {
        SceneManager.LoadScene(scennName);
    }



    

}
