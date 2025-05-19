import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from '../../models/Product.Model';
import { MydataService } from '../../Services/mydata.service';


@Component({
  selector: 'app-add-product',
  imports: [ReactiveFormsModule],
  standalone: true,
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {
createProductForm: FormGroup;

  constructor(
    public router: Router,
    private formBuilder: FormBuilder,
    private dataService: MydataService
  ) {
    this.createProductForm = this.formBuilder.group({
      name: [],
      description: [],
      price: []
    });
  }

  saveProduct(): void {
    if (this.createProductForm.valid) {
      const newProduct: Product = {
        id: 0,
        name: this.createProductForm.value.name,
        description: this.createProductForm.value.description,
        price: this.createProductForm.value.price

      };

      this.dataService.createProduct(newProduct).subscribe({
        next: () => {
          alert('successful.');
          this.router.navigate(['/']);
        },
        error: (error) => {
          console.error('Error creating product:', error);
          alert('Failed. Please try again');
        }
      })
    }  
  }

  cancel(): void {
    this.router.navigate(['/']);
  }
}
