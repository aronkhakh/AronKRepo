package bcu.cmp5332.librarysystem.data;
import java.util.ArrayList;
import bcu.cmp5332.librarysystem.model.Patron;
import bcu.cmp5332.librarysystem.model.Book;
import bcu.cmp5332.librarysystem.model.Library;
import bcu.cmp5332.librarysystem.main.LibraryException;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;
import java.util.Scanner;

public class PatronDataManager implements DataManager {

    private final String RESOURCE = "./resources/data/patrons.txt";
    
    @Override
    public void loadData(Library library) throws IOException, LibraryException {
            try (Scanner sc = new Scanner(new File(RESOURCE))) {
                int line_idx = 1;
                while (sc.hasNextLine()) {
                    String line = sc.nextLine();
                    String[] properties = line.split(SEPARATOR, -1);
                    try {
                        int id = Integer.parseInt(properties[0]);
                        String name = properties[1];
                        String phone = properties[2];
                        List<Book> books = new ArrayList<Book>();
                        Patron patron = new Patron(id, name, phone, books);
                        library.addPatron(patron);
                    } catch (NumberFormatException ex) {
                        throw new LibraryException("Unable to parse patron id " + properties[0] + " on line " + line_idx
                            + "\nError: " + ex);
                    }
                    line_idx++;
                }
            }
        }

    @Override
    public void storeData(Library library) throws IOException {
        // TODO: implement the books as well
    	    try (PrintWriter out = new PrintWriter(new FileWriter(RESOURCE))) {
                for (Patron patron : library.getPatrons()) {
                    out.print(patron.getId() + SEPARATOR);
                    out.print(patron.getName() + SEPARATOR);
                    out.print(patron.getPhone() + SEPARATOR);
                    out.println();
                }
            }
        }

    }

