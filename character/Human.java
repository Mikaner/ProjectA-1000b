package character;

abstract class Human {
    protected int hp;
    protected int radius;
    protected int locationX;
    protected int locationY;

    public Human(int hp, int radius, int locationX, int locationY){
        this.hp = hp;
        this.radius = radius;
        this.locationX = locationX;
        this.locationY = locationY;
    }

    abstract protected void hit(int damage);
    protected int getHp(){
        return hp;
    }
    protected int getLocationX(){
        return locationX;
    }
    protected int getLocationY(){
        return locationY;
    }
}