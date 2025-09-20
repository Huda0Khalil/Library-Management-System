import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CategoryService } from '../../services/category.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-add-category',
  imports: [CommonModule, MatFormFieldModule,MatInputModule,ReactiveFormsModule,MatButtonModule],
  templateUrl: './edit-add-category.component.html',
  styleUrl: './edit-add-category.component.css'
})
export class EditAddCategoryComponent {

  @Input() isEditMode:boolean = false;
  @Input() CategoryData:any;
  @Output() formSubmit: EventEmitter<any> = new EventEmitter<any>();
  categoryForm!: FormGroup;
  constructor(private fb: FormBuilder, private categoryService:CategoryService,private dialogRef: MatDialogRef<EditAddCategoryComponent>) {}
  ngOnInit(): void {
    this.categoryForm = this.fb.group({
      id: [null],
      name: ['', Validators.required],
      description: ['',[Validators.required, Validators.maxLength(500)]]
    });
    if(this.isEditMode && this.CategoryData){
      console.log(this.CategoryData);
      this.categoryForm.patchValue(this.CategoryData);
    }else{
      this.categoryForm.reset();
    }
  }
  onSubmit() {
    if (this.categoryForm.invalid) {
      return;
    }
    if(this.isEditMode){
      const id = this.categoryForm.get('id')?.value;
      this.categoryService.updateCategory(id, this.categoryForm.value).subscribe((result:any)=>{
        console.log('Category updated successfully', result);
        this.formSubmit.emit(result);
          this.dialogRef.close();
      }, 
      (error:any)=>{
        console.error('Error updating category', error);
      });
    }else{
      this.categoryService.addCategory(this.categoryForm.value).subscribe((result:any)=>{
        console.log('Category added successfully', result);
        this.formSubmit.emit(result);
        this.dialogRef.close();
        
      }, (error:any)=>{
        console.error('Error adding category', error);
      });
    }
  }
}
