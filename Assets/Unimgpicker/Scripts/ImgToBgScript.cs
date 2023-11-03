using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ImgToBgScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer wallRenderer;

    // Function to receive the image path
    public void ReceiveImagePath(string imagePath)
    {
        // Handle the received image path
        Debug.Log("Received Image Path: " + imagePath);

        // Example: Set the received image path as a background texture
        Texture2D texture = LoadImageFromFile(imagePath);
        if (texture != null)
        {
            Debug.Log("texture is not null");
            // Debug.Log("wallRenderer's material: "+ wallRenderer.material);
            // wallRenderer.material.mainTexture = texture;
            if (wallRenderer != null)
            {
                Debug.Log("wallRenderer is not null");
                wallRenderer.material.mainTexture = texture;
            }
        }
    }

    // Example: Load an image from file into a Texture2D
    private static Texture2D LoadImageFromFile(string filePath)
    {
        byte[] imageBytes = File.ReadAllBytes(filePath);
        Debug.Log("filePath: " + filePath);
        Texture2D texture = new Texture2D(2, 2);
        if (texture.LoadImage(imageBytes))
        {
            Debug.Log("Texture: " + texture);
            return texture;
        }
        else
        {
            Debug.LogError("Failed to load image from file: " + filePath);
            return null;
        }
    }
}
