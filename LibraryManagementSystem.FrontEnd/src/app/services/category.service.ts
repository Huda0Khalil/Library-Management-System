import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }
  private apiUrl = environment.apiUrl+'/Categories';
  getCategories() {
    return this.http.get(this.apiUrl);
  } 
  addCategory(category: any) {
    return this.http.post(this.apiUrl, category);
  }
  updateCategory(id: number, category: any) {
    return this.http.put(`${this.apiUrl}/${id}`, category);
  } 
  deleteCategory(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  getCategoryById(id: number) {
    return this.http.get(`${this.apiUrl}/${id}`);
  }
}
