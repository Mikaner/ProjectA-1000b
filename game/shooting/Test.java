package shooting;

import java.io.File;

import javafx.animation.AnimationTimer;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

public class Test extends Application {
    public static void main(String[] args) {
        launch(args);
    }

    //Main player
    ImageView img = new ImageView(new File("shooting/sample1.png").toURI().toString());

    boolean isLeft;
    boolean isRight;
    boolean isUp;
    boolean isDown;

    int sceneMaxX = 1000;
    int sceneMaxY = 1000;

    @Override
    public void start(Stage primaryStage) throws Exception {
        Pane p = new Pane();
        p.setPrefSize(20,20);
        Scene scene = new Scene(p,sceneMaxX,sceneMaxY);
        primaryStage.setScene(scene);
        primaryStage.show();

        p.getChildren().add(img);

        scene.setOnKeyPressed(e -> keyPressed(e));
        scene.setOnKeyReleased(e -> keyReleased(e));

        new AnimationTimer() {
            @Override
            public void handle(long arg0) {
                gameLoop();
            }
        }.start();
    }

    public void gameLoop() {
        if ( isLeft ) {
            if ( img.getX() > 0 ) img.setX(img.getX()-3);
        }
        if ( isRight ) {
            if(img.getX() < sceneMaxX ) img.setX(img.getX()+3);
        }
        if ( isUp ) {
            if(img.getY() > 0 ) img.setY(img.getY()-3);
        }
        if ( isDown ) {
            if(img.getY() < sceneMaxY )img.setY(img.getY()+3);
        }
    }

    private void keyPressed(KeyEvent e) {
        switch(e.getCode()) {
            case LEFT:
                isLeft = true;
                break;
            case RIGHT:
                isRight = true;
                break;
            case UP:
                isUp = true;
                break;
            case DOWN:
                isDown = true;
                break;
            default:
                break;
        }
    }

    private void keyReleased(KeyEvent e) {
        switch (e.getCode()) {
            case LEFT:
                isLeft = false;
                break;
            case RIGHT:
                isRight = false;
                break;
            case UP:
                isUp = false;
                break;
            case DOWN:
                isDown = false;
                break;
            default:
                break;
        }
    }
}