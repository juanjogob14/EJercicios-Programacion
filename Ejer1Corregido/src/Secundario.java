import javax.swing.*;
import java.awt.event.*;
import java.awt.*;

public class Secundario extends JDialog implements ActionListener, ItemListener {

    JTextField txfTitulo;
    JComboBox <String> cmbColores;
    String [] colores = {"Azul", "Verde", "Rojo", "Amarillo"};
    Color [] arrayColores = {Color.BLUE, Color.GREEN, Color.RED, Color.YELLOW};

    public Secundario(FormularioRaton fr) {
        super(fr, true);
        setLayout(new FlowLayout());

        txfTitulo = new JTextField(10);
        txfTitulo.addActionListener(this);
        add(txfTitulo);

        cmbColores = new JComboBox<String>(colores);
        cmbColores.addItemListener(this);
        add(cmbColores);


    }

    @Override
    public void actionPerformed(ActionEvent e) {
        FormularioRaton fr = (FormularioRaton)this.getOwner();
        fr.setTitle(txfTitulo.getText());
        fr.titulo = txfTitulo.getText();

    }

    @Override
    public void itemStateChanged(ItemEvent e) {
        FormularioRaton fr = (FormularioRaton)this.getOwner();

        fr.color = arrayColores[cmbColores.getSelectedIndex()];

    }
}