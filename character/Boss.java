package character;

public class Boss extends Human {
    int defense;
    public Boss(int hp, int radius, int locationX, int locationY, int defense){
        super(hp, radius, locationX, locationY);
        this.defense = defense;
    }

    @Override
    public void hit(int damage){
        this.hp = this.hp - (damage-defense);
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