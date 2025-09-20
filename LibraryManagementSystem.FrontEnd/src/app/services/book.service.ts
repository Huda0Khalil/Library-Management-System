import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }
  private apiUrl = environment.apiUrl+'/Books';
  getBooks(){
    return this.http.get(this.apiUrl);
  }
  addBook(book:any){
    return this.http.post(this.apiUrl,book);
  }
  updateBook(id:number,book:any){
    return this.http.put(`${this.apiUrl}/${id}`,book);
  }
  deleteBook(id:number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  getBookById(id:number){
    return this.http.get(`${this.apiUrl}/${id}`);
  }
}
