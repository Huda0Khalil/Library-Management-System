import { Component, inject } from '@angular/core';
import { BookService } from '../../../services/book.service';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableDataSource } from '@angular/material/table';
import { MatIcon } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { DeleteConfirmDialogComponent } from '../../../delete-confirm-dialog/delete-confirm-dialog.component';
import { EditAddBooksComponent } from '../../edit-add-books/edit-add-books.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-view-all-books',
  imports: [CommonModule, MatFormFieldModule, MatInputModule, MatTableModule, MatIcon, MatDialogModule, RouterLink],
  standalone: true,
  templateUrl: './view-all-books.component.html',
  styleUrl: './view-all-books.component.css'
})
export class ViewAllBooksComponent {
isEditMode: boolean = false;
selectedBook: any = null;
books:any[]=[];
displayedColumns: string[] = ['ID', 'Title', 'Author', 'Is Available', 'View','Edit', 'Delete'];
dataSource = new MatTableDataSource(this.books);
readonly dialog = inject(MatDialog);

constructor(private bookservice:BookService) { }
ngOnInit(): void {
  this.loadBooks();
}
loadBooks(){
  this.bookservice.getBooks().subscribe((data:any)=>{
    this.books=data;
  });
}
AddBook() {
  this.isEditMode = false;
  this.selectedBook = null;
  const dialogRef = this.dialog.open(EditAddBooksComponent,{
    width: '1000px',
    height: 'auto',
    maxWidth: '90vw'
  });
  dialogRef.componentInstance.isEditMode = this.isEditMode;
    dialogRef.componentInstance.bookData = this.selectedBook;
    dialogRef.componentInstance.formSubmit.subscribe((result: any) => {
      this.loadBooks();
    }
  );
  dialogRef.afterClosed().subscribe(result => {
      this.isEditMode = false;
      this.selectedBook = null;
    });
  
}
editBook(id: any) {
  this.bookservice.getBookById(id).subscribe((data:any)=>{
    this.isEditMode = true;
    this.selectedBook = data;
    const dialogRef = this.dialog.open(EditAddBooksComponent,{
      width: '1000px',       
      height: 'auto',       
      maxWidth: '90vw'
    });
    dialogRef.componentInstance.isEditMode = this.isEditMode;
    dialogRef.componentInstance.bookData = this.selectedBook;
    dialogRef.componentInstance.formSubmit.subscribe((result: any) => {
      this.loadBooks();
    }
  );
   
    dialogRef.afterClosed().subscribe(result => {
      this.isEditMode = false;
      this.selectedBook = null;
    });
    
  });
}
openDialog(id: any) {
  const dialogRef = this.dialog.open(DeleteConfirmDialogComponent);
  dialogRef.componentInstance.type = 'book';
  dialogRef.componentInstance.Id = id;
  dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.deleteBook(id);
      }
    });

}
deleteBook(id: any) {
  this.bookservice.deleteBook(id).subscribe((data:any)=>{
    this.loadBooks();
  });
}  
}
