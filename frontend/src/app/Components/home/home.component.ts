import { Component, OnInit } from '@angular/core';
import { MydataService } from '../../Services/mydata.service';
import { Product } from '../../models/Product.Model';
import { CommonModule, NgFor } from '@angular/common';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  imports: [NgFor,NgIf],
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
products: Product[] = [];

  constructor(
    private myDataService:MydataService,
    public router: Router
  ){ }

ngOnInit(): void {
  this.loadProducts();
}

loadProducts(): void {
  this.myDataService.getAllProducts().subscribe({
    next: (data: Product[]) => {
      data.reverse();
      this.products = data;

    },
    error: (error) => {
      console.error('Error fetching products:', error);
    }
  });
}

deleteProduct(id: number): void {
  this.myDataService.deleteProduct(id).subscribe({
    next: () => {
      alert('Deleted.');
      window.location.reload();
    },
    error: () => {
      alert('Failed to delete. Please try again.');
    }
  });
}

}

