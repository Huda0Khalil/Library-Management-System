import { Component, inject } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatIcon } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { RouterLink } from '@angular/router';
import { EditAddCategoryComponent } from '../edit-add-category/edit-add-category.component';
import { DeleteConfirmDialogComponent } from '../../delete-confirm-dialog/delete-confirm-dialog.component';

@Component({
  selector: 'app-view-all-categories',
  imports: [CommonModule, MatFormFieldModule, MatInputModule, MatTableModule, MatIcon, MatDialogModule, RouterLink],
  templateUrl: './view-all-categories.component.html',
  styleUrl: './view-all-categories.component.css'
})
export class ViewAllCategoriesComponent {
  isEditMode: boolean = false;
  selectedCategory: any = null;
  readonly dialog = inject(MatDialog);

  constructor(private categoryService:CategoryService){}
  categories:any[] = [];
  displayedColumns: string[] = ['ID', 'Name', 'Description', 'View', 'Edit', 'Delete'];
  ngOnInit(): void {
    this.loadCategories();  
  }
  loadCategories(){
    this.categoryService.getCategories().subscribe((data:any)=>{
      this.categories=data;
      console.log(this.categories);
    });
  }
  openDialog(id: any) {
    const dialogRef = this.dialog.open(DeleteConfirmDialogComponent);
    dialogRef.componentInstance.type = 'category';
    dialogRef.componentInstance.Id = id;
    dialogRef.afterClosed().subscribe(result => {
        if (result === true) {
          this.deleteCategory(id);
        }
      });
  }
  deleteCategory(id: any) {
    this.categoryService.deleteCategory(id).subscribe((result:any)=>{
      console.log('Category deleted successfully', result);
      this.loadCategories();
    }, (error:any)=>{
      console.error('Error deleting category', error);
    });
  }
  editCtegory(id: any) {
    this.categoryService.getCategoryById(id).subscribe((data:any)=>{
      this.isEditMode = true;
      this.selectedCategory = data;
      const dialogRef = this.dialog.open(EditAddCategoryComponent,{
        width: '1000px',       
        height: 'auto',       
        maxWidth: '90vw'
      });
      dialogRef.componentInstance.isEditMode = this.isEditMode;
      dialogRef.componentInstance.CategoryData = this.selectedCategory;
      dialogRef.componentInstance.formSubmit.subscribe((result: any) => {
        this.loadCategories();
      }
    );

    dialogRef.afterClosed().subscribe(result => {
        this.isEditMode = false;
        this.selectedCategory = null;
      });
  });
  }

  AddCategory() {
    this.isEditMode = false;
      this.selectedCategory = null;
      const dialogRef = this.dialog.open(EditAddCategoryComponent,{
        width: '1000px',
        height: 'auto',
        maxWidth: '90vw'
      });
      dialogRef.componentInstance.isEditMode = this.isEditMode;
        dialogRef.componentInstance.CategoryData = this.selectedCategory;
        dialogRef.componentInstance.formSubmit.subscribe((result: any) => {
          this.loadCategories();
        }
      );
      dialogRef.afterClosed().subscribe(result => {
          this.isEditMode = false;
          this.selectedCategory = null;
        });
    }
}
