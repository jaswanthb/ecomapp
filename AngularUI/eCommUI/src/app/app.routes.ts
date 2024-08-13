import { Routes } from '@angular/router';
import { GetCustomersComponent } from './get-customers/get-customers.component';
import { AppComponent } from './app.component';
import { GetSupplierComponent } from './get-supplier/get-supplier.component';

export const routes: Routes = [
    {
        path:"customers",component:GetCustomersComponent
    },
    {
        path:"home",component:AppComponent
    },
    {
        path:"suppliers",component:GetSupplierComponent
    }
];
