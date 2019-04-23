package character;

public class MainCharacter extends Human {
    public MainCharacter(int hp, int radius,int locationX, int locationY){
        super(hp, radius, locationX, locationY);
    }

    @Override
    public void hit(int damage){
        this.hp = this.hp - damage;
    }

    @Override
    public int getHp(){
        return super.hp;
    }

    @Override
    public int getLocationX(){
        return super.locationX;
    }

    @Override
    public int getLocationY(){
        return super.locationY;
    }
}