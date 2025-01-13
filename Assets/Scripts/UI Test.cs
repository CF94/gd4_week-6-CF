using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UITest : MonoBehaviour
{
    public Slider slider;
    public Toggle toggle;
    public TMP_InputField inputField;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = slider.value;
        //GetComponent<AudioSource>().enabled = toggle.isOn;
    }
    public void displayText()
    {
        Debug.Log(inputField.text);
    }
}
