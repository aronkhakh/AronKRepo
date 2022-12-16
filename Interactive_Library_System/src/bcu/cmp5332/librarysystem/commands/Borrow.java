package bcu.cmp5332.librarysystem.commands;

import java.time.LocalDate;

import bcu.cmp5332.librarysystem.main.LibraryException;
import bcu.cmp5332.librarysystem.model.Book;
import bcu.cmp5332.librarysystem.model.Library;
import bcu.cmp5332.librarysystem.model.Loan;
import bcu.cmp5332.librarysystem.model.Patron;

public class Borrow implements Command {
	private int patronId;
	private int bookId;
	private String startDate;

	public Borrow(int patronId, int bookId, String startDate) {
		this.patronId = patronId;
		this.bookId = bookId;
		this.startDate = startDate;
	}

	@Override
	public void execute(Library library, LocalDate currentDate) throws LibraryException {
		int lastIndex = library.getLoans().size() - 1;
		int maxId = library.getLoans().get(lastIndex).getId();

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
		} catch (Exception ex) {
			throw new LibraryException(
					"Unable to parse book id " + bookId + "\nError: " + ex);
		}
		try {  //to ensure the patrons can't take out more than 3 books 
			System.out.println("Books on loan" + patron.getBooks().size());
			if (patron.getBooks().size() >= library.getMaxBookLoans()) {
				System.out.println("You cannot borrow more than 3 books at a time");
			}

			try {
				LocalDate startDate = LocalDate.parse(this.startDate);
				LocalDate dueDate = startDate.plusDays(library.getLoanPeriod());
				loan = new Loan(++maxId, patron, book, startDate, dueDate);
				library.addLoan(loan);			
				// assign book loan info from loans data
				// assign patron book info from loans data
				book.setLoan(loan);
				patron.addBook(book);
				System.out.println("Loan for Patron " + loan.getId() + " added.");
			} catch (Exception ex) {
				throw new LibraryException("Unable to assign loan \nError: " + ex);

			}
		}
