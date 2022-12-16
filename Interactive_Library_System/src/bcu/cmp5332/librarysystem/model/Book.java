package bcu.cmp5332.librarysystem.model;
import bcu.cmp5332.librarysystem.main.LibraryException;
import java.time.LocalDate;

public class Book {
    
    private int id;
    private String title;
    private String author;
    private String publicationYear;
    private String publisher;
    //private final int loanPeriod = 7;
    private Loan loan;
    //private String startDate; 

    public Book(int id, String title, String author, String publicationYear, String publisher) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.publicationYear = publicationYear;
        this.publisher = publisher;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }
    
    public String getAuthor() {
        return author;
    }
    
    public void setAuthor(String author) {
        this.author = author;
    }

    public String getPublicationYear() {
        return publicationYear;
    }

    public void setPublicationYear(String publicationYear) {
        this.publicationYear = publicationYear;
    }
    
    public String getPublisher() {
    	return publisher;
    }
    
    public void setPublisher(String publisher) {
    	this.publisher = publisher;
    }
	
    public String getDetailsShort() {
        return "Book #" + " " + id + " - " + title;
    }

    public String getDetailsLong() {
        return "Book #" + " " + id + " " + author + " " + title + " " + publicationYear + " " + publisher;
    }
    
    public boolean isOnLoan() {
        return (loan != null);
    }
    
    public String getStatus() {
        return null;
    }

    public String getDueDate() {
        if (loan != null)
        	{
        	return loan.getDueDate();
        	};
    }
    
// set due date is specific to loan not to book    
//    public void setDueDate(LocalDate dueDate) throws LibraryException {
//    	LocalDate startDate = LocalDate.parse(this.startDate);
//    	LocalDate DueDate = startDate.plusDays(loanPeriod);
//    }

    public Loan getLoan() {
        return loan;
    }

    public void setLoan(Loan loan) {
        this.loan = loan;
    }

    public void returnToLibrary() {
        loan = null;
    }
}
