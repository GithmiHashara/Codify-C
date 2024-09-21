using UnityEngine;
using UnityEngine.UI;

public class HowToPlayManager : MonoBehaviour
{
    public GameObject slide1;
    public GameObject slide2;
    private int currentSlide = 1;

    // Start is called before the first frame update
    void Start()
    {
        slide1.SetActive(false);
        slide2.SetActive(false);
    }

    public void OnHowToPlayButtonPressed()
    {
        if (currentSlide == 1)
        {
            slide1.SetActive(true);
            slide2.SetActive(false);
        }
        else if (currentSlide == 2)
        {
            slide1.SetActive(false);
            slide2.SetActive(true);
        }
    }

    public void OnNextButtonPressed()
    {
        if (currentSlide == 1)
        {
            currentSlide = 2;
            slide1.SetActive(false);
            slide2.SetActive(true);
        }
        else
        {
            currentSlide = 1;
            slide1.SetActive(true);
            slide2.SetActive(false);
        }
    }

    public void OnCloseButtonPressed()
    {
        slide1.SetActive(false);
        slide2.SetActive(false);
        currentSlide = 1;
    }
}
