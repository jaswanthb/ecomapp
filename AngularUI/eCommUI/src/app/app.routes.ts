import { Routes } from '@angular/router';
import { GetCustomersComponent } from './get-customers/get-customers.component';
import { AppComponent } from './app.component';
import { GetSupplierComponent } from './get-supplier/get-supplier.component';
import { EditCustomerComponent } from './edit-customer/edit-customer.component';

export const routes: Routes = [
    {
        path:"customers",component:GetCustomersComponent, title:"Customers"
    },
    {
        path:"new-customer",component:EditCustomerComponent,title:"New Customer"
    },
    {
        path:"edit-customer/:id",component:EditCustomerComponent,title:"Edit Customer"
    },
    {
        path:"home",component:AppComponent, title:"Home"
    },
    {
        path:"suppliers",component:GetSupplierComponent,title:"Suppliers"
    }
];
