using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {

  public float scrollDuration = 10;
  public int maxNumTiles = 30;

  private bool fin = false;

  private float tileMoveProgress = 0;

  public static int tilesSpawned = 0;

  public int maxFoodPerTile = 5;

  private float height;
  private float width;
  private Vector3 center;

  public Object[] healthyFood;
  public Object[] unhealthyFood;

	// Use this for initialization
	void Start () {
  
    setTileSpeed();
    center = this.transform.position;

    width = GetComponent<SpriteRenderer>().bounds.size.x;
    height = GetComponent<SpriteRenderer>().bounds.size.y;
    StartCoroutine(scrollDown());
	
	}
	
	// Update is called once per frame
	void Update () {

    setTileSpeed();

	}

  IEnumerator scrollDown() {
    
    Vector3 startPosition = this.transform.position;
    Vector3 tileFloatDestination;

    tileFloatDestination = new Vector3(this.transform.position.x,
                                      Camera.main.transform.position.y - Camera.main.orthographicSize*2);


    while (true) {

      bool spawned = false;


      for (tileMoveProgress = 0; tileMoveProgress < scrollDuration; tileMoveProgress+=Time.deltaTime) {


        if (tileMoveProgress >= scrollDuration/4 && !spawned && !fin) {

          spawnNewTile();
          spawned = true;

        }

        if (fin && tileMoveProgress >= (scrollDuration*0.75)) break;

        this.transform.position = Vector3.Lerp(startPosition, tileFloatDestination, tileMoveProgress/scrollDuration);
        yield return null;

      }

      if (fin) {

        GameObject.Find("Controller").GetComponent<ScrollTrack>().loadScoreScreen();
        break;

      }

      GameObject.Destroy(this.gameObject);

    }
  }

  void spawnNewTile() {

    Vector3 destination = this.transform.position;
    destination.y += (height)/2;

    if (Tile.tilesSpawned < maxNumTiles) {

      GameObject newTile = (GameObject)GameObject.Instantiate(ScrollTrack.regularTrack, destination, Quaternion.identity);

      if (BeginRace.started) {
        newTile.GetComponent<Tile>().placeFood();
        Tile.tilesSpawned++;
      }
    }

    else {

      GameObject newTile = (GameObject)GameObject.Instantiate(ScrollTrack.finTrack, destination, Quaternion.identity);
      newTile.GetComponent<Tile>().isFin();

    }

  }

  public void placeFood() {

    width = GetComponent<SpriteRenderer>().bounds.size.x*2;
    height = GetComponent<SpriteRenderer>().bounds.size.y*2;

    for (int i = 0; i < maxFoodPerTile; i++) {

      Object foodToPlace;
      int randomBit = Random.Range(-1, 1);
      Debug.Log(randomBit);
      if (randomBit < 0) {

        foodToPlace = healthyFood[Random.Range(0, healthyFood.Length-1)];

      }

      else {

        foodToPlace = unhealthyFood[Random.Range(0, healthyFood.Length-1)];

      }

      Vector3 foodPosition = new Vector3(Random.Range(-width, width),
                                         Random.Range(-height, height),
                                         this.transform.position.z-1);

      GameObject newFood = (GameObject)GameObject.Instantiate(foodToPlace);
      newFood.transform.parent = this.transform;
      newFood.transform.localPosition = foodPosition;

    }
  }

  public void setTileSpeed() {

    tileMoveProgress *= (SamController.tileMoveDuration /scrollDuration);
    scrollDuration = SamController.tileMoveDuration;
    

  }

  public void isFin() {

    fin = true;

  }
}
