import { Component } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-view-category',
  imports: [CommonModule],
  templateUrl: './view-category.component.html',
  styleUrl: './view-category.component.css'
})
export class ViewCategoryComponent {
category:any;
id! : number ;
constructor(private route: ActivatedRoute, private categoryService:CategoryService, private location: Location){}
ngOnInit(): void {
  this.id = Number(this.route.snapshot.paramMap.get('id'));
  this.loadCategory();  
}
loadCategory(){
  this.categoryService.getCategoryById(this.id).subscribe((data:any)=>{
    this.category = data;
    console.log(this.category);
  });
}
goBack(): void {
    this.location.back();
  }
}
