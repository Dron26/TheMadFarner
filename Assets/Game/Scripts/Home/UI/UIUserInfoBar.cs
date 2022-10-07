using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUserInfoBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> _images;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _nameAvatar;

    public void SetAvatar(string imageName)
    {
        foreach (GameObject avatar in _images)
        {
            if (avatar.name == imageName)
            {
                avatar.SetActive(true);
                _nameAvatar.text = avatar.name;
            }
        }       
    }  
}
