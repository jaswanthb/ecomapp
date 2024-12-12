import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerServiceService } from '../services/customer-service.service';
import { Customer } from '../models/Customer';

@Component({
  selector: 'app-edit-customer',
  standalone: true,
  imports: [],
  templateUrl: './edit-customer.component.html',
  styleUrl: './edit-customer.component.css'
})
export class EditCustomerComponent implements OnInit {

  custId: any;
  customer: any;
constructor(
  private route: ActivatedRoute,
  private router: Router,
  private custService: CustomerServiceService
){
  
}

ngOnInit() {
  this.custId = this.route.snapshot.paramMap.get('companyName');
  if(this.custId == null){
    alert("New cust")
  }
  else {
    this.custService.getCustomerById(this.custId).subscribe(data => {
      this.customer = data as Customer;
      debugger;
    });
  }
}

UpdateCustomer(){
  //Prepare Payload
  this.custService.insertCustomer(this.customer);
}

}
