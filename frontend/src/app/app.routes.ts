import { Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { AddProductComponent } from './Components/add-product/add-product.component';
import { EditProductComponent } from './Components/edit-product/edit-product.component';

export const routes: Routes = [
    {
        path:'',
        component : HomeComponent,
    },
    {
        path: 'add-product',
        component : AddProductComponent
    },
    {//edit route has id param
        path: 'edit-product/:id',
        component : EditProductComponent
    },
    {
        path: 'Lesson-1',
        component: AddProductComponent
    }
];
