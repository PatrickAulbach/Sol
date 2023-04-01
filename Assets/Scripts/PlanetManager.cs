using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] int spawnChance;
    [SerializeField] List<Sprite> sprites;
    [SerializeField] int childPosition;
    private const float INITIAL_SPRITE_SCALE_FACTOR = 0.5f;
    private readonly Vector2 CANVAS_SIZE = new Vector2(3, 0.5f);
    private readonly Vector3 CANVAS_SPAWN_POINT = new Vector3(0, 1.6f, 0);
    private readonly List<Vector3> SYMBOL_SPAWN_POINTS = new List<Vector3>{
        new Vector3(1.2f, 0, 0),
        new Vector3(0, 0, 0),
        new Vector3(-1.2f, 0, 0)
    };
    
    private void Awake()
    {
        InitializeCanvas();
        InitializeRessources();
    }

    private void InitializeRessources()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            if (Random.Range(0, 101) <= spawnChance)
            {
                GameObject planetSymbolGameObject = new GameObject();
                planetSymbolGameObject.transform.localScale = planetSymbolGameObject.transform.localScale / transform.localScale.x;
                SpriteRenderer spriteRenderer = planetSymbolGameObject.AddComponent<SpriteRenderer>();

                spriteRenderer.sprite = sprites[i];
                spriteRenderer.transform.position = SYMBOL_SPAWN_POINTS[i] / transform.localScale.x;
                if (spriteRenderer.transform.localScale.x >= 1)
                {
                    spriteRenderer.transform.localScale *= (INITIAL_SPRITE_SCALE_FACTOR / transform.localScale.x);
                }

                Transform canvasTransform = transform.GetChild(childPosition).gameObject.GetComponent<Canvas>().transform;
                planetSymbolGameObject.transform.SetParent(canvasTransform, false);
            }
        }
    }

    private void InitializeCanvas()
    {
        GameObject canvasGameObject = new GameObject();
        var canvas = canvasGameObject.AddComponent<Canvas>();
        canvas.transform.position = CANVAS_SPAWN_POINT;
        canvas.GetComponent<RectTransform>().sizeDelta = CANVAS_SIZE / transform.localScale.x;

        canvas.transform.SetParent(this.transform, false);

    }
}
