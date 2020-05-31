import javax.swing.JFrame;

public class App {
    public static void main(String[] args) throws Exception {

        FormularioRaton f = new FormularioRaton();

        f.setSize(500,300);

        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        f.setVisible(true);
    }
}
