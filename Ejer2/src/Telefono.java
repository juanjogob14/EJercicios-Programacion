import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.util.Scanner;
import javax.swing.*;
import javax.swing.event.MouseInputAdapter;

import javafx.event.ActionEvent;

//import javafx.scene.input.KeyEvent;

public class Telefono extends JFrame implements ActionListener {

    JTextField txfNumerosPulsados;
    JButton btReset, btNumeros;
    JMenuBar barraMenu;
    JMenu mnArchivo, mnMovil, mnOtros;
    JMenuItem grabarNum, mostrarNum, resetOpc, salir, acercaDe;
    private String[] numeros = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "#", "0", "*" };
    JButton[] botones = new JButton[numeros.length];
    String texto = "";

    public Telefono() {
        super();
        setLayout(null);
        setFocusable(true);
        
        int x = 10, y = 50;
        this.addMouseListener(new gestorRaton());
        addKeyListener(new gestorTeclado());

        for (int i = 0; i < numeros.length; i++) {
            botones[i] = new JButton(numeros[i]);
            botones[i].setSize(100, 30);
            botones[i].setLocation(x, y);
            botones[i].addActionListener(new ActionListener(){
                @Override
                public void actionPerformed(java.awt.event.ActionEvent e) {
                    String botonNumero = ((JButton) e.getSource()).getText();
                    txfNumerosPulsados.setText(texto + botonNumero);
                    texto = txfNumerosPulsados.getText();

                }
            });
            botones[i].addMouseListener(new gestorRaton());
            botones[i].addMouseMotionListener(new gestorRaton());
            this.add(botones[i]);

            if ((i + 1) % 3 == 0) {
                x = 10;
                y += 40;
            } else {
                x += 130;
            }
        }

        txfNumerosPulsados = new JTextField(20);
        txfNumerosPulsados.setSize(350, 30);
        txfNumerosPulsados.setLocation(10, 10);
        txfNumerosPulsados.setEditable(false);
        add(txfNumerosPulsados);

        btReset = new JButton("Reset");
        btReset.setSize(100, 30);
        btReset.setLocation(140, 210);
        btReset.addActionListener(this);
        add(btReset);

        // menu archivo
        grabarNum = new JMenuItem("Grabar número");
        grabarNum.setMnemonic('A');
        grabarNum.addActionListener(this);

        mostrarNum = new JMenuItem("Leer número");
        mostrarNum.setMnemonic('B');
        mostrarNum.addActionListener(this);

        mnArchivo = new JMenu("Archivo");
        mnArchivo.setMnemonic('Q');
        mnArchivo.add(grabarNum);
        mnArchivo.add(mostrarNum);

        // menu movil

        resetOpc = new JMenuItem("Reset");
        resetOpc.setMnemonic('C');
        resetOpc.addActionListener(this);

        salir = new JMenuItem("Salir");
        salir.setMnemonic('D');
        salir.addActionListener(this);

        mnMovil = new JMenu("Movil");
        mnMovil.setMnemonic('S');
        mnMovil.add(resetOpc);
        mnMovil.add(salir);

        // menu otros

        acercaDe = new JMenuItem("Acerca de...");
        acercaDe.setMnemonic('F');
        acercaDe.addActionListener(this);

        mnOtros = new JMenu("Otros");
        mnOtros.setMnemonic('X');
        mnOtros.add(acercaDe);

        // barra principal

        barraMenu = new JMenuBar();
        barraMenu.add(mnArchivo);
        barraMenu.add(mnMovil);
        barraMenu.add(mnOtros);
        this.setJMenuBar(barraMenu);

    }

    @Override
    public void actionPerformed(java.awt.event.ActionEvent e) {
        String archivo = System.getProperty("user.home") + "\\numeros.txt";
        if (e.getSource() == grabarNum) {

            try (PrintWriter pw = new PrintWriter(new FileWriter(archivo, true))) {
                pw.println(txfNumerosPulsados.getText());
            } catch (IOException ex) {
                System.err.println("Error de acceso al archivo");
            }
        }

        if (e.getSource() == mostrarNum) {
            String texto="";
            String numero;

            try (Scanner f = new Scanner(new File(archivo))) {
                while (f.hasNext()) {
                    numero = f.nextLine();
                    texto = texto + numero + "\n";
                }
            } catch (IOException ex) {
                System.err.println("Error de acceso al archivo");
            }
            JOptionPane.showMessageDialog(null, texto, "Telefonos guardados", JOptionPane.INFORMATION_MESSAGE);
        }

        if (e.getSource() == resetOpc) {
            txfNumerosPulsados.setText("");
            texto = "";
            for (int i = 0; i < botones.length; i++) {
                botones[i].setBackground(null);
            }
        }

        if (e.getSource() == salir) {
            System.exit(0);
        }

        if (e.getSource() == acercaDe) {
            JOptionPane.showMessageDialog(null, System.getProperty("user.home") + " " + System.getProperty("user.name"),
                    "Informacion", JOptionPane.INFORMATION_MESSAGE);
        }

        if (e.getSource() == btReset) {
            txfNumerosPulsados.setText("");
            texto = "";
            for (int i = 0; i < botones.length; i++) {
                botones[i].setBackground(null);
            }
        }

    }

    private class gestorRaton extends MouseAdapter {

        @Override
        public void mouseClicked(MouseEvent e) {

            for (int i = 0; i < botones.length; i++) {
                if (e.getSource() == botones[i]) {
                    botones[i].setBackground(Color.RED);
                }
            }
        }

        @Override
        public void mouseEntered(MouseEvent e) {
            for (int i = 0; i < botones.length; i++) {
                if (e.getSource() == botones[i] && botones[i].getBackground()!= Color.RED){
                    botones[i].setBackground(Color.GREEN);
                }
            }

        }

        @Override
        public void mouseExited(MouseEvent e) {
            for (int i = 0; i < botones.length; i++) {
                if (e.getSource() == botones[i] && botones[i].getBackground() != Color.RED) {
                    botones[i].setBackground(null);
                }
            }

        }

    }

    private class gestorTeclado extends KeyAdapter {
        
        @Override
        public void keyPressed(KeyEvent e) {
            String teclaPulsada = Character.toString(e.getKeyChar());

            texto = texto+teclaPulsada;

            txfNumerosPulsados.setText(texto);
            
            
            for (int i = 0; i < botones.length; i++) {
                if(Telefono.this.botones[i].getText().equals(teclaPulsada)){
                    Telefono.this.botones[i].setBackground(Color.RED);
                }
            }
            
        }

        @Override
        public void keyReleased(KeyEvent e){
            String teclaPulsada = Character.toString(e.getKeyChar());


            for (int i = 0; i < botones.length; i++) {
                if(Telefono.this.botones[i].getText().equals(teclaPulsada)){
                    Telefono.this.botones[i].setBackground(null);
                }
            }
        }

    }

    
}