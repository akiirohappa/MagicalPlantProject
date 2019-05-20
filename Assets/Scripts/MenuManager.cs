using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

enum MenuMode
{
    None,
    Item,
    Shop,
    Log,
    Config,
}
public class MenuManager : MonoBehaviour
{
    public GameObject BackButton;
    [SerializeField] GameObject Shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenShop()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Shop.SetActive(true);
        Shop.GetComponent<Animator>().SetTrigger("Open");
        BackButton.SetActive(true);
    }
    public void CloseMenu()
    {
        BackButton.SetActive(false);
    }
}
