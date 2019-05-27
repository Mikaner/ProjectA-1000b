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

public class OperationTest extends Application {
    public static void main(String[] args) {
        launch(args);
    }

    Image im = new Image("shooting/sample1.png");

    //Main player
    ImageView img = new ImageView();

    boolean isLeft;
    boolean isRight;
    boolean isUp;
    boolean isDown;
    boolean isSpace;

    int sceneMaxX = 540;
    int sceneMaxY = 960;

    @Override
    public void start(Stage primaryStage) throws Exception {
        Pane p = new Pane();
        p.setPrefSize(1,1);
        Scene scene = new Scene(p,sceneMaxX,sceneMaxY);
        primaryStage.setScene(scene);
        scene.getStylesheets().add(OperationTest.class.getResource("stage.css").toExternalForm());
        primaryStage.show();
        img.setImage(im);

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
        if ( isSpace ) {
            System.out.println(img.getX());
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
            case SPACE:
                isSpace = true;
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
            case SPACE:
                isSpace = false;
                break;
            default:
                break;
        }
    }
}