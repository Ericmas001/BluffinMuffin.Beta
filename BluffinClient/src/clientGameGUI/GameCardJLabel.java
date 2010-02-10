package clientGameGUI;

import javax.swing.ImageIcon;
import javax.swing.JLabel;

public class GameCardJLabel extends JLabel
{
    public int m_height;
    public int m_width;
    public ImageIcon m_img;
    private static final long serialVersionUID = 1L;
    
    public GameCardJLabel(String url)
    {
        super();
        m_img = new ImageIcon(url);
        m_width = (m_img.getIconWidth());
        m_height = (m_img.getIconHeight());
        setIcon(m_img);
        setSize(m_width, m_height);
        setVisible(false);
    }
}
