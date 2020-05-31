import javax.swing.*;

//import javafx.scene.input.KeyEvent;

//import javafx.scene.input.KeyEvent;

import java.awt.event.*;
import java.nio.file.SecureDirectoryStream;
import java.awt.*;

public class FormularioRaton extends JFrame {

    JButton btnDerecho, btnIzquierdo;
    JLabel lblTeclas;
    Color color = Color.GRAY;
    int coordX, coordY;
    String titulo = "Control de ratón";

    public FormularioRaton() {
        super("Control de ratón");
        setLayout(new FlowLayout());
        setFocusable(true);

        btnIzquierdo = new JButton("Izquierdo");
        btnIzquierdo.addMouseListener(new gestorRaton());
        btnIzquierdo.addMouseMotionListener(new gestorRaton());
        add(btnIzquierdo);

        btnDerecho = new JButton("Derecho");
        btnDerecho.addMouseListener(new gestorRaton());
        btnDerecho.addMouseMotionListener(new gestorRaton());
        add(btnDerecho);

        lblTeclas = new JLabel("Teclas");
        lblTeclas.setFocusable(true);
        add(lblTeclas);

        this.getContentPane().addMouseListener(new gestorRaton());
        this.getContentPane().addMouseMotionListener(new gestorRaton());

        addKeyListener(new gestorTeclado());

    }

    private class gestorRaton extends MouseAdapter {

        @Override
        public void mouseMoved(MouseEvent e) {

            setTitle(String.format("Posición del ratón X:%d, Y:%d)", e.getX(), e.getY()));

            if (e.getSource().getClass() == JButton.class) {
                setTitle(String.format("Posición del ratón X:%d, Y:%d)", e.getX() + ((JButton) e.getSource()).getX(), e.getY()+ ((JButton) e.getSource()).getY()));
            }

        }
        
        @Override
        public void mousePressed(MouseEvent e) {
            Secundario sec = new Secundario(FormularioRaton.this);

            if (SwingUtilities.isLeftMouseButton(e)) {
                btnIzquierdo.setBackground(color);
            } else {
                if (SwingUtilities.isRightMouseButton(e)) {
                    btnDerecho.setBackground(color);
                }
            }

        }

        @Override
        public void mouseReleased(MouseEvent e) {
            if (SwingUtilities.isLeftMouseButton(e)) {
                btnIzquierdo.setBackground(null);
            } else {
                if (SwingUtilities.isRightMouseButton(e)) {
                    btnDerecho.setBackground(null);
                }
            }
        }

        @Override
        public void mouseExited(MouseEvent e) {
            setTitle(titulo);
        }

    }

    private class gestorTeclado extends KeyAdapter {

        @Override
        public void keyPressed(java.awt.event.KeyEvent e) {
            lblTeclas.setText("Letra seleccionada: " + e.getKeyChar() + " código asociado: " + e.getKeyCode());

            if (e.isControlDown() && e.getKeyCode() == e.VK_C) {

                Secundario s = new Secundario(FormularioRaton.this);

                s.setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE);

                s.setSize(200, 200);

                s.setVisible(true);

            }

        }
    }

}