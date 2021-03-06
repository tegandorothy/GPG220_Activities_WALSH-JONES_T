﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class TextureRenderer : MonoBehaviour
{
    public byte[] backBuffer;

    private int xSize = 24;
    private int ySize = 24;

    public Texture2D texture;

    private Renderer quadRenderer;

    private int byteSize;

    public int red;
    public int green;
    public int blue;

    private Star star;
    
    void Start()
    {
        quadRenderer = GetComponent<Renderer>();
        
        byteSize = xSize * ySize * 3;

        //Initialising the backBuffer array so that each pixel takes in 3 values
        backBuffer = new byte[byteSize];

        texture = new Texture2D(xSize, ySize, TextureFormat.RGB24, false);

        //Turning off blur for debugging
        texture.filterMode = FilterMode.Point;

        //Preventing wrapping
        texture.wrapMode = TextureWrapMode.Clamp;

        quadRenderer.material.mainTexture = texture;
    }

    void Update()
    {
        texture.LoadRawTextureData(backBuffer);
        texture.Apply(false);

        // Testing
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           //RedPixel();
           //WhitePixel();
           //GreenPixel();
           //ChangePixel(6, 0, 255, 255, 255); //Setting the sixth pixel to white
           //ColourToTexture(255, 0, 0); //Setting the entire texture to red
           //ColourToTexture(128, 64, 255); //Setting the entire texture to colour 128, 64, 255
        }
        
        //Change the colour of the entire texture at runtime
        //ColourToTexture(red, green, blue);
        
        /* More testing
        ChangePixel(0,0,255,0,0);
        ChangePixel(3,0,0,255,0);
        ChangePixel(1,1,0,0,255);
        */
        
        //ChangePixel(Random.Range(0, 24), Random.Range(0, 24), 255, 255, 255);
    }
    
    //Setting the first pixel to red
    void RedPixel()
    {
        backBuffer[0] = 255;
    }
    
    //Setting the sixth pixel to white
    void WhitePixel()
    {
        /* Hard coded
        backBuffer[15] = 255;
        backBuffer[16] = 255;
        backBuffer[17] = 255;
        */
    }
    //Setting the pixel at x=10, y=20 to green
    void GreenPixel()
    {
        ChangePixel(10, 20, 0 , 255, 0);
    }

    void ChangePixel(int x, int y, int R, int G, int B)
    {
        backBuffer[((xSize * 3 * y) + (x * 3))] = (byte) R;
        backBuffer[((xSize * 3 * y) + (x * 3) + 1)] = (byte) G;
        backBuffer[((xSize * 3 * y) + (x * 3) + 2)] = (byte) B;
    }

    public void ColourToTexture(int R, int G, int B)
    {
        for (int i = 0; i < byteSize / 3; i++)
        {
            ChangePixel(i, 0, R, G, B);
        }
    }
}
