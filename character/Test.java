package character;

public class Test {
    public static void main(String[] args) {
        Human mc = new MainCharacter(10,5,10,10);
        Human bs = new Boss(10,5,10,10,2);

        System.out.println(mc.getHp());
        System.out.println(bs.getHp());
        mc.hit(5);
        bs.hit(5);
        System.out.println(mc.getHp());
        System.out.println(bs.getHp());
    }
}