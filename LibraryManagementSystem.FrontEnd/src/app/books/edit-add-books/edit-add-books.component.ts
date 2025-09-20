import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges  } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatOption } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelect } from '@angular/material/select';
import { BookService } from '../../services/book.service';
import { CategoryService } from '../../services/category.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-add-books',
  standalone: true,
  imports: [CommonModule,MatFormFieldModule,MatInputModule,ReactiveFormsModule,MatButtonModule, MatOption, MatCheckboxModule, MatSelect],
  templateUrl: './edit-add-books.component.html',
  styleUrl: './edit-add-books.component.css'
})
export class EditAddBooksComponent implements OnInit{

  @Input() isEditMode:boolean = false;
  @Input() bookData:any;
  @Output() formSubmit: EventEmitter<any> = new EventEmitter<any>();
  bookForm!: FormGroup;
  categories: any[] = [];
  constructor(private fb: FormBuilder, private bookService:BookService, private categoryService:CategoryService, private dialogRef: MatDialogRef<EditAddBooksComponent>) {}
  

  ngOnInit(): void {
  this.bookForm = this.fb.group({
    id: [null],
    title: ['', [Validators.required, Validators.maxLength(150)]],
    author: ['', [Validators.required, Validators.maxLength(100)]],
    isbn: ['', [Validators.required, Validators.pattern(/^\d{3}-\d{10}$/)]],
    publishedYear: [
      null,
      [Validators.min(1450), Validators.max(2100)]
    ],
    isAvailable: [false, Validators.required],
    description: ['', [Validators.maxLength(500)]],
    publisher: ['', [Validators.maxLength(100)]],
    language: ['', [Validators.maxLength(50)]],
    categoryIds: [[], [Validators.required]],
  })
  this.categoryService.getCategories().subscribe((data:any)=>{
    this.categories = data;
  });
     if(this.isEditMode && this.bookData){
      console.log(this.bookData);

      this.bookForm.patchValue(this.bookData);
      this.bookForm.get('categoryIds')?.setValue(this.bookData.categories?.map((cat: any) => cat.id) || []);
    }else{
      this.bookForm.reset();
    }
}
  onSubmit() {
    if (this.bookForm.invalid) {
      return;
    }
    const formValue = this.bookForm.value;
    if (this.isEditMode) {
      this.bookService.updateBook(formValue.id, formValue).subscribe({
        next: (res) => {
          this.formSubmit.emit(true);
          this.dialogRef.close();
        },
        error: (err) => {
          console.error('Error updating book:', err);
        }
      });
    } else {
      formValue.id = 0; // Ensure ID is 0 for new book
      this.bookService.addBook(formValue).subscribe({
        next: (res) => {
          this.formSubmit.emit(true);
          this.dialogRef.close();
        },
        error: (err) => {
          console.error('Error adding book:', err);
        }
      });
    }
  }
}
