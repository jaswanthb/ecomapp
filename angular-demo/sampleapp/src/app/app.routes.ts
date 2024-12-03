import { Routes } from '@angular/router';
import { DatabindingComponent } from './databinding/databinding.component';
import { DirectiveSampleComponent } from './directive-sample/directive-sample.component';
import { PipeSampleComponent } from './pipe-sample/pipe-sample.component';
import { PersonalComponent } from './pipe-sample/personal/personal.component';
import { EducationComponent } from './pipe-sample/education/education.component';
import { CustomerAddComponent } from './customer/customer-add/customer-add.component';
import { AddProductComponent } from './product/add-product/add-product.component';
import { AddProductModelDrivenComponent } from './product/add-product-model-driven/add-product-model-driven.component';

export const routes: Routes = [
    { path: "databinding", component: DatabindingComponent },
    { path: "dir/:id", component: DirectiveSampleComponent },
    { path: "pipe", component: PipeSampleComponent, children:[
        {path:"personal", component:PersonalComponent},
        {path:"education", component:EducationComponent}
    ] },
    { path: "customer", component: CustomerAddComponent },
    { path: "add-product", component: AddProductComponent },
    {path:"model-driven", component:AddProductModelDrivenComponent},
    {path:"**", component:DatabindingComponent} //404
];
