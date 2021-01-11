using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifesQuantRenderer : MonoBehaviour
{
    public GameObject knifeTilePrefab;

    private int knifeQuant;

    private Vector2 genPos;

    private GameObject newTile;

    public List<GameObject> knifesQuantTiles = new List<GameObject>();

    private int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        knifeQuant = GameObject.FindGameObjectWithTag("Wood").GetComponent<Wood>().woodHP;
        genPos = transform.position;
        KnifesQuantRender();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject lastElem = knifesQuantTiles[knifesQuantTiles.Count - index];
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastElem.GetComponent<SpriteRenderer>().enabled = false;
            index++;
            if(index > knifesQuantTiles.Count)
            {
                index = knifesQuantTiles.Count;
            }
        }
    }

    

    public void KnifesQuantRender()
    {   
        float tileHeight = knifeTilePrefab.GetComponent<BoxCollider2D>().size.y;
        for( int i = 0; i < knifeQuant; i++)
        {
            newTile = Instantiate(knifeTilePrefab, genPos, Quaternion.identity);
            genPos = new Vector2(transform.position.x, transform.position.y + tileHeight * (i+1));
            newTile.transform.parent = transform;
            knifesQuantTiles.Add(newTile);
        }
    }
}
