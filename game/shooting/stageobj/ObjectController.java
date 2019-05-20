public class ObjectController {
    // Enemy's bullet
    static Bullet[] bullet;
    static Boss boss;
    // Player's bullet
    static MyBullet[] mybullet;
    // Bomber
    static Particle[] particle;

    Player player;

    // thouch length x TO y
    static final int DIST_PLAYER_TO_BULLET = 8;
    static final int DIST_PLAYER_TO_ENEMY = 16;
    static final int DIST_ENEMY_TO_MYBULLET = 16;

    // Max of number in scene
    static final int BULLET_MAX = 100;
    static final int PARTICLE_MAX = 100;
    static final int MYBULLET_MAX = 5;

    ObjectController() {
        player = new Player(250,400,4);
    }
}