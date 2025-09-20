import { Routes } from '@angular/router';
import path from 'path';

export const routes: Routes = [
  {
	path: 'view-books',
	loadComponent: () => import('./books/allBooks/view-all-books/view-all-books.component').then(c => c.ViewAllBooksComponent)
  },
  {
    path: 'view-book/:id',
    loadComponent: () => import('./books/view-book/view-book.component').then(c => c.ViewBookComponent)
  },
  {
    path: 'view-categories',
    loadComponent: () => import('./categories/view-all-categories/view-all-categories.component').then(c => c.ViewAllCategoriesComponent)
  },
  {
    path: 'view-category/:id',
    loadComponent: () => import('./categories/view-category/view-category.component').then(c => c.ViewCategoryComponent)
  },
  
];
