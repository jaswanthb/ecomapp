import { Routes } from '@angular/router';
import { DatabindingComponent } from './databinding/databinding.component';
import { DirectiveSampleComponent } from './directive-sample/directive-sample.component';
import { PipeSampleComponent } from './pipe-sample/pipe-sample.component';
import { PersonalComponent } from './pipe-sample/personal/personal.component';
import { EducationComponent } from './pipe-sample/education/education.component';
import { CustomerAddComponent } from './customer/customer-add/customer-add.component';
import { TemplateDrivenComponent } from './product/template-driven/template-driven.component';
import { ModelDrivenComponent } from './product/model-driven/model-driven.component';

export const routes: Routes = [
    { path: "databinding", component: DatabindingComponent },
    { path: "dir/:id", component: DirectiveSampleComponent },
    { path: "pipe", component: PipeSampleComponent, children:[
        {path:"personal", component:PersonalComponent},
        {path:"education", component:EducationComponent}
    ] },
    { path: "customer", component: CustomerAddComponent },
    { path: "template-driven", component: TemplateDrivenComponent },
     {path:"model-driven", component:ModelDrivenComponent},
    {path:"**", component:DatabindingComponent} //404
];
