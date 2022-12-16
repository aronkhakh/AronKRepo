package bcu.cmp5332.librarysystem.model;

import bcu.cmp5332.librarysystem.main.LibraryException;
import java.time.LocalDate;
//import java.util.ArrayList;
import java.util.List;

public class Patron {

	private int id;
	private String name;
	private String phone;
	private final List<Book> books;

	public Patron(int id, String name, String phone, List<Book> books) {
		this.id = id;
		this.name = name;
		this.phone = phone;
		this.books = books;
	}

	public void borrowBook(Book book, LocalDate dueDate) throws LibraryException {
		// TODO: implementation here
	}

	public void renewBook(Book book, LocalDate dueDate) throws LibraryException {
		// TODO: implementation here
	}

	public void returnBook(Book book) throws LibraryException {
		// TODO: implementation here
	}

	public void addBook(Book book) {
		this.books.add(book);
	}

	public void removeBook(Book book) {
		this.books.remove(book);
	}

	public String getDetails() {
		return id + " " + " " + name + " " + phone;
	}

	public int getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public String getPhone() {
		return phone;
	}

	public List<Book> getBooks(){
		return this.books;
	}
}
