using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoSingleton<LoadingManager>
{
    [SerializeField] private GameObject root;

    public void ShowLoading()
    {
        root.SetActive(true);
    }

    public void HideLoading()
    {
        root.SetActive(false);
    }
}
