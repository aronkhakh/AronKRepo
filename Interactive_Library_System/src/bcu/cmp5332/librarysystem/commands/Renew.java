package bcu.cmp5332.librarysystem.commands;

import java.time.LocalDate;
import java.util.List;

import bcu.cmp5332.librarysystem.main.LibraryException;
import bcu.cmp5332.librarysystem.model.Book;
import bcu.cmp5332.librarysystem.model.Library;
import bcu.cmp5332.librarysystem.model.Loan;
import bcu.cmp5332.librarysystem.model.Patron;

public class Renew implements Command {
	private int patronId;
	private int bookId;

	public Renew(int patronId, int bookId) {
		this.patronId = patronId;
		this.bookId = bookId;
	}

	@Override
	public void execute(Library library, LocalDate currentDate) throws LibraryException {
		//filter on matching loan
		//add renewal days to dueDate
		try {
			List<Loan> loans = library.getLoans();
			for (Loan loan : loans) {
				if (loan.getPatronId() == patronId && loan.getBookId() == bookId) {
					loan.setDueDate(LocalDate.now().plusDays(library.getLoanPeriod()));//renew from today
					System.out.println("Loan for Patron " + loan.getPatronId() + " book " + loan.getBookId() + " renewed.");					
				}
			}
		} catch (Exception ex) {
			throw new LibraryException("Unable to renew loan \nError: " + ex);
			
		}
	}	
}
