using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Showroom.Datas
{
    public enum CharacterType
    {
        None,
        Player,
        Receptionist
    }
    [CreateAssetMenu(menuName = "Data/New IAData")]
    public class CharacterData : ScriptableObject
    {
        
        [SerializeField]
        private float _movementSpeed = 3.5f;
        //[SerializeField]
        //private string _greetingsTag = "Player";
        [SerializeField]
        private List<CharacterType> _greetingsTagList;



        public float MovementSpeed { get => _movementSpeed; }
        public List<CharacterType> GreetingsTags { get => _greetingsTagList; }
    }
}
