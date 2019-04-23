package character;

public class MainCharacter extends Human {
    public MainCharacter(int hp, int radius,int locationX, int locationY){
        super(hp, radius, locationX, locationY);
    }

    @Override
    public void hit(int damage){
        this.hp = this.hp - damage;
    }
}