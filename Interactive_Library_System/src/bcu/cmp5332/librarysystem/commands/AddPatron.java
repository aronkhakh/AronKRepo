package bcu.cmp5332.librarysystem.commands;

import bcu.cmp5332.librarysystem.main.LibraryException;
import bcu.cmp5332.librarysystem.model.Book;
import bcu.cmp5332.librarysystem.model.Library;
import bcu.cmp5332.librarysystem.model.Patron;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class AddPatron implements Command {

	private final String name;
	private final String phone;
	private final List<Book> books;

	public AddPatron(String name, String phone, List<Book> books) {
		this.name = name;
		this.phone = phone;
		this.books = books;
	}

	@Override
	public void execute(Library library, LocalDate currentDate) throws LibraryException {
		// TODO: implementation here
		int lastIndex = library.getPatrons().size() - 1;
		int maxId = library.getPatrons().get(lastIndex).getId();
		List<Book> books = new ArrayList<Book>();
		Patron patron = new Patron(++maxId, name, phone, books);
		library.addPatron(patron);
		System.out.println(patron.getId() + "added.");
	}
}