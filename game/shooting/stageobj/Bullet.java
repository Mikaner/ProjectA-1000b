package shooting.stageobj;

public class Bullet{
    private int damage;
    private int locationX;
    private int locationY;

    public Bullet(int damage){
        this.damage = damage;
    }

    public int getDamage(){
        return this.damage;
    }

    public int getLocationX(){
        return this.locationX;
    }

    public int getLocationY(){
        return this.locationY;
    }
}
