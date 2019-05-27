package shooting.stageobj;

public abstract class Human {
    protected int hp;
    private int radius;
    private int locationX;
    private int locationY;

    public Human(int hp, int radius, int locationX, int locationY){
        this.hp = hp;
        this.radius = radius;
        this.locationX = locationX;
        this.locationY = locationY;
    }

    abstract public void hit(int damage);
    public int getHp(){
        return hp;
    }
    public int getLocationX(){
        return locationX;
    }
    public int getLocationY(){
        return locationY;
    }
}
