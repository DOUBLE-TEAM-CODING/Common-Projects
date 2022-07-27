import java.io.File;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;
import java.sql.*;

public class npcUpdater {
    public static Connection c = null;
    public static Statement st = null;
    public static File bosses_cond = new File(".//states//Bosses.cond");
    public static File npcm_cond = new File(".//states//NPC_M.cond");
    public static File npcs_cond = new File(".//states//NPC_S.cond");

    public static void main(String[] args) throws IOException, SQLException, ClassNotFoundException{
        Class.forName("org.sqlite.JDBC");
        c = DriverManager.getConnection("jdbc:sqlite:.//bin//characterList.db");
        st = c.createStatement();

        try{

            writeBosses();
            writeMNpcs();
            writeSNpcs();

        }catch(Exception ex){System.out.println(ex);}

    }  


    public static void writeBosses() throws SQLException, IOException{
        FileWriter fw = new FileWriter(bosses_cond);
        ResultSet bosses = st.executeQuery("select * from bosses;");

        while(bosses.next()){
            fw.write(String.valueOf(bosses.getInt("id")) + " | " + String.valueOf(bosses.getBoolean("isAlive")) + "\n");

        }

        fw.close();

    }

    public static void writeMNpcs() throws SQLException, IOException{
        FileWriter fw = new FileWriter(npcm_cond);
        ResultSet bosses = st.executeQuery("select * from main_npcs;");

        while(bosses.next()){
            fw.write(String.valueOf(bosses.getInt("id")) + " | " + String.valueOf(bosses.getBoolean("isAlive")) + "\n");

        }

        fw.close();

    }

    public static void writeSNpcs() throws SQLException, IOException{
        FileWriter fw = new FileWriter(npcs_cond);
        ResultSet bosses = st.executeQuery("select * from secondary_npcs;");

        while(bosses.next()){
            fw.write(String.valueOf(bosses.getInt("id")) + " | " + String.valueOf(bosses.getBoolean("isAlive")) + "\n");

        }

        fw.close();

    }
}