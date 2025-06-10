using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private BootStrapper _bootStrapper;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _minusButton;
    [SerializeField] private Button _plusButton;
    [SerializeField] private Text _numberText;
    [SerializeField] private GameObject[] _objects;
    private void Start()
    {

        _numberText.text = NumberObject().ToString();
        _minusButton.onClick.AddListener(MinusObject);
        _plusButton.onClick.AddListener(PlusObject);
        _startButton.onClick.AddListener(StartApp);
    }
    private void MinusObject()
    {
        if(NumberObject() > 0)
        {
            _objects[NumberObject() - 1].gameObject.SetActive(false);
            _numberText.text = NumberObject().ToString();
        }
    }
    private void PlusObject()
    {
        if(NumberObject() < _objects.Length)
        {
            _objects[NumberObject()].gameObject.SetActive(true);
            _numberText.text = NumberObject().ToString();
        }
    }
    private int NumberObject()
    {
        int number = 0;
        for (int i = 0; i < _objects.Length; i++)
        {
            if(_objects[i].activeSelf)
            {
                number++;
                number = Mathf.Clamp(number, 1, _objects.Length);
            }
        }
        return number;
    }
    private void StartApp()
    {
        _bootStrapper.Init();
        gameObject.SetActive(false);
    }
}
