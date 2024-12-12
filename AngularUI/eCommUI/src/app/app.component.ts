import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {GetCustomersComponent} from './get-customers/get-customers.component'
import { GetSupplierComponent } from './get-supplier/get-supplier.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, GetCustomersComponent,GetSupplierComponent],

  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'eCommUI';
}
