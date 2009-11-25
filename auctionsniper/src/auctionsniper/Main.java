package auctionsniper;

import auctionsniper.ui.MainWindow;

import javax.swing.*;

public class Main {
    public static final String MAIN_WINDOW_NAME = "";
    public static final String SNIPER_STATUS_NAME = "";

    private MainWindow ui;

    public Main() throws Exception {
        startUserInterface();
    }

    public static void main(String... args) throws Exception {
        new Main();
    }

    private void startUserInterface() throws Exception{
        SwingUtilities.invokeAndWait(new Runnable() {
            public void run() {
                ui = new MainWindow();
            }
        });
    }
}
