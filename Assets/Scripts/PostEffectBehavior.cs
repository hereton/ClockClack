using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class PostEffectBehavior : MonoBehaviour
{
    public Material mat;
    public Toggle IsNormalToggle;
    public Slider DistortionSlider;
    private void Awake()
    {
        IsNormalToggle.onValueChanged.AddListener((bool isNormal) =>
        {
            if (isNormal)
            {
                this.GetComponent<PostEffectBehavior>().enabled = !isNormal;
            }
            else
            {
                this.GetComponent<PostEffectBehavior>().enabled = !isNormal;

            }
        });

        DistortionSlider.onValueChanged.AddListener((float value) =>
        {
            mat.SetFloat("_DistortionAmount", value);
        });
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }
    private void Update()
    {
    }
}
