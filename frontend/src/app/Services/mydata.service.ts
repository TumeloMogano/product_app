import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/Product.Model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MydataService {
  private apiUrl = `https://localhost:7299/api/Product`;

  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}/GetAllProducts`);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/GetProduct/${id}`);
  }

  createProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.apiUrl}/CreateProduct`, product);
  }

  editProduct(id: number, product: Partial<Product>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/EditProduct/${id}`, product);
  }

  deleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteProduct/${id}`);
  }
}
