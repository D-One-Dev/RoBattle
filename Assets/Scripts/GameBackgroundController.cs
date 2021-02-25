using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackgroundController : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    private Transform camTransform;
    private Vector3 lastCamPos;
    private float textureUnitSizeX;
    private void Start()
    {
        camTransform = Camera.main.transform;
        lastCamPos = camTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaMove = camTransform.position - lastCamPos;
        transform.position += deltaMove * parallaxEffect;
        lastCamPos = camTransform.position;

        if (Mathf.Abs(camTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPosX = (camTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(camTransform.position.x + offsetPosX, transform.position.y);
        }
    }
}
