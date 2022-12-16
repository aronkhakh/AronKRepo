package bcu.cmp5332.librarysystem.model;
import bcu.cmp5332.librarysystem.main.LibraryException;
import java.util.*;

public class Library {
    
    private final int loanPeriod = 7;
    private final Map<Integer, Patron> patrons = new TreeMap<>();
    private final Map<Integer, Book> books = new TreeMap<>();
    private final Map<Integer, Loan> loans = new TreeMap<>();
    private final int maxBooks = 3;

    public int getMaxBookLoans() {
    	return maxBooks;
    }
    
    public int getLoanPeriod() {
        return loanPeriod;
    }

    public List<Book> getBooks() {
        List<Book> out = new ArrayList<>(books.values());
        return Collections.unmodifiableList(out);
    }

    public Book getBookByID(int id) throws LibraryException {
        if (!books.containsKey(id)) {
            throw new LibraryException("There is no such book with that ID.");
        }
        return books.get(id);
    }

    public Patron getPatronByID(int id) throws LibraryException {
        if (!patrons.containsKey(id)) {
            throw new LibraryException("There is no such patron with that ID.");
        }
        return patrons.get(id);
    }

    public void addBook(Book book) {
        if (books.containsKey(book.getId())) {
            throw new IllegalArgumentException("Duplicate book ID.");
        }
        books.put(book.getId(), book);
    }
    
    public List<Patron> getPatrons() {
        List<Patron> out = new ArrayList<>(patrons.values());
        return Collections.unmodifiableList(out);
    }

    public void addPatron(Patron patron) {
        if (patrons.containsKey(patron.getId())) {
            throw new IllegalArgumentException("Duplicated patron ID.");
        }
        patrons.put(patron.getId(), patron);
    }

    public List<Loan> getLoans() {
        List<Loan> out = new ArrayList<>(loans.values());
        return Collections.unmodifiableList(out);
    }

    public void addLoan(Loan loan) {
    	if (loans.containsKey(loan.getId())) {
            throw new IllegalArgumentException("Duplicated loan.");
    	}
            loans.put(loan.getId(), loan);
    }
    
    public void removeLoan(Loan loan) {
    	if (!loans.containsKey(loan.getId())) {
            throw new IllegalArgumentException("Loan Not Found " + loan.getId());
    	}
        loans.remove(loan.getId(), loan);
    } 
    
}
