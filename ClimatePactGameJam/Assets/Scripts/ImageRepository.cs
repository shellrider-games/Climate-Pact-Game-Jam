using System;
using System.Collections.Generic;
using UnityEngine;

public class ImageRepository : MonoBehaviour
{
    [Serializable]
    public struct ImageEntry
    {
        public string name;
        public Sprite sprite;
    }
    
    
    [SerializeField] private List<ImageEntry> images = new List<ImageEntry>();
    public Dictionary<string, Sprite> ImageDictionary;

    private void Awake()
    {
        ImageDictionary = new Dictionary<string, Sprite>();
        foreach (ImageEntry entry in images)
        {
            ImageDictionary.Add(entry.name, entry.sprite);
        }
    }
}
