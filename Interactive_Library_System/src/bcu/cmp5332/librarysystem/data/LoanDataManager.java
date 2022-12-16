package bcu.cmp5332.librarysystem.data;

import bcu.cmp5332.librarysystem.main.LibraryException;
import bcu.cmp5332.librarysystem.model.Book;
import bcu.cmp5332.librarysystem.model.Library;
import bcu.cmp5332.librarysystem.model.Loan;
import bcu.cmp5332.librarysystem.model.Patron;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDate;
import java.util.List;
import java.util.Scanner;

public class LoanDataManager implements DataManager {

	public final String RESOURCE = "./resources/data/loans.txt";

	@Override
	public void loadData(Library library) throws IOException, LibraryException {
		try (Scanner sc = new Scanner(new File(RESOURCE))) {
			int line_idx = 1;
			while (sc.hasNextLine()) {
				String line = sc.nextLine();
				String[] properties = line.split(SEPARATOR, -1);
				int id;
				Patron patron;
				Book book;
				Loan loan;
				
				try {
					id = Integer.parseInt(properties[0]);
				} catch (Exception ex) {
					throw new LibraryException(
							"Unable to parse loan id " + properties[0] + " on line " + line_idx + "\nError: " + ex);
				}
				try {
					int patronId = Integer.parseInt(properties[1]);
					patron = library.getPatronByID(patronId);
				} catch (Exception ex) {
					throw new LibraryException(
							"Unable to parse patron id " + properties[1] + " on line " + line_idx + "\nError: " + ex);
				}
				try {
					int bookId = Integer.parseInt(properties[2]);
					book = library.getBookByID(bookId);
				} catch (Exception ex) {
					throw new LibraryException(
							"Unable to parse book id " + properties[2] + " on line " + line_idx + "\nError: " + ex);
				}
				try {
					LocalDate startDate = LocalDate.parse(properties[3]);
					LocalDate dueDate = LocalDate.parse(properties[4]);
					loan = new Loan(id, patron, book, startDate, dueDate);
					library.addLoan(loan);
				} catch (NumberFormatException ex) {
					throw new LibraryException("Unable to parse patron for start date " + properties[3] + " due date "
							+ properties[4] + " on line " + line_idx + "\nError: " + ex);
				}

				try {
					// assign book loan info from loans data
					// assign patron book info from loans data
					book.setLoan(loan);
					patron.addBook(book);
				} catch (Exception ex) {
					throw new LibraryException("Unable to assign loan on line " + line_idx + "\nError: " + ex);
				}
				line_idx++;
				}
			}
		}

	@Override
	public void storeData(Library library) throws IOException {
		try (PrintWriter out = new PrintWriter(new FileWriter(RESOURCE))) {
		for (Loan loan : library.getLoans()) {
			out.print(loan.getId() + SEPARATOR);
			out.print(loan.getPatronId() + SEPARATOR);
			out.print(loan.getBookId() + SEPARATOR);
			out.print(loan.getStartDate() + SEPARATOR);
			out.print(loan.getDueDate() + SEPARATOR);
			out.println();
			}
		}
	}
}