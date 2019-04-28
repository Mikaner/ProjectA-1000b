package shooting;
import shooting.character.*;
import shooting.stageobj.*;

public class Main {
    public static void main(String[] args) {
        Human mc = new MainCharacter(10,5,10,10);
        Human bs = new Boss(10,5,10,10,2);
        Bullet b = new Bullet(5);
        System.out.println(mc.getHp());
        System.out.println(bs.getHp());
        mc.hit(b.getDamage());
        bs.hit(b.getDamage());
        System.out.println(mc.getHp());
        System.out.println(bs.getHp());
    }
}