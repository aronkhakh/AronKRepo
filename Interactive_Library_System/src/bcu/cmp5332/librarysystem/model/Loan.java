package bcu.cmp5332.librarysystem.model;

import java.time.LocalDate;

public class Loan {

	private int id;
	private Patron patron;
	private Book book;
	private LocalDate startDate;
	private LocalDate dueDate;

	public Loan(int id, Patron patron, Book book, LocalDate startDate, LocalDate dueDate) {
		this.id = id;
		this.patron = patron;
		this.book = book;
		this.startDate = startDate;
		this.dueDate = dueDate;
	}

	public int getId() {
		return id;
	}

	public int getPatronId() {
		return patron.getId();
	}

	public int getBookId() {
		return book.getId();
	}

	public String getStartDate() {
		return startDate.toString();
	}

	public String getDueDate() {
		return dueDate.toString();
	}

	public void setDueDate(LocalDate newDueDate) {
		dueDate = newDueDate;
	}
}

// TODO: implementation of Getter and Setter methods
