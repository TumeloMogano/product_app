import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MydataService } from '../../Services/mydata.service';
import { Product } from '../../models/Product.Model';

@Component({
  selector: 'app-edit-product',
  imports: [ReactiveFormsModule],
  standalone: true,
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent implements OnInit{
editProductForm: FormGroup;
id: number;

  constructor(
    public router: Router,
    private formbuilder: FormBuilder,
    private dataService: MydataService,
    private route: ActivatedRoute
  ) {
    this.editProductForm = this.formbuilder.group({
      name: [],
      description: [],
      price: []
    });
    
    //grabs id from the route parameters :id which was defined in the routes
    const idParam = this.route.snapshot.paramMap.get('id')!;
    this.id = idParam ? Number(idParam) : 0;
    console.log(`Edit Product Component initialized with product id: ${this.id}`);
  }

  ngOnInit(): void {
    this.loadProductData();
  }

    loadProductData(): void {
    if (this.id) {
      this.dataService.getProduct(this.id).subscribe(
        product => {
          console.log('fetched role: ', product);
          this.editProductForm.patchValue({
            name: product.name,
            description: product.description,
            price: product.price
          });
        }, error => {
          console.error('Error fetching product data:', error);
        });
    }
  }

  editProduct(): void {
    if (this.editProductForm.valid) {
      const updatedProduct: Partial<Product> = {
        name: this.editProductForm.value.name,
        description: this.editProductForm.value.description,
        price: this.editProductForm.value.price
      };

      this.dataService.editProduct(this.id, updatedProduct).subscribe(
        () => {
          alert('Successful.');
          this.router.navigate(['/']);
        }, error => {
          alert('Failed. Please try again.');
        });
    }
  }

  cancel(): void {
    this.router.navigate(['/']);
  }
}
