using UnityEngine;


// 최상위 캔버스에 컴포넌트로 넣어주기!
public class LSH_ButtonEvent : MonoBehaviour
{

    [SerializeField] GameObject menuCanvas1;
    [SerializeField] GameObject menuCanvas2;
    [SerializeField] GameObject menuCanvas3;
    [SerializeField] GameObject menuCanvas4;
    [SerializeField] GameObject menuCanvas5;


    private void Start()
    {
        menuCanvas1.SetActive(true);
        menuCanvas2.SetActive(false);
        menuCanvas3.SetActive(false);
        menuCanvas4.SetActive(false);
        menuCanvas5.SetActive(false);
    }




    public void ClickBtn1()
    {
        menuCanvas1.SetActive(true);
        menuCanvas2.SetActive(false);
        menuCanvas3.SetActive(false);
        menuCanvas4.SetActive(false);
        menuCanvas5.SetActive(false);
    }

    public void ClickBtn2()
    {
        menuCanvas1.SetActive(false);
        menuCanvas2.SetActive(true);
        menuCanvas3.SetActive(false);
        menuCanvas4.SetActive(false);
        menuCanvas5.SetActive(false);
    }

    public void ClickBtn3()
    {
        menuCanvas1.SetActive(false);
        menuCanvas2.SetActive(false);
        menuCanvas3.SetActive(true);
        menuCanvas4.SetActive(false);
        menuCanvas5.SetActive(false);
    }

    public void ClickBtn4()
    {
        menuCanvas1.SetActive(false);
        menuCanvas2.SetActive(false);
        menuCanvas3.SetActive(false);
        menuCanvas4.SetActive(true);
        menuCanvas5.SetActive(false);
    }

    public void ClickBtn5()
    {
        menuCanvas1.SetActive(false);
        menuCanvas2.SetActive(false);
        menuCanvas3.SetActive(false);
        menuCanvas4.SetActive(false);
        menuCanvas5.SetActive(true);
    }


}
