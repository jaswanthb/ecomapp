import { Component } from '@angular/core';
import { CustomerServiceService } from '../services/customer-service.service';

@Component({
  selector: 'app-get-customers',
  standalone: true,
  imports: [],
  templateUrl: './get-customers.component.html',
  styleUrl: './get-customers.component.css'
})
export class GetCustomersComponent {
  constructor(private customerService: CustomerServiceService){}

  customers: any[] = [];

  getCustomers(){
    //debugger;
    var res = this.customerService.getCustomers().subscribe(data => {
      this.customers = data as any[];
      console.log("custResponse",this.customers);
    });
    console.log("res",res);
    //show some edit btn/deletes
  }
}
