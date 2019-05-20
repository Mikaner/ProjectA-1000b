package shooting.stageobj;

public class Player extends GameObject {
    double speed;

    public Player(double x, double y, double speed){
        super.x = x;
        super.y = y;
        this.speed = speed;
        super.active = false;
    }

    public void main(){}

    public void main(int ix, int iy) {
        double postX = x + ix * speed;
        double postY = y + iy * speed;

        if ((0 < postX)&&(postX < 500)) {
            x = postX;
        }
        if ((0 < postY)&&(postY < 500)) {
            y = posty;
        }
    }

    @Override
    public void hit(int damage){
        this.hp = this.hp - damage;
    }
}
