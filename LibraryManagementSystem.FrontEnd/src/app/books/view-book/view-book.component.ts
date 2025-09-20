import { Component } from '@angular/core';
import { BookService } from '../../services/book.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-view-book',
  imports: [CommonModule],
  templateUrl: './view-book.component.html',
  styleUrl: './view-book.component.css'
})
export class ViewBookComponent {
book:any;
id! : number ;
constructor(private route: ActivatedRoute, private bookService: BookService){}

ngOnInit(): void {
  this.id = Number(this.route.snapshot.paramMap.get('id'));
  this.loadBook();  
}
loadBook(){
  this.bookService.getBookById(this.id).subscribe((data:any)=>{
    this.book = data;
    console.log(this.book);
  });
}
}
