/// <summary>
/// Speed listener interface for objects that should change with scroll speed.
/// </summary>
public interface SpeedListener {

  //method that will be called by SpeedChanger, updates the speed
  void updateScrollSpeed(float speed);

}
