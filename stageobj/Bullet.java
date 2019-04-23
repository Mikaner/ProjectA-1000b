public class Bullet{
  int damage;
  int locationX;
  int locationY;

  class Bullet(int damage){
    this.damage = damage;
  }

  int getDamage(){
    return this.damage;
  }
  int getLocationX(){
    return this.locationX;
  }
  int getLocationY(){
    return this.locationY;
  }
}
