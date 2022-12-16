package bcu.cmp5332.librarysystem.commands;

import java.time.LocalDate;

import bcu.cmp5332.librarysystem.main.LibraryException;
import bcu.cmp5332.librarysystem.model.Book;
import bcu.cmp5332.librarysystem.model.Library;
import bcu.cmp5332.librarysystem.model.Loan;
import bcu.cmp5332.librarysystem.model.Patron;

public class Return implements Command {
	private int patronId;
	private int bookId;

	public Return(int patronId, int bookId) {
		this.patronId = patronId;
		this.bookId = bookId;
	}

	@Override
	public void execute(Library library, LocalDate currentDate) throws LibraryException {

		Patron patron;
		Book book;
		Loan loan;
		try {
			patron = library.getPatronByID(patronId);
		} catch (Exception ex) {
			throw new LibraryException(
					"Unable to parse patron id " + patronId + "\nError: " + ex);
		}
		try {
			book = library.getBookByID(bookId);
			loan = book.getLoan();
		} catch (Exception ex) {
			throw new LibraryException(
					"Unable to parse book id " + bookId + "\nError: " + ex);
		}
		try {
			//clear loan on book
			book.setLoan(null);
			//clear loan on patron
			patron.removeBook(book);
			//remove loan from loans collection
			library.removeLoan(loan);
			System.out.println("Loan for Patron " + loan.getPatronId() + " for book " + loan.getBookId() + " removed.");
		} catch (Exception ex) {
			throw new LibraryException("Unable to return loan \nError: " + ex);
			
		}
	}	
}
