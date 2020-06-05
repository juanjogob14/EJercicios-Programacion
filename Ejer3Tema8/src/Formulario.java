import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;

import java.awt.*;
import java.awt.event.*;
import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class Formulario extends JFrame implements ActionListener {

    JButton botonSeleccionar;
    JTextArea contenidoArchivo;
    JLabel muestraImagen;
    JLabel datosArchivo;
    JScrollPane scroll;
    String archivo;

    public Formulario() {
        super("Selector de archivos");
        this.setLayout(new FlowLayout());

        botonSeleccionar = new JButton("Seleccionar");
        botonSeleccionar.addActionListener(this);
        add(botonSeleccionar);

        contenidoArchivo = new JTextArea(10, 20);
        scroll = new JScrollPane(contenidoArchivo);
        contenidoArchivo.setLineWrap(true);
        contenidoArchivo.setWrapStyleWord(true);
        add(scroll);

        muestraImagen = new JLabel();
        add(muestraImagen);

        datosArchivo = new JLabel();
        add(datosArchivo);

    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == botonSeleccionar) {
            int respuesta;
            String texto = "";
            String acu = "";
            FileNameExtensionFilter filtro = new FileNameExtensionFilter("Imagenes", "jpg", "jpeg", "gif", "png");
            FileNameExtensionFilter filtro2 = new FileNameExtensionFilter("Archivos de texto", "txt");
            JFileChooser fc = new JFileChooser();
            fc.addChoosableFileFilter(filtro);
            fc.addChoosableFileFilter(filtro2);
            fc.setFileSelectionMode(JFileChooser.FILES_AND_DIRECTORIES);
            respuesta = fc.showOpenDialog(this);

            if (respuesta == JFileChooser.APPROVE_OPTION) {
                archivo = fc.getSelectedFile().getName();

                if (fc.getSelectedFile().isFile()) {
                    if (archivo.endsWith(".jpg") || archivo.endsWith(".jpeg") || archivo.endsWith(".png")
                            || archivo.endsWith(".gif")) {
                        muestraImagen.setIcon(new ImageIcon(fc.getSelectedFile().getPath()));
                        muestraImagen.setSize(muestraImagen.getPreferredSize());
                        datosArchivo.setText("");
                    } else {
                        if (archivo.endsWith(".txt")) {
                            try (Scanner f = new Scanner(new File(fc.getSelectedFile().getPath()))) {
                                while (f.hasNext()) {
                                    texto = f.nextLine();
                                    acu = acu + texto + "\n";
                                    contenidoArchivo.setText(acu);
                                    //System.err.println(acu);
                                }
                            } catch (IOException ex) {
                                System.err.print("");
                            }
                            muestraImagen.setIcon(null);
                            datosArchivo.setText("");
                        } else {
                            datosArchivo.setText(String.format("<html><body>%s<br>%s<br>%d KB<br>%s %s</body></html>",
                                    fc.getSelectedFile().getName(), fc.getSelectedFile().getAbsolutePath(),
                                    fc.getSelectedFile().length() / 1024, fc.getSelectedFile().canRead(),
                                    fc.getSelectedFile().canWrite()));
                                    muestraImagen.setIcon(null);

                        }
                    }

                }

                if (fc.getSelectedFile().isDirectory()) {

                    File[] content = fc.getSelectedFile().listFiles();
                    String acumulador = "";

                    for (int i = 0; i < content.length; i++) {

                        if (content[i].isDirectory()) {
                            acumulador += "D " + content[i].getName()+"\n";
                        } else {
                            acumulador += content[i].getName()+"\n";
                        }
                        
                        contenidoArchivo.setText(acumulador);

                    }

                }

            }

        }
    }

}
